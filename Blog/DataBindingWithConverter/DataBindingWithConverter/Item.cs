using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBindingWithConverter
{
    /*
     * Item是我们自定义的一个类型，包含三个属性，对应三个控件的属性
     * Source --> Image的Source
     * Ischecked --> Checkbox的checked
     * 这里继承了接口INotifyPropertyChanged，当Item某一属性值发生更改时，发出通知
     * 导致控件的属性也实时更改
     * 这里主要是为了测试转化器才这么使用的，可以暂时不用管INotifyPropertyChanged的作用
     */
    public class Item : INotifyPropertyChanged
    {
        private string _source;
        private bool _ischecked;

        public string Source
        {
            get => _source;
            set { _source = value; OnPropertyChanged("Source"); }
        }
        public bool Ischecked
        {
            get => _ischecked;
            set { _ischecked = value; OnPropertyChanged("Ischecked"); }
        }


        public Item(string source,bool ischecked)
        {
            this._source = source;
            this._ischecked = ischecked;
        }

        //显示实现接口，实现数据绑定动态更新
        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string propertyName = "")
        {
            PropertyChangedEventHandler handler = this.PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
