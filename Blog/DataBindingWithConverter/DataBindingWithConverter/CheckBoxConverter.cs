using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Data;

namespace DataBindingWithConverter
{
    /*
     * 转化器，将布尔值转化为Checkbox的IsChecked属性(System.Nullable`1[System.Boolean])
     */
    public class CheckBoxConverter : IValueConverter
    {
        /*
        * value为Item的Ischecked 属性，布尔值
        * targetType为Checkbox的Ischecked 属性的类型
        * parameter为转化时传递的参数
        * 通过value的值，返回一个targetType类型的值
        */
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            /*
             * bool? 表示isChecked可以取null
             * value as bool? 将value转化为布尔值然后返回，如果不能转化，则返回null
             */
            bool? isChecked = value as bool?;
            /*
             * 实际上这里返回的并不是targetType类型的值，而是布尔值
             * 但是在代码中返回值为Object，布尔值将被强制转化
             * 注意：在类型不能强制转化的情况下，应该根据targetType的类型返回返回需要的值
             */
            if (isChecked == null || isChecked == false)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        /*
         * 因为是单向绑定，所有并不需要管ConvertBack函数的内容
         * 如果使用了双向绑定，可以参考上面函数的写法添加ConvertBack函数的代码
         */
        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }
}
