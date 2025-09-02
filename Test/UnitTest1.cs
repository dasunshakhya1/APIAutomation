using Core.Configs;
using Core.Endpoints.Product;
using Core.Endpoints.Product.models;
using Core.Utils;
using Core.Utils.models;

namespace Test
{
    public class UnitTest1
    {
        [Fact]
        public async Task Test1Async()
        {

            string expectedSchema = await FileReader.GetSchema("product.schema.json");
            Product expectedProduct = JsonParser.ParseJson<Product>(await FileReader.GetJsonData("product.json"));
          
            Response res = await ProductController.GetProductsById("7");

            Product actualProduct = JsonParser.ParseJson<Product>(res.Content);

            bool isValidSchema = SchemaValidator.isValidSchema(expectedSchema, res.Content);
            Assert.NotNull(res);
            Assert.Equal(200, res.StatusCode);
            Assert.True(isValidSchema);
            Assert.Equal(expectedProduct, actualProduct);
        }
    }
}