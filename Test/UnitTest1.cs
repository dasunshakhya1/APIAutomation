using Core.models;
using Core.Utils;

namespace Test
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {
         HttpClientImpl.HttpGet("/objects");
        }
    }
}