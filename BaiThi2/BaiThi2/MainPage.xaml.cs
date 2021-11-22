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
using BaiThi2.Service;
using BaiThi2.Models;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace BaiThi2
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
        }

        private void To_Login(object sender, RoutedEventArgs e)
        {
            next.Navigate(typeof(Login));
        }

        private void Create(object sender, RoutedEventArgs e)
        {
            Product item = new Product() { Name = username.Text, Pasword = password.Password};
            ItemService service = new ItemService();
            service.AddNew(item);
            next.Navigate(typeof(Login));
        }
    }
}
