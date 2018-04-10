using System;
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

namespace SimpleDataBinding
{
    /// <summary>
    /// 可用于自身或导航至 Frame 内部的空白页。
    /// </summary>
    public sealed partial class MainPage : Page
    {
        //ObservableCollection表示一个动态数据集合，它可在添加、删除项目或刷新整个列表时提供通知
        //用于数据绑定的对象一般存放在ObservableCollection集合中
        public ObservableCollection<Item> Array = new ObservableCollection<Item>();

        public MainPage()
        {
            //往集合中添加对象
            Array.Add(new Item("This is the head line, with the pictur 0.png in Folder /Assets.", "Assets/0.png"));
            Array.Add(new Item("This is the first line, with the pictur 1.png in Folder /Assets.", "Assets/1.png"));
            Array.Add(new Item("This is the second line, with the pictur 2.png in Folder /Assets.", "Assets/2.png"));
            Array.Add(new Item("This is the third line, with the pictur 3.png in Folder /Assets.", "Assets/3.png"));
            Array.Add(new Item("This is the fourth line, with the pictur 4.png in Folder /Assets.", "Assets/4.png"));
            this.InitializeComponent();
        }
    }
}
