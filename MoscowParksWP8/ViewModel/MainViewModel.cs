using GalaSoft.MvvmLight;
using Microsoft.WindowsAzure.MobileServices;
using MoscowParksWP8;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

namespace MoscowParksWP8.ViewModel
{
    /// <summary>
    /// This class contains properties that the main View can data bind to.
    /// <para>
    /// Use the <strong>mvvminpc</strong> snippet to add bindable properties to this ViewModel.
    /// </para>
    /// <para>
    /// You can also use Blend to data bind with the tool's support.
    /// </para>
    /// <para>
    /// See http://www.galasoft.ch/mvvm
    /// </para>
    /// </summary>
    public class MainViewModel : ViewModelBase
    {
        /// <summary>
        /// Initializes a new instance of the MainViewModel class.
        /// </summary>
        public MainViewModel()
        {
            ////if (IsInDesignMode)
            ////{
            ////    // Code runs in Blend --> create design time data.
            ////}
            ////else
            ////{
            ////    // Code runs "for real"
            ////}
        }

        private ObservableCollection<ParkItem> _items = new ObservableCollection<ParkItem>();
        /// <summary>
        /// Park items
        /// </summary>
        public ObservableCollection<ParkItem> Items
        {
            get { return _items; }
            set
            {
                _items = value;
                RaisePropertyChanged("Items");
            }
        }

        private bool _loading = false;

        public bool Loading
        {
            get { return _loading; }
            set
            {
                _loading = value;
                RaisePropertyChanged("Loading");
            }
        }

        private ParkItem _currentItem;

        public ParkItem CurrentItem
        {
            get { return _currentItem; }
            set
            {
                _currentItem = value;
                RaisePropertyChanged("CurrentItem");
            }
        }

        //public Flyout AddBox = new Flyout();

        private Collection<string> _parkImages = new Collection<string>();
        /// <summary>
        /// 
        /// </summary>
        public Collection<string> ParkImages
        {
            get { return _parkImages; }
            set
            {
                _parkImages = value;
                RaisePropertyChanged("ParkImages");
            }
        }

        private MobileServiceCollection<ParkItem, ParkItem> parkItems;
        private IMobileServiceTable<ParkItem> ParksTable = App.MobileService.GetTable<ParkItem>();

        public async Task<bool> LoadData()
        {
            this.Loading = true;
            Items = await ParksTable.ToCollectionAsync(100);
            ParkImages = new Collection<string>();
            foreach (var item in Items)
            {
                ParkImages.Add(item.Image);
            };
            RaisePropertyChanged("ParkImages");
            RaisePropertyChanged("Items");
            this.Loading = false;

            return true;
        }
    }
}