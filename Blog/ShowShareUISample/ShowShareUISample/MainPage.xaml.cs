using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.ApplicationModel.DataTransfer;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Storage.Streams;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;


namespace ShowShareUISample
{
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
            //使ShareRequested函数在共享操作时发生
            DataTransferManager.GetForCurrentView().DataRequested += ShareRequested;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //启动共享
            DataTransferManager.ShowShareUI();
        }

        //设置想要共享的内容
        private void ShareRequested(DataTransferManager sender, DataRequestedEventArgs args)
        {
            var deferral = args.Request.GetDeferral();
            DataRequest request = args.Request;
            request.Data.Properties.Title = "ShareUISample";
            request.Data.SetText("Description：" + "This is a line from ShareUISample. Welcome to learn UWP.");
            request.Data.SetBitmap(RandomAccessStreamReference.CreateFromUri(new Uri("ms-appx:///Assets/flash.jpg")));
            deferral.Complete();
        }
    }
}
