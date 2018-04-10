using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/*
 * AdaptiveUIWithListView为你自己所使用的命名空间，这里选择和MainPage的命名空间一样
 * 需要注意的是，你也可以使用自己定义的命名空间
 * 但是因为MainPage.xaml.cs和MainPage.xaml里都使用了Item，所以需要添加using指令
 * 假如你的Item只用的命名空间为MyNamespace，那么首先需要在MainPage.xaml.cs里添加
 */
namespace AdaptiveUIWithListView
{
    public class Item
    {
        private string _content;
        private string _source;

        public string Content { get => _content; }
        public string Source { get => _source; }

        public Item(string content, string source)
        {
            this._content = content;
            this._source = source;
        }
    }
}
