using System.Collections.Generic;
using System.Collections.ObjectModel;


using RestaurantManager.Models;
using System.Windows.Input;
using System.Linq;

namespace RestaurantManager.ViewModels
{
    public class OrderViewModel : ViewModel
    {

        public string SpecialNotes { get; set; }

        private ObservableCollection<MenuItem> _currentlySelectedMenuItems;
       
        public ICommand AddToOrderCommand { get; private set; }
        public ICommand SubmitOrderCommand { get; private set; }



        public OrderViewModel()
        {
            AddToOrderCommand = new DelegateCommand<MenuItem>(AddToOrder);
            SubmitOrderCommand = new DelegateCommand<ObservableCollection<MenuItem>>(SubmitOrder);
        }


        protected override void OnDataLoaded()
        {
            //    System.Diagnostics.Debug.WriteLine("OnDataLoaded OrderDataManager");

            this.MenuItems = Repository.StandardMenuItems;

            OnPropertyChanged("MenuItems");

            //    System.Diagnostics.Debug.WriteLine("MenuItems 1 "+this.MenuItems[1].Title.ToString());

            this.CurrentlySelectedMenuItems = new ObservableCollection<MenuItem>();
            /*
             {
              // selection by default 
                 this.MenuItems[3],
                 this.MenuItems[5]             
             };
            */
            OnPropertyChanged("CurrentlySelectedMenuItems");

        }
               

        public List<MenuItem> MenuItems { get;  set; }

        
        public ObservableCollection<MenuItem> CurrentlySelectedMenuItems
        {
            get { return _currentlySelectedMenuItems; }
            set
            {
                if (value != _currentlySelectedMenuItems)
                {
                    _currentlySelectedMenuItems = value;
                    OnPropertyChanged("CurrentlySelectedMenuItems");

                }
            }
        }

        public object MessageBox { get; private set; }

        private void AddToOrder(MenuItem menuItem)
        {
            CurrentlySelectedMenuItems.Add(menuItem);            
        }

        private void SubmitOrder(ObservableCollection<MenuItem> menuItem)
        {
            Order newOrder = new Order
            {
                Table = base.Repository.Tables.First(),
                Complete = false,
                Expedite = false,
                Items = menuItem.ToList(),
                SpecialRequests = SpecialNotes
            };

    /*
            if (newOrder.SpecialRequests!=null)
            {
                System.Diagnostics.Debug.WriteLine("SubmitOrder newOrder: --" + newOrder.ToString() + "--");
            } else      System.Diagnostics.Debug.WriteLine("SubmitOrder newOrder: --nulo--");

    */
    //      System.Diagnostics.Debug.WriteLine("SubmitOrder newOrder: --" + newOrder.ToString() + "--");
    //      System.Diagnostics.Debug.WriteLine("Before SubmitOrder OrderViewModel");

            Repository.Orders.Add(newOrder);
        
    //      System.Diagnostics.Debug.WriteLine("After SubmitOrder OrderViewModel");
    //      System.Diagnostics.Debug.WriteLine("SubmitOrder Orders: --" + Repository.Orders.Last().ToString() + "--");


        }


    }
}
