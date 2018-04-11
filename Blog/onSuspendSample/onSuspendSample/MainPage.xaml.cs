using System;
using System.Collections.Generic;
using System.Diagnostics;
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


namespace onSuspendSample
{
    public sealed partial class MainPage : Page
    {
        //source和Content用于保存Image控件的Source和文本框的内容
        private string source = "";
        private string content = "";
        //prefix为LocalFolder的使用前缀，可以查看另一篇博客了解相关内容
        private string prefix = "ms-appdata:///local/";

        public MainPage()
        {
            this.InitializeComponent();
        }

        //改变图片的按钮点击事件
        private async void ChangeImage(object sender, RoutedEventArgs e)
        {
            //挑选图片
            var openPicker = new Windows.Storage.Pickers.FileOpenPicker();
            openPicker.FileTypeFilter.Add(".jpg");
            StorageFile file = await openPicker.PickSingleFileAsync();

            //保存图片到LocalFolder，关于文件保存权限问题可以查看另一篇博客
            Windows.Storage.StorageFolder localFolder = Windows.Storage.ApplicationData.Current.LocalFolder;
            StorageFile fileCopy = await file.CopyAsync(localFolder, file.Name, NameCollisionOption.ReplaceExisting);
            BitmapImage bitmap = new BitmapImage();
            using (var stream = await fileCopy.OpenAsync(Windows.Storage.FileAccessMode.Read))
            {
                bitmap.SetSource(stream);
            }

            //source保存图片路径，挂起后重新打开将使用这个值进行还原
            source = prefix + file.Name;

            //设置图片控件的Image属性
            MyImage.Source = bitmap;
        }

        //进入MainPage时调用
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            //判断是第一次打开还是挂起后打开
            if (e.NavigationMode == NavigationMode.New)
            {
                ApplicationData.Current.LocalSettings.Values.Remove("MainPage");
            }
            else
            {
                if (ApplicationData.Current.LocalSettings.Values.ContainsKey("MainPage"))
                {
                    //还原值
                    ApplicationDataCompositeValue composite = ApplicationData.Current.LocalSettings.Values["MainPage"] as ApplicationDataCompositeValue;
                    source = composite["source"].ToString();
                    content = composite["content"].ToString();
                    ApplicationData.Current.LocalSettings.Values.Remove("MainPage");
                }
                //更新控件
                UpdateWidget();
            }
        }

        protected override void OnNavigatedFrom(NavigationEventArgs e)
        {
            /*
             * OnNavigatedFrom在离开MainPage是会被调用，有可能是跳转到其他的页面，也有可能是挂起
             * suspending判断是否为挂起
             */
            bool suspending = ((App)App.Current).isSuspend;
            if (suspending)
            {
                //如果是，将source，content的值保存下来，下次再打开的时候还原
                ApplicationDataCompositeValue composite = new ApplicationDataCompositeValue();
                composite["source"] = source;
                composite["content"] = MyTextBox.Text;
                ApplicationData.Current.LocalSettings.Values["MainPage"] = composite;
            }
        }

        //更新控件
        private async void UpdateWidget()
        {
            //根据路径获取图片
            var uri = new System.Uri(source);
            StorageFile file = await StorageFile.GetFileFromApplicationUriAsync(uri);
            BitmapImage bitmap = new BitmapImage();
            using (var stream = await file.OpenAsync(Windows.Storage.FileAccessMode.Read))
            {
                bitmap.SetSource(stream);
            }
            MyImage.Source = bitmap;
            MyTextBox.Text = content;
        }


    }
}
