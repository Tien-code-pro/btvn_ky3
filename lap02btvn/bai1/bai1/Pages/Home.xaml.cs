using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using bai1.Models;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace bai1.Pages
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class Home : Page
    {
        private List<Models.Car> cars;
       
        public Home()
        {
            this.InitializeComponent();
            cars = CarManager.GetCars();
        }
        private void GridView_ItemClick(object sender, ItemClickEventArgs e)
        {
            var cars = (Models.Car)e.ClickedItem;
            ResultTextBlock.Text = "You Selected--->>" + cars.Category + "--->>Model_ " + cars.Model;
        }

    }
}
