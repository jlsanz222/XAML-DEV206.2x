using System.Collections.Generic;

using RestaurantManager.Models;

namespace RestaurantManager.ViewModels
{
    public class ExpediteViewModel :ViewModel
    {
        protected override void OnDataLoaded()
        {
            this.OrderItems = Repository.Orders;
            OnPropertyChanged("OrderItems");
        }

        public List<Order> OrderItems
        {
            ///           get { return base.Repository.Orders; }
            get;set;        
        }
    }
}
