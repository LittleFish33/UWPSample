﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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


namespace DataBindingWithConverter
{
    public sealed partial class MainPage : Page
    {
        //ObservableCollection表示一个动态数据集合，它可在添加、删除项目或刷新整个列表时提供通知
        //用于数据绑定的对象一般存放在ObservableCollection集合中
        public ObservableCollection<Item> Array = new ObservableCollection<Item>();

        public MainPage()
        {
            /*
             * 往集合中添加对象
             * Array[2]和Array[3]设置为unchecked，其他设置为checked
             */
            Array.Add(new Item("This is the head line, with the pictur 0.png(checked)", "Assets/0.png",true));
            Array.Add(new Item("This is the first line, with the pictur 1.png(checked)", "Assets/1.png",true));
            Array.Add(new Item("This is the second line, with the pictur 2.png(unchecked)", "Assets/2.png",false));
            Array.Add(new Item("This is the third line, with the pictur 3.png(unchecked)", "Assets/3.png",false));
            Array.Add(new Item("This is the fourth line, with the pictur 4.png(checked)", "Assets/4.png",true));
            this.InitializeComponent();
        }
    }
}
