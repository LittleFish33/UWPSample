using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Imaging;

namespace DataBindingWithConverter
{
    class ImageConverter : IValueConverter
    {
        //string转ImageSource（Image的Source属性）
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            string source = value as string;
            ImageSource imageSource = new BitmapImage(new Uri(source));
            return imageSource;
        }

        //Mode = Oneway，所以不用管ConvertBack的内容
        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }
}
