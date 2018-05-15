using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleForNewtonsoft
{
    class Weather
    {

        public class Rootobject
        {
            public string resultcode { get; set; }
            public string reason { get; set; }
            public Result result { get; set; }
            public int error_code { get; set; }
        }

        public class Result
        {
            public Sk sk { get; set; }
            public Today today { get; set; }
            public Future[] future { get; set; }
        }

        public class Sk
        {
            public string temp { get; set; }
            public string wind_direction { get; set; }
            public string wind_strength { get; set; }
            public string humidity { get; set; }
            public string time { get; set; }
        }

        public class Today
        {
            public string city { get; set; }
            public string date_y { get; set; }
            public string week { get; set; }
            public string temperature { get; set; }
            public string weather { get; set; }
            public Weather_Id weather_id { get; set; }
            public string wind { get; set; }
            public string dressing_index { get; set; }
            public string dressing_advice { get; set; }
            public string uv_index { get; set; }
            public string comfort_index { get; set; }
            public string wash_index { get; set; }
            public string travel_index { get; set; }
            public string exercise_index { get; set; }
            public string drying_index { get; set; }
        }

        public class Weather_Id
        {
            public string fa { get; set; }
            public string fb { get; set; }
        }

        public class Future
        {
            public string temperature { get; set; }
            public string weather { get; set; }
            public Weather_Id1 weather_id { get; set; }
            public string wind { get; set; }
            public string week { get; set; }
            public string date { get; set; }
        }

        public class Weather_Id1
        {
            public string fa { get; set; }
            public string fb { get; set; }
        }

    }
}
