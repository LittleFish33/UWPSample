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

// https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x804 上介绍了“空白页”项模板

namespace MediaElementAndSlider
{

    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
        }

        // 开始播放
        private void playClick(object sender, RoutedEventArgs e)
        {
            mediaSimple.Play();
            EllStoryboard.Begin();
            progress.Maximum = mediaSimple.NaturalDuration.TimeSpan.TotalSeconds;
        }

        // 暂停播放
        private void pauseClick(object sender, RoutedEventArgs e)
        {
            mediaSimple.Pause();
            EllStoryboard.Pause();
        }

        // 停止播放，回到起始位置
        private void stopClick(object sender, RoutedEventArgs e)
        {
            mediaSimple.Stop();
            EllStoryboard.Stop();
        }

    }
}
