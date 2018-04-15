using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using Windows.UI.Xaml.Navigation;

// https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x804 上介绍了“空白页”项模板

namespace SQLiteSample
{
    /// <summary>
    /// 可用于自身或导航至 Frame 内部的空白页。
    /// </summary>
    public sealed partial class MainPage : Page
    {
        //allItems作为ListView的source
        private ObservableCollection<Item> allItems = new ObservableCollection<Item>();
        public ObservableCollection<Item> AllItems { get { return this.allItems; } }
        //数据库操作类
        private DBService itemDBService = DBService.GetInstance();
        //rightItem和右边添加/更新Item的界面控件双向绑定
        private Item rightItem = new Item(-1,"","");
        //selectItem用于在更新的时候指向需要更新的Item
        private Item selectItem;

        public MainPage()
        {
            itemDBService.Initialize(allItems);
            this.InitializeComponent();
            //如果你想要知道数据库文件保存在哪里，那么可以去掉下面的注释查看数据库文件的位置
            //StorageFolder localFolder = ApplicationData.Current.LocalFolder;
            //Debug.WriteLine(localFolder.Path);
        }

        //查找
        private void queryClick(object sender, RoutedEventArgs e)
        {
            itemDBService.queryItem(Query.Text);
        }

        //列表项被点击，此时处于更新Item的状态
        private void ItemClicked(object sender, ItemClickEventArgs e)
        {
            selectItem = (Item)(e.ClickedItem);
            rightItem.Title = selectItem.Title;
            rightItem.Detail = selectItem.Detail;
            MyButton.Content = "Update";
        }

        //更新Item或添加Item
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (MyButton.Content.Equals("Create"))
            {
                int id = itemDBService.CreateItem(rightItem);
                allItems.Add(new Item(id,rightItem.Title, rightItem.Detail));
            }
            else{
                itemDBService.UpdateItem(rightItem);
                selectItem.Title = rightItem.Title;
                selectItem.Detail = rightItem.Detail;
            }
            reset();
        }

        //取消按钮点击，重置
        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            reset();
        }

        //重置
        private void reset() {
            selectItem = null;
            rightItem.Title = "";
            rightItem.Detail = "";
            MyButton.Content = "Create";
        }

        private void DeleteClick(object sender, RoutedEventArgs e)
        {
            var frame = sender as FrameworkElement;
            Item item = (Item)frame.DataContext;
            itemDBService.DeleteItem(item.Id);
            allItems.Remove(item);
        }
    }
}
