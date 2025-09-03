using Core.Endpoints.Products;
using Core.Endpoints.Products.models;
using Core.Utils;
using Core.Utils.models;
using Test.Utils;

namespace Test
{
    public class ProductControllerTests
    {


        [Fact]
        public async Task Test_GetProducts_ReturnsAtLeastOneProduct()
        {
            string schemaJson = "get.products.schema.json";
            string productJson = "products.json";

            string expectedSchema = await FileReader.GetSchema(schemaJson);
            List<Product> expectedProduct = JsonParser.ParseJson<List<Product>>(await FileReader.GetJsonData(productJson));
          
            Response res = await ProductController.GetProducts();

            List<Product> actualProduct = JsonParser.ParseJson<List<Product>>(res.Content);

            bool isValidSchema = SchemaValidator.IsValidSchema(expectedSchema, res.Content);

            Assert.Equal(200, res.StatusCode);
            Assert.True(isValidSchema);
            Assert.True(actualProduct.Count() > 0);
            Assert.Equal(expectedProduct, actualProduct);
        }


        [Fact]
        public async Task Test_GetProductById_ReturnsAProductByValidId() {

            string schemaJson = "get.product.schema.json";
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


        [Fact]
        public async Task Test_GetProductById_ReturnsAnErrorForNonExistingId()
        {

            string schemaJson = "error.schema.json";
            string productJson = "error.json";
            string productId = "981";

            string expectedSchema = await FileReader.GetSchema(schemaJson);
            Product expectedProduct = JsonParser.ParseJson<Product>(await FileReader.GetJsonData(productJson));

            Response res = await ProductController.GetProductById(productId);

            Product actualProduct = JsonParser.ParseJson<Product>(res.Content);

            bool isValidSchema = SchemaValidator.IsValidSchema(expectedSchema, res.Content);

            Assert.Equal(404, res.StatusCode);
            Assert.True(isValidSchema);
            Assert.Equal(expectedProduct, actualProduct);
        }


        [Fact]
        public async Task Test_AddProduct_ReturnsCreatedProduct()
        {

            ProductData productData = new(2025,2200.25, "Intel Core i12","1 TB");
            Product product = new("Apple MacBook Pro 17", productData);


            string schemaJson = "add.product.schema.json";
         //   string productJson = "error.json";
        //    string productId = "981";

            string expectedSchema = await FileReader.GetSchema(schemaJson);
         //   Product expectedProduct = JsonParser.ParseJson<Product>(await FileReader.GetJsonData(productJson));

            Response res = await ProductController.AddProduct(product);
            Console.WriteLine(res.Content);

            Product actualProduct = JsonParser.ParseJson<Product>(res.Content);

            bool isValidSchema = SchemaValidator.IsValidSchema(expectedSchema, res.Content);

            Assert.Equal(200, res.StatusCode);
            Assert.True(isValidSchema);
         //   Assert.Equal(expectedProduct, actualProduct);
        }
    }
}