using Newtonsoft.Json;

namespace Inventory.Website.Models
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