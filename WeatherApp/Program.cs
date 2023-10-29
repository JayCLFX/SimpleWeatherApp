using Newtonsoft.Json.Linq;
using System;
using System.Diagnostics;
using System.Net;
using System.Threading;

namespace WeatherApp
{
    public class Program
    {
        static WebClient webClient = new WebClient();
        static string latitude = "";
        static string longitude = "";
        static string ApiKey = "";
        static string CityName = "";

        static void Main(string[] args)
        {
            State("");
        }

        static void State(string Answer)
        {
            Console.WriteLine("State youre Open-Meteo Api Key:");
            ApiKey = Console.ReadLine();
            Console.Clear();
            Console.WriteLine("Choose Mode:");
            Console.WriteLine("\n1. Longitude / Latitude");
            Console.WriteLine("\n2. City \n");
            Answer = Console.ReadLine();
            CheckInput(Answer);
        }

        static void CheckInput(string Input)
        {
            if (Input != "1" && Input != "2")
            {
                Debug.WriteLine(Input);
                Console.WriteLine("Wrong Answer Specified! \n Return");
                Thread.Sleep(5000);
                Console.Clear();
                State("");
            }

            if (Input == "1")
            {
                Console.Clear();
                Number1Mode();
            }

            if (Input == "2")
            {
                Console.Clear();
                Number2Mode();
            }
        }

        private static void Number1Mode()
        {
            latitude = "0";
            longitude = "0";
            Console.WriteLine("State Latitude: \n");
            latitude = Console.ReadLine();
            Console.WriteLine("\nState Longitude: \n");
            longitude = Console.ReadLine();
            Console.Clear();

            if (latitude != null && longitude != null)
            {
                try
                {
                    Console.WriteLine(
                        $"Country : {Manager.GetCountry()} \n" +
                        $"City Name : {Manager.GetCityname()} \n" +
                        $"Weather: {Manager.GetWeather()} \n" +
                        $"Description : {Manager.GetDescription()} \n" +
                        $"Temperature : {Manager.GetTemperature()} °C \n" +
                        $"Temperature Minimum : {Manager.GetTemperatureMin()} °C \n" +
                        $"Temperature Maximum : {Manager.GetTemperatureMax()} °C \n" +
                        $"Pressure : {Manager.GetPressure()} hpa \n" +
                        $"Humidity : {Manager.GetHumidity()} q \n" +
                        $"Visibility : {Manager.GetVisibility()} m \n" +
                        $"Wind Speed : {Manager.GetWindspeed()} km/h \n" +
                        $"Wind Direction : {Manager.GetWinddirection()} ° \n" +
                        $"Wind Gusts : {Manager.GetWindgusts()} km/h + \n" +
                        $"Sunrise : {Manager.GetSunrise()} UTC \n" +
                        $"Sunset : {Manager.GetSunset()} UTC \n" +
                        $"Latitude : {latitude} \n" +
                        $"Longitude : {longitude} \n"

                        );

                }
                catch (Exception ex)
                {
                    Debug.WriteLine(ex.ToString());
                }
                Console.ReadLine();
            }
        }

        private static void Number2Mode() 
        {
            Console.WriteLine("State City Name: \n");
            CityName = Console.ReadLine();
            Console.Clear();

            using (WebClient client = new WebClient())
            {
                try
                {
                    string json = webClient.DownloadString(Return2ndURL());
                    dynamic data = JObject.Parse(json);

                    var lat = data.results[0].latitude;
                    var lon = data.results[0].longitude;

                    if (lat != 0 && lon != 0)
                    {
                        latitude = lat;
                        longitude = lon;
                        string secjson = webClient.DownloadString(Return1stURL());
                        dynamic secdata = JObject.Parse(secjson);

                        Console.WriteLine(
                        $"Country : {Manager.GetCountry()} \n" +
                        $"City Name : {Manager.GetCityname()} \n" +
                        $"Weather: {Manager.GetWeather()} \n" +
                        $"Description : {Manager.GetDescription()} \n" +
                        $"Temperature : {Manager.GetTemperature()} °C \n" +
                        $"Temperature Minimum : {Manager.GetTemperatureMin()} °C \n" +
                        $"Temperature Maximum : {Manager.GetTemperatureMax()} °C \n" +
                        $"Pressure : {Manager.GetPressure()} hpa \n" +
                        $"Humidity : {Manager.GetHumidity()} q \n" +
                        $"Visibility : {Manager.GetVisibility()} m \n" +
                        $"Wind Speed : {Manager.GetWindspeed()} km/h \n" +
                        $"Wind Direction : {Manager.GetWinddirection()} ° \n" +
                        $"Wind Gusts : {Manager.GetWindgusts()} km/h + \n" +
                        $"Sunrise : {Manager.GetSunrise()} UTC \n" +
                        $"Sunset : {Manager.GetSunset()} UTC \n" +
                        $"Latitude : {lat} \n" + 
                        $"Longitude : {lon} \n"

                        );
                    }
                    Console.ReadLine();
                }
                catch (WebException ex)
                {
                    Debug.WriteLine(ex);
                }
            }
        }

        public static string Return1stURL()
        {
            string ApiURL = $"https://api.openweathermap.org/data/2.5/weather?lat={latitude}&lon={longitude}&appid={ApiKey}";
            return ApiURL;
        }

        public static string Return2ndURL()
        {
            string secondAPIUrl = $"https://geocoding-api.open-meteo.com/v1/search?name={CityName}&count=10&language=en&format=json";
            return secondAPIUrl;
        }
    }
}
