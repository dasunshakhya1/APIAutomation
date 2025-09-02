using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Core.Endpoints.Product.models
{
    public class ProductData
    {
        [JsonPropertyName("year")]
        public int Year { get; set; }

        [JsonPropertyName("price")]
        public double Price { get; set; }

        [JsonPropertyName("CPU model")]
        public string CpuModel { get; set; }

        [JsonPropertyName("Hard disk size")]
        public string HardDiskSize { get; set; }
    }
}
