using Newtonsoft.Json;

namespace theObjects.WebAPI.Proxy.ViewModels
{
    public class BaseProduct
    {
        [JsonIgnore]
        public string database_file = "";

        public BaseProduct()
        {
        }
    }
}