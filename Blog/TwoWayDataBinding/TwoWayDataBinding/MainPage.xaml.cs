using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
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


namespace TwoWayDataBinding
{
    public sealed partial class MainPage : Page
    {
        //用于数据绑定的对象存放在ObservableCollection集合中
        public ObservableCollection<Item> Array = new ObservableCollection<Item>();

        public MainPage()
        {
            Array.Add(new Item("This is the head line, with the pictur 0.png(checked)", "Assets/0.png", true));
            Array.Add(new Item("This is the first line, with the pictur 1.png(checked)", "Assets/1.png", true));
            Array.Add(new Item("This is the second line, with the pictur 2.png(unchecked)", "Assets/2.png", false));
            Array.Add(new Item("This is the third line, with the pictur 3.png(unchecked)", "Assets/3.png", false));
            Array.Add(new Item("This is the fourth line, with the pictur 4.png(checked)", "Assets/4.png", true));
            this.InitializeComponent();
        }

        //点击添加按钮，将往Array中添加元素，此时我们可以看到ListView实时更新
        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            Array.Add(new Item("This is the line you add, with the pictur add.png(unchecked)", "Assets/add.jpg", false));
        }

        /*
         * 当ListView内的内容发生更改时，点击ShowButton，将触发该事件
         * 打印出Array的内容，此时我们可以看到Array的内容随着ListView的变化而变化
         */
        private void ShowButton_Click(object sender, RoutedEventArgs e)
        {
            foreach (var item in Array)
            {
                Debug.WriteLine(item.Content + " " + item.Ischecked);
            }
        }
    }
}
