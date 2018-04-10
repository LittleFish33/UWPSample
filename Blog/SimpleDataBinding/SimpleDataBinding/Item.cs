using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleDataBinding
{
    /*
     * Item是我们自定义的一个类型，其包含两个属性：content和source（内容和图片地址）
     */
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
