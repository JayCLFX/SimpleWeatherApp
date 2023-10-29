using Newtonsoft.Json.Linq;
using System;
using System.Diagnostics;
using System.Net;

namespace WeatherApp
{
    static class Manager
    {
        static WebClient webClient = new WebClient();
        public static string json = webClient.DownloadString(Program.Return1stURL());
        public static dynamic data = JObject.Parse(json);

        public static int GetSunset()
        {
            try
            {
                int Sunset = data.sys.sunset;
                return Sunset;
            }
            catch (Exception e)
            {
                Debug.WriteLine(e);
                return 0;
            }
        }

        public static int GetSunrise()
        {
            try
            {
                int Sunrise = data.sys.sunrise;
                return Sunrise;
            }
            catch (Exception e)
            {
                Debug.WriteLine(e);
                return 0;
            }
        }

        public static string GetCityname()
        {
            try
            {
                var CityName = data.name;
                return CityName;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
                return "Error";
            }
        }

        public static string GetCountry()
        {
            try
            {
                var Country = data.sys.country;
                return Country;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
                return "Error";
            }
        }

        public static string GetWindgusts()
        {
            try
            {
                var WindGusts = data.wind.gust;
                return WindGusts;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
                return "Error";
            }
        }

        public static string GetWinddirection()
        {
            try
            {
                var WindDirection = data.wind.deg;
                return WindDirection;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
                return "Error";
            }
        }

        public static string GetWindspeed()
        {
            try
            {
                var WindSpeed = data.wind.speed;
                return WindSpeed;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
                return "Error";
            }
        }

        public static string GetVisibility()
        {
            try
            {
                var visibility = data.visibility;
                return visibility;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
                return "Error";
            }
        }

        public static string GetHumidity()
        {
            try
            {
                var Humidity = data.main.humidity;
                return Humidity;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
                return "Error";
            }
        }

        public static string GetPressure()
        {
            try
            {
                var Pressure = data.main.pressure;
                return Pressure;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
                return "Error";
            }
        }

        public static int GetTemperatureMax()
        {
            try
            {
                int Temperature_Max = data.main.temp_max - 273;
                return Temperature_Max;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
                return 0;
            }
        }

        public static int GetTemperatureMin()
        {
            try
            {
                int Temperature_Min = data.main.temp_min - 273;
                return Temperature_Min;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
                return 0;
            }
        }

        public static int GetTemperature()
        {
            try
            {
                int Temperature = data.main.temp - 273;
                return Temperature;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
                return 0;
            }
        }

        public static string GetDescription()
        {
            try
            {
                var Description = data.weather[0].description;
                return Description;
            }
            catch (Exception e)
            {
                Debug.WriteLine(e);
                return "Error";
            }
        }

        public static string GetWeather()
        {
            try
            {
                var Weather = data.weather[0].main;
                return Weather;
            }
            catch (Exception e)
            {
                Debug.WriteLine(e);
                return "Error";
            }
        }
    }
}
