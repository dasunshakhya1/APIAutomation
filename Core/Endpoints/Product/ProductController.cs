using Core.Utils;
using Core.Utils.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Endpoints.Product
{
    public class ProductController
    {

        public static async Task<Response> GetProductsById(string productId)
        {
            string uri = $"/objects/{productId}";
            return await HttpClientImpl.HttpGet(uri);
        }
    }
}
