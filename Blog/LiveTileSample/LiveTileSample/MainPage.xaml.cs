using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Todo.Common;
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

namespace LiveTileSample
{
    public sealed partial class MainPage : Page
    {
        private LiveTileService liveTileService;
        private string source;
        public MainPage()
        {
            liveTileService = new LiveTileService();
            source = "ms-appx:///Assets/spider.jpg";
            this.InitializeComponent();
        }

        private void AddTile(object sender, RoutedEventArgs e)
        {
            //添加磁贴
            liveTileService.AddTile(MyTitle.Text, MyDetail.Text, source);
        }

        private async void ChangeImage(object sender, RoutedEventArgs e)
        {
            //选取图片
            FileOpenPicker openPicker = new FileOpenPicker();
            openPicker.FileTypeFilter.Add(".jpg");
            StorageFile file = await openPicker.PickSingleFileAsync();
            if (file != null)
            {
                //设置Image为选择的图片
                BitmapImage bitmap = new BitmapImage();
                using (var stream = await file.OpenAsync(Windows.Storage.FileAccessMode.Read))
                {
                    bitmap.SetSource(stream);
                }
                MyImage.Source = bitmap;

                //将图片保存在LocalFolder
                StorageFolder localFolder = ApplicationData.Current.LocalFolder;
                StorageFile fileCopy = await file.CopyAsync(localFolder, file.Name, NameCollisionOption.ReplaceExisting);
            }
            source = "ms-appdata:///local/" + file.Name;
        }
        
    }
}
