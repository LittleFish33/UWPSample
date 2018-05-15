using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static ConsoleForNewtonsoft.Weather;

namespace ConsoleForNewtonsoft
{
    class Program
    {
        static Rootobject weather = null;

        // 将Json字符串解析为Json对象
        static void ToJsonObject(string str)
        {
            // 下面两句话就可以将Json字符串解析为Json对象，是不是很简单
            JsonSerializer json = JsonSerializer.Create();
            weather = json.Deserialize<Rootobject>(new JsonTextReader(new StringReader(str)));


            // 下面我们来测试一下输出
            Console.WriteLine("resultcode: " + weather.resultcode);
            Console.WriteLine("reason：" + weather.reason);
            Console.WriteLine("result.today.temperature：" + weather.result.today.temperature);
        }

        // 将Json对象解析为Json字符串
        private static void ToJsonString()
        {
            // 打开文件，下面替换为你要保存的文件路径
            FileStream file = new FileStream("C:\\Users\\HP\\Desktop\\output.txt", FileMode.OpenOrCreate);
            TextWriter stream = new StreamWriter(file);

            // 下面两句话就可以将Json对象解析为Json字符串
            var json = JsonSerializer.Create();
            json.Serialize(stream, weather);

            // 关闭文件流很重要，之前没有关闭流文件导致后面的数据莫名其妙地丢失了
            stream.Close();
            
        }

        static void Main(string[] args)
        {
            //打开文件，文件里存放在Json字符串，将下面的路径换为你要的文件路径
            FileStream file = new FileStream("C:\\Users\\HP\\Desktop\\weather.txt", FileMode.Open);
            StreamReader streamReader = new StreamReader(file);
            StringBuilder stringBuilder = new StringBuilder();
            String line = streamReader.ReadLine();

            //一行一行的读取weather.txt里的json字符串
            while (line != null)
            {
                stringBuilder.Append(line);
                line = streamReader.ReadLine();
            }

            streamReader.Close();
            file.Close();

            //测试我们的算法
            ToJsonObject(stringBuilder.ToString());
            ToJsonString();

        }

    }
}
