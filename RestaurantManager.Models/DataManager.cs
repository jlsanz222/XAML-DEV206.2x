using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace RestaurantManager.Models
{
    public abstract class DataManager : INotifyPropertyChanged
    {
        
        protected RestaurantContext Repository { get;
            private set ; }
        

        public DataManager()
        {
            LoadData();
//            System.Diagnostics.Debug.WriteLine("OnDataLoaded DataManager");
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged([ CallerMemberName  ] string propName = null)
        {
            if (PropertyChanged != null)
            {
                this.PropertyChanged(this, new PropertyChangedEventArgs(propName));
            }
        }


        private async void LoadData()
        {
           
            this.Repository = new RestaurantContext();
            await this.Repository.InitializeContextAsync();
 //           System.Diagnostics.Debug.WriteLine("Antes LoadData DataManager");
            OnDataLoaded();
 //           System.Diagnostics.Debug.WriteLine("Despues LoadData DataManager");

        }

        protected abstract void OnDataLoaded();
    }
}
