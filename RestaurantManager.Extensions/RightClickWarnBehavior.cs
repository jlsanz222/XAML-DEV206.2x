using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.Xaml.Interactivity;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Controls;
using Windows.UI.Popups;


namespace RestaurantManager.Extensions
{
    public class RightClickWarnBehavior : DependencyObject, IBehavior { 
    
    public string Message { get; set; }
    public string Title { get; set; }

    public DependencyObject AssociatedObject { get; private set; }

    private async void Page_RightTapped(object sender, RightTappedRoutedEventArgs e)
    {
        await new MessageDialog(this.Message, this.Title).ShowAsync();
    }

    public void Attach(DependencyObject associatedObject)
    {
        if (associatedObject is Page)
        {
            this.AssociatedObject = associatedObject;
            (this.AssociatedObject as Page).RightTapped += Page_RightTapped;
        }
    }

    public void Detach()
    {
        if (this.AssociatedObject != null && this.AssociatedObject is Page)
        {
            this.AssociatedObject = null;
            (this.AssociatedObject as Page).RightTapped -= Page_RightTapped;
        }
    }
        
  }
}
