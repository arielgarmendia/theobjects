using Newtonsoft.Json;

namespace Products.Webapi.Creator.Model
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