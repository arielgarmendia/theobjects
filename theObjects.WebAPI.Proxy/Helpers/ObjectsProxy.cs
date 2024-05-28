using theObjects.WebAPI.Proxy.ViewModels;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace theObjects.WebAPI.Proxy.Helpers
{
    internal static class ObjectsProxy<T>
    {
        private static string baseAddress = "http://localhost:29026/";

        #region Shapes
        internal static async Task<List<T>> GetAll()
        {
            try
            {
                HttpClient client = new HttpClient();
                HttpResponseMessage response = null;

                client.BaseAddress = new Uri(baseAddress);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

                var body = new StringContent(JsonConvert.SerializeObject(""), Encoding.UTF8, "application/json");
                var specificType = typeof(T);

                switch (specificType.Name)
                {
                    case "Point":
                        response = client.PostAsync("api/objects/getpoints", body).Result;
                        break;
                    case "Circle":
                        response = client.PostAsync("api/objects/getcircles", body).Result;
                        break;
                    case "Rectangle":
                        response = client.PostAsync("api/objects/getrectangles", body).Result;
                        break;
                    case "Square":
                        response = client.PostAsync("api/objects/getsquares", body).Result;
                        break;
                    case "Line":
                        response = client.PostAsync("api/objects/getlines", body).Result;
                        break;
                }

                if (response != null)
                {
                    var jsonString = await response.Content.ReadAsStringAsync();

                    return JsonConvert.DeserializeObject<List<T>>(jsonString);
                }

                return null;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        internal static async Task<T> Get(Guid ID)
        {
            try
            {
                HttpClient client = new HttpClient();
                HttpResponseMessage response = null;

                client.BaseAddress = new Uri(baseAddress);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

                var body = new StringContent(JsonConvert.SerializeObject(ID), Encoding.UTF8, "application/json");
                var specificType = typeof(T);

                switch (specificType.Name)
                {
                    case "Point":
                        response = client.PostAsync("api/objects/getpoint", body).Result;
                        break;
                    case "Circle":
                        response = client.PostAsync("api/objects/getcircle", body).Result;
                        break;
                    case "Rectangle":
                        response = client.PostAsync("api/objects/getrectangle", body).Result;
                        break;
                    case "Square":
                        response = client.PostAsync("api/objects/getsquare", body).Result;
                        break;
                    case "Line":
                        response = client.PostAsync("api/objects/getline", body).Result;
                        break;
                }

                if (response != null)
                {
                    var jsonString = await response.Content.ReadAsStringAsync();

                    return JsonConvert.DeserializeObject<T>(jsonString);
                }

                return default;
            }
            catch (Exception ex)
            {
                return default;
            }
        }

        internal static async Task<bool> Draw(Shape shape)
        {
            HttpClient client = new HttpClient();
            HttpResponseMessage response = null;

            client.BaseAddress = new Uri(baseAddress);
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

            var body = new StringContent(JsonConvert.SerializeObject(shape), Encoding.UTF8, "application/json");
            var specificType = typeof(T);

            switch (specificType.Name)
            {
                case "Point":
                    response = client.PostAsync("api/objects/drawpoint", body).Result;
                    break;
                case "Circle":
                    response = client.PostAsync("api/objects/drawcircle", body).Result;
                    break;
                case "Rectangle":
                    response = client.PostAsync("api/objects/drawrectangle", body).Result;
                    break;
                case "Square":
                    response = client.PostAsync("api/objects/drawsquare", body).Result;
                    break;
                case "Line":
                    response = client.PostAsync("api/objects/drawline", body).Result;
                    break;
            }

            if (response != null)
            {
                response.EnsureSuccessStatusCode();

                var ss = await response.Content.ReadAsStringAsync();

                return response.IsSuccessStatusCode;
            }
            else
                return false;
        }

        internal static async Task<bool> Move(Guid ID, int X, int Y)
        {
            HttpClient client = new HttpClient();
            HttpResponseMessage response = null;

            client.BaseAddress = new Uri(baseAddress);
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

            var body = new StringContent(JsonConvert.SerializeObject(new { id = ID, StartX = X, StartY = Y, EndX = 0, EndY = 0 }), Encoding.UTF8, "application/json");
            var specificType = typeof(T);

            switch (specificType.Name)
            {
                case "Point":
                    response = client.PostAsync("api/objects/movepoint", body).Result;
                    break;
                case "Circle":
                    response = client.PostAsync("api/objects/movecircle", body).Result;
                    break;
                case "Rectangle":
                    response = client.PostAsync("api/objects/moverectangle", body).Result;
                    break;
                case "Square":
                    response = client.PostAsync("api/objects/movesquare", body).Result;
                    break;
                case "Line":
                    response = client.PostAsync("api/objects/moveline", body).Result;
                    break;
            }

            if (response != null)
            {
                response.EnsureSuccessStatusCode();

                var ss = await response.Content.ReadAsStringAsync();

                return response.IsSuccessStatusCode;
            }
            else
                return false;
        }
        #endregion
    }
}
