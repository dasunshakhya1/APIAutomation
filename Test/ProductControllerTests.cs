using Core.Endpoints.Product;
using Core.Endpoints.Product.models;
using Core.Utils;
using Core.Utils.models;

namespace Test
{
    public class ProductControllerTests
    {


        [Fact]
        public async Task Test_GetProducts_ReturnsAtLeastOneProduct()
        {
            string schemaJson = "products.schema.json";
            string productJson = "products.json";

            string expectedSchema = await FileReader.GetSchema(schemaJson);
            List<Product> expectedProduct = JsonParser.ParseJson<List<Product>>(await FileReader.GetJsonData(productJson));
          
            Response res = await ProductController.GetProducts();

            List<Product> actualProduct = JsonParser.ParseJson<List<Product>>(res.Content);

            bool isValidSchema = SchemaValidator.IsValidSchema(expectedSchema, res.Content);

            Assert.Equal(200, res.StatusCode);
            Assert.True(isValidSchema);
            Assert.Equal(expectedProduct, actualProduct);
        }


        [Fact]
        public async Task Test_GetProductById_ReturnsAProductByValidId() {

            string schemaJson = "product.schema.json";
            string productJson = "product.json";
            string productId = "7";

            string expectedSchema = await FileReader.GetSchema(schemaJson);
            Product expectedProduct = JsonParser.ParseJson<Product>(await FileReader.GetJsonData(productJson));

            Response res = await ProductController.GetProductById(productId);

            Product actualProduct = JsonParser.ParseJson<Product>(res.Content);

            bool isValidSchema = SchemaValidator.IsValidSchema(expectedSchema, res.Content);

            Assert.Equal(200, res.StatusCode);
            Assert.True(isValidSchema);
            Assert.Equal(expectedProduct, actualProduct);
        }
    }
}