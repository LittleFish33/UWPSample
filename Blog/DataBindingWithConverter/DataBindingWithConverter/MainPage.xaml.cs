using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Storage;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;


namespace DataBindingWithConverter
{
    public sealed partial class MainPage : Page
    {
        public Item MyItem;
        //LocalFolder文件存储
        private string prefix = "ms-appdata:///local/";

        public MainPage()
        {
            MyItem = new Item("ms-appx:///Assets/flash.jpg", true);
            this.InitializeComponent();
        }

        private async void ChangeImage(object sender, RoutedEventArgs e)
        {
            var openPicker = new Windows.Storage.Pickers.FileOpenPicker();
            openPicker.FileTypeFilter.Add(".jpg");
            StorageFile file = await openPicker.PickSingleFileAsync();

            //LocalFolder文件存储
            Windows.Storage.StorageFolder localFolder = Windows.Storage.ApplicationData.Current.LocalFolder;
            StorageFile fileCopy = await file.CopyAsync(localFolder, file.Name, NameCollisionOption.ReplaceExisting);

            //设置MyItem的Source，此时将使用转化器转化为Image的Source值
            MyItem.Source = prefix + file.Name;
        }
    }
}
