using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Data;

namespace TwoWayDataBinding
{
    /*
     * 转化器，将布尔值转化为Checkbox的IsChecked属性
     */
    public class CheckBoxConverter : IValueConverter
    {
        //如果对转化器还不了解，可以查看上一篇博客：http://littlefish33.cn/uwp/DataBindingWithConverter/
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            bool? isChecked = value as bool?;
            if (isChecked == null || isChecked == false)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            bool? isChecked = value as bool?;
            if (isChecked == null || isChecked == false)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}
