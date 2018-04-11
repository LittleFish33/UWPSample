using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Storage;
using Windows.Storage.Pickers;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Imaging;
using Windows.UI.Xaml.Navigation;

// https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x804 上介绍了“空白页”项模板

namespace FileManagementSample
{
    public sealed partial class MainPage : Page
    {
        private StorageFile file;

        public MainPage()
        {
            this.InitializeComponent();
        }
        private async void PickImage(object sender, RoutedEventArgs e)
        {
            //选取图片
            FileOpenPicker openPicker = new FileOpenPicker();
            openPicker.FileTypeFilter.Add(".jpg");
            StorageFile Pickfile = await openPicker.PickSingleFileAsync();
            if (Pickfile != null)
            {
                //设置Image为选择的图片
                BitmapImage bitmap = new BitmapImage();
                using (var stream = await Pickfile.OpenAsync(Windows.Storage.FileAccessMode.Read))
                {
                    bitmap.SetSource(stream);
                }
                MyImage.Source = bitmap;

                //将图片保存在LocalFolder
                StorageFolder localFolder = ApplicationData.Current.LocalFolder;
                StorageFile fileCopy = await Pickfile.CopyAsync(localFolder, Pickfile.Name, NameCollisionOption.ReplaceExisting);
            }
        }

    }
}
