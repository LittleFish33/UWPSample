using System;
using System.Collections.Generic;
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
using Windows.UI.Xaml.Media.Imaging;
using Windows.UI.Xaml.Navigation;

namespace KnownFolderSample
{
    public sealed partial class MainPage : Page
    {
        StorageFile file;
        public MainPage()
        {
            this.InitializeComponent();
            SetImageSource();
        }

        private async void SetImageSource()
        {
            StorageFolder storageFolder = await KnownFolders.GetFolderForUserAsync(null, KnownFolderId.PicturesLibrary);
            //注意，这里需要更改为你自己的图片
            file = await storageFolder.GetFileAsync("detective978.jpg");
            //将图片赋给右侧的Image
            if (file != null)
            {
                BitmapImage bitmap = new BitmapImage();
                using (var stream = await file.OpenAsync(Windows.Storage.FileAccessMode.Read))
                {
                    bitmap.SetSource(stream);
                }
                MyImage.Source = bitmap;
            }
        }

        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            StorageFolder storageFolder = await KnownFolders.GetFolderForUserAsync(null, KnownFolderId.VideosLibrary);
            //CopyAsync接收三个参数，保存文件夹，新的文件名，保存方式（重名是否替换）
            await file.CopyAsync(storageFolder, "KnownFolder.jpg", NameCollisionOption.ReplaceExisting);
        }
    }
}
