using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQLiteSample
{
    //继承INotifyPropertyChanged实现实时更新
    public class Item : INotifyPropertyChanged
    {
        private string _title;
        private string _detail;
        private int _id;

        public int Id { get => _id; set => _id = value; }
        public string Title
        {
            get => _title;
            set { _title = value; OnPropertyChanged("Title"); }
        }
        public string Detail
        {
            get => _detail;
            set { _detail = value; OnPropertyChanged("Detail"); }
        }

        public Item(int id,string title,string detail)
        {
            this._id = id;
            this._title = title;
            this._detail = detail;
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
