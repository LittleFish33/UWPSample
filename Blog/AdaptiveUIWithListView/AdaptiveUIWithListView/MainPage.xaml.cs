using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Reflection;
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

namespace AdaptiveUIWithListView
{
    /// <summary>
    /// 可用于自身或导航至 Frame 内部的空白页。
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public ObservableCollection<Item> Array = new ObservableCollection<Item>();
        public MainPage()
        {
            Array.Add(new Item("This is the head line, with the pictur 0.png in Folder /Assets.", "Assets/0.png"));
            Array.Add(new Item("This is the first line, with the pictur 1.png in Folder /Assets.", "Assets/1.png"));
            Array.Add(new Item("This is the second line, with the pictur 2.png in Folder /Assets.", "Assets/2.png"));
            Array.Add(new Item("This is the third line, with the pictur 3.png in Folder /Assets.", "Assets/3.png"));
            Array.Add(new Item("This is the fourth line, with the pictur 4.png in Folder /Assets.", "Assets/4.png"));
            this.InitializeComponent();

            this.SizeChanged += (s, e) =>
            {
                if (e.NewSize.Width > 000 && e.NewSize.Width < 600)
                {
                    ShowImage(false);
                }
                else
                {
                    ShowImage(true);
                }
            };
        }

        //flag决定图片是否显示
        private void ShowImage(bool flag)
        {
            /*
             * FindChildren是一个自定义的函数，接受两个参数，一个是List<T>，另一个是窗口的一个控件
             * FindChildren运行结束后，将找到该控件的所有子控件中类型为T的控件
             * 下面的例子即找到MyList控件中所有类型为RelativePanel的控件
             */
            List<RelativePanel> list = new List<RelativePanel>();
            FindChildren<RelativePanel>(list, MyList);

            foreach (RelativePanel panel in list)
            {
                for (int i = 0; i < panel.Children.Count; i++)
                {
                    //如果为图片，则判断是否显示
                    if (panel.Children[i] is Image)
                    {
                        if (flag)
                        {
                            ((Image)panel.Children[i]).Visibility = Visibility.Visible;
                        }
                        else
                        {
                            ((Image)panel.Children[i]).Visibility = Visibility.Collapsed;
                        }
                    }
                    //这里的Grid即xaml中的Space
                    if (panel.Children[i] is Grid)
                    {
                        if (flag)
                        {
                            ((Grid)panel.Children[i]).Width = 90;
                        }
                        else
                        {
                            ((Grid)panel.Children[i]).Width = 40;
                        }
                    }
                }
            }
        }

        //遍历startNode的子节点，找到类型为T的控件并且放在results中
        internal static void FindChildren<T>(List<T> results, DependencyObject startNode)
             where T : DependencyObject
        {
            int count = VisualTreeHelper.GetChildrenCount(startNode);
            for (int i = 0; i < count; i++)
            {
                DependencyObject current = VisualTreeHelper.GetChild(startNode, i);
                if ((current.GetType()).Equals(typeof(T)) || (current.GetType().GetTypeInfo().IsSubclassOf(typeof(T))))
                {
                    T asType = (T)current;
                    results.Add(asType);
                }
                FindChildren<T>(results, current);
            }
        }
    }
}
