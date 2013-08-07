using Microsoft.WindowsAzure.MobileServices;
using moscow_parks.Common;
using moscow_parks.ViewModel;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Net.Http;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

namespace moscow_parks
{
    public class TodoItem
    {
        public int Id { get; set; }

        [JsonProperty(PropertyName = "text")]
        public string Text { get; set; }

        [JsonProperty(PropertyName = "complete")]
        public bool Complete { get; set; }
    }


    public sealed partial class MainPage : Page
    {
        private MobileServiceCollection<TodoItem, TodoItem> items;
        private IMobileServiceTable<TodoItem> todoTable = App.MobileService.GetTable<TodoItem>();

        private MobileServiceCollection<ParkItem, ParkItem> parkItems;
        private IMobileServiceTable<ParkItem> ParksTable = App.MobileService.GetTable<ParkItem>();

        public MainPage()
        {
            this.InitializeComponent();
        }

        private async void InsertTodoItem(TodoItem todoItem)
        {
            // This code inserts a new TodoItem into the database. When the operation completes
            // and Mobile Services has assigned an Id, the item is added to the CollectionView
            await todoTable.InsertAsync(todoItem);
            items.Add(todoItem);                        
        }

        private async void RefreshTodoItems()
        {
            MobileServiceInvalidOperationException exception = null;
            try
            {
                // This code refreshes the entries in the list view by querying the TodoItems table.
                // The query excludes completed TodoItems
                items = await todoTable
                    .Where(todoItem => todoItem.Complete == false)
                    .ToCollectionAsync();
            }
            catch (MobileServiceInvalidOperationException e)
            {
                exception = e;
            }

            if (exception != null)
            {
                await new MessageDialog(exception.Message, "Error loading items").ShowAsync();
            }
            else
            {
                ListItems.ItemsSource = items;
            }
        }

        private async void UpdateCheckedTodoItem(TodoItem item)
        {
            // This code takes a freshly completed TodoItem and updates the database. When the MobileService 
            // responds, the item is removed from the list 
            await todoTable.UpdateAsync(item);
            items.Remove(item);
        }

        private void ButtonRefresh_Click(object sender, RoutedEventArgs e)
        {
            RefreshTodoItems();
        }

        private void ButtonSave_Click(object sender, RoutedEventArgs e)
        {
            var todoItem = new TodoItem { Text = TextInput.Text };
            InsertTodoItem(todoItem);
        }

        private void CheckBoxComplete_Checked(object sender, RoutedEventArgs e)
        {
            CheckBox cb = (CheckBox)sender;
            TodoItem item = cb.DataContext as TodoItem;
            UpdateCheckedTodoItem(item);
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            RefreshTodoItems();
        }

        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            HttpClient client = new HttpClient();
            string earthQuakeData = await client.GetStringAsync("http://m0rg0t.com/parks.csv");

            // Parse the file 
            CsvParser csvParser = new CsvParser();
            csvParser.RawText = earthQuakeData;
            csvParser.HasHeaderRow = true;
            csvParser.Delimiter = ';';

            var results = await csvParser.Parse();

            foreach (var item in results)
            {
                ParkItem park = new ParkItem();
                //park.Id = Int32.Parse(item["1_Номер"]);
                park.Name = item["1_Название"];
                park.Title = item["0_label"];
                park.Address = item["1_Адрес"];
                park.Lat = Double.Parse(item["0_y"].ToString().Replace(",","."));
                park.Lon = Double.Parse(item["0_x"].ToString().Replace(",", "."));
                park.Ao = item["1_Административный округ"];
                park.District = item["1_Район"];
                park.OfficialAddress = item["1_Юридический адрес"];
                park.Phone = item["1_Телефон"];
                park.Fax = item["1_Факс"];
                park.Site = item["1_Сайт"];
                park.Email = item["1_Адрес электронной почты"];
                park.Image = "http://dic.academic.ru/pictures/wiki/files/71/Grand_Kremlin_Public_Garden-2.jpg";

                await ParksTable.InsertAsync(park);
            };
           
        }
    }
}
