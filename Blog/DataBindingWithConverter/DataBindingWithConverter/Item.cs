using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBindingWithConverter
{
    /*
     * Item是我们自定义的一个类型，包含三个属性，对应三个控件的属性
     * Content --> 文本框的内容
     * Source --> Image的Source
     * Ischecked --> Checkbox的checked
     */
    public class Item
    {
        private string _content;
        private string _source;
        private bool _ischecked;

        public string Content { get => _content; }
        public string Source { get => _source; }
        public bool Ischecked { get => _ischecked; }

        public Item(string content, string source,bool ischecked)
        {
            this._content = content;
            this._source = source;
            this._ischecked = ischecked;
        }
    }
}
