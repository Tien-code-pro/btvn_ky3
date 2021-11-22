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
using Windows.Storage;
using Windows.Storage.Streams;
using Windows.UI.Popups;
using Newtonsoft.Json;
using BaiThi1.Models;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace BaiThi1
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        List<Employee> list;

        public MainPage()
        {
            this.InitializeComponent();
            list = new List<Employee>();
        }


        private async void btn_add_Click(object sender, RoutedEventArgs e)
        {

            Employee em = new Employee();
            em.EmpID = tb_EmpID.Text;
            em.EmpName = tb_EmpName.Text;
            em.DOB = tb_DOB.Text;            

            list.Add(em);

            //Pase Object List sang Json String
            string jsonContent = JsonConvert.SerializeObject(list);

            //Folder
            StorageFolder localFolder = ApplicationData.Current.LocalFolder;
            StorageFile textFile = await localFolder.CreateFileAsync("employee.json", CreationCollisionOption.ReplaceExisting);
            using (IRandomAccessStream textStream = await textFile.OpenAsync(FileAccessMode.ReadWrite))
            {
                using (DataWriter textWriter = new DataWriter(textStream))
                {
                    textWriter.WriteString(jsonContent);
                    await textWriter.StoreAsync();
                }

            }


            Windows.UI.Popups.MessageDialog dialog = new Windows.UI.Popups.MessageDialog("Them du lieu thanh cong");
            await dialog.ShowAsync();
        }

        private void btn_save_Click(object sender, RoutedEventArgs e)
        {
            tb_EmpID.Text = "";
            tb_EmpName.Text = "";
            tb_DOB.Text = "";            
        }

        private async void btn_Load_Click(object sender, RoutedEventArgs e)
        {
            // Đọc file Json
            StorageFolder localFolder = ApplicationData.Current.LocalFolder;
            StorageFile textFile = await localFolder.GetFileAsync("employee.json");
            using (IRandomAccessStream textStream = await textFile.OpenReadAsync())
            {
                DataReader textReader = new DataReader(textStream);
                uint textLength = (uint)textStream.Size;
                await textReader.LoadAsync(textLength);
                string jsonContent = textReader.ReadString(textLength);
                //Get list từ file Json
                List<Employee> listJSON = JsonConvert.DeserializeObject<List<Employee>>(jsonContent);
                //listJSON đã chứa giá trị
                //Bindding đến name="listView" để hiên thị dữ liệu
                this.listView.ItemsSource = listJSON;
            }
        }
    }
}
