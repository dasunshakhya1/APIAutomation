using Core.Endpoints.Product;
using Core.Utils;
using Core.Utils.models;

namespace Test
{
    public class UnitTest1
    {
        [Fact]
        public async Task Test1Async()
        {
            Response res = await ProductController.GetProductsById("700");


            bool isValidSchema = SchemaValidator.isValidSchema(ResponseSchemas.productGetByIdSchema(), res.Content);
            Assert.NotNull(res);
            Assert.Equal(200, res.StatusCode);
            Assert.True(isValidSchema);
        }
    }
}