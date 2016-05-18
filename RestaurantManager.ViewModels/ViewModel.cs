using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.ComponentModel;
using System.Runtime.CompilerServices;

using RestaurantManager.Models;

namespace RestaurantManager.ViewModels
{
    public abstract class ViewModel : INotifyPropertyChanged
    {
        protected RestaurantContext Repository { get; private set; }

        private bool _isLoading;
        public bool IsLoading
        {
            get { return _isLoading; }
            set {
                _isLoading = value;
                OnPropertyChanged("IsLoading");
                }
        }


        public ViewModel()
        {
            LoadData();
        }

        private async void LoadData()
        {
            /**              
             this.Repository = new RestaurantContext();
            await this.Repository.InitializeContextAsync();
 //           System.Diagnostics.Debug.WriteLine("Antes LoadData DataManager");
            OnDataLoaded();
 //           System.Diagnostics.Debug.WriteLine("Despues LoadData DataManager");
 
             **/
            IsLoading = true;
            this.Repository = await RestaurantContextFactory.GetRestaurantContextAsync();
            OnDataLoaded();
            IsLoading = false;
        }

        protected abstract void OnDataLoaded();

        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged([CallerMemberName] string propName = null)
        {
            if (PropertyChanged != null)
            {
                this.PropertyChanged(this, new PropertyChangedEventArgs(propName));
            }
        }


    }
}