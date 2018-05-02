using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Xml;
using Windows.Data.Json;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x804 上介绍了“空白页”项模板

namespace JsonAndXmlSample
{
    public sealed partial class MainPage : Page
    {
        // Url地址和app key
        private string trainStr = "http://apis.juhe.cn/train/s?dtype=xml&name=";
        private string weatherStr = "http://v.juhe.cn/weather/index?format=2&cityname=";
        private string trainKey = "&key=9ec62157b998149569d54ae25cbaa8e5";
        private string weatherKey = "&key=0e3c2dab2c8a77f4bac1138099a812ea";

        public MainPage()
        {
            this.InitializeComponent();
        }

        private async void queryWeather(object sender, RoutedEventArgs e)
        {
            // 获得json字符串和解析
            string url = weatherStr + cityBox.Text.Trim() + weatherKey;
            HttpClient httpClient = new HttpClient();
            var headers = httpClient.DefaultRequestHeaders;

            HttpResponseMessage response = await httpClient.GetAsync(url);

            response.EnsureSuccessStatusCode();
            Byte[] getByte = await response.Content.ReadAsByteArrayAsync();
            // 避免中文乱码
            Encoding code = Encoding.GetEncoding("UTF-8");
            string jsonString = code.GetString(getByte, 0, getByte.Length);

            // 解析Json对象
            JsonObject weatherObject = JsonObject.Parse(jsonString);
            if (weatherObject.GetNamedString("resultcode").Equals("200"))
            {
                JsonObject skObject = JsonObject.Parse(weatherObject.GetNamedValue("result").ToString());
                JsonObject todayObject = JsonObject.Parse(skObject.GetNamedValue("today").ToString());
                // 使用StringBuilder，可变字符串
                StringBuilder stringBuilder = new StringBuilder();
                stringBuilder.Append("气温 : " + todayObject.GetNamedString("temperature"));
                stringBuilder.Append("\n");
                stringBuilder.Append("天气 : " + todayObject.GetNamedString("weather"));
                stringBuilder.Append("\n");
                stringBuilder.Append("风向 : " + todayObject.GetNamedString("wind"));
                stringBuilder.Append("\n");
                MessageDialog showDialog = new Windows.UI.Popups.MessageDialog(stringBuilder.ToString());
                await showDialog.ShowAsync();
            }
            else
            {
                MessageDialog errorDialog = new Windows.UI.Popups.MessageDialog("输入错误！！！");
                await errorDialog.ShowAsync();
            }
        }


        private async void queryTrain(object sender, RoutedEventArgs e)
        {
            // 获得xml对象和解析
            string url = trainStr + trainBox.Text.Trim() + trainKey;
            HttpClient httpClient = new HttpClient();
            var headers = httpClient.DefaultRequestHeaders;

            HttpResponseMessage response = await httpClient.GetAsync(url);

            response.EnsureSuccessStatusCode();
            Byte[] getByte = await response.Content.ReadAsByteArrayAsync();

            Encoding code = Encoding.GetEncoding("UTF-8");
            string xmlString = code.GetString(getByte, 0, getByte.Length);

            // 解析xml对象
            XmlDocument doc = new XmlDocument();
            doc.LoadXml(xmlString);
            XmlNode root = doc.DocumentElement;
            if (doc.GetElementsByTagName("resultcode")[0].InnerText.Equals("200"))
            {
                XmlNodeList child = doc.GetElementsByTagName("train_info")[0].ChildNodes;

                StringBuilder stringBuilder = new StringBuilder();
                stringBuilder.Append("车次 : " + child[0].InnerText);
                stringBuilder.Append("\n");
                stringBuilder.Append("出发站 : " + child[1].InnerText);
                stringBuilder.Append("\n");
                stringBuilder.Append("到达站 : " + child[2].InnerText);
                stringBuilder.Append("\n");
                stringBuilder.Append("出发时间 : " + child[3].InnerText);
                stringBuilder.Append("\n");
                stringBuilder.Append("到达时间 : " + child[4].InnerText);
                stringBuilder.Append("\n");
                MessageDialog showDialog = new Windows.UI.Popups.MessageDialog(stringBuilder.ToString());
                await showDialog.ShowAsync();
            }
            else
            {
                MessageDialog errorDialog = new Windows.UI.Popups.MessageDialog("输入错误！！！");
                await errorDialog.ShowAsync();
            }

        }

    }
}
