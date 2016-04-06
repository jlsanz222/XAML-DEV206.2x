using System.Collections.Generic;


namespace RestaurantManager.Models
{
    public class OrderDataManager : DataManager
    {       
        protected override void OnDataLoaded()
        {
        //    System.Diagnostics.Debug.WriteLine("OnDataLoaded OrderDataManager");

            this.MenuItems = Repository.StandardMenuItems;

            OnPropertyChanged("MenuItems");

        //    System.Diagnostics.Debug.WriteLine("MenuItems 1 "+this.MenuItems[1].Title.ToString());

            this.CurrentlySelectedMenuItems = new List<MenuItem>
            {
                this.MenuItems[3],
                this.MenuItems[5]
            };
            OnPropertyChanged("CurrentlySelectedMenuItems");

        }
               

        public List<MenuItem> MenuItems { get;  set; }

        public List<MenuItem> CurrentlySelectedMenuItems { get; set; }



    }
}
