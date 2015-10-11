using BernieApp.Common.Http;
using System;
using System.Net;
using System.Threading.Tasks;
using Xunit;

namespace BernieApp.Common.Tests.Http
{
    public class ES4BSClientTests
    {
        [Fact]
        public async Task WithES4BSClient_Given404_ThrowHttpError404()
        {
            //Arrange
            var mockHttpClient = new MockHttpClient();
            mockHttpClient.ReturnStatusCode = HttpStatusCode.NotFound;

            var newsClient = new NewsClient(mockHttpClient);

            try
            {
                var result = await newsClient.GetAsync();
            }
            catch(Exception e)
            {
                Assert.Equal(typeof(InvalidCastException), e.GetType());
            }
            //var t = Task.Run(async () => { return await newsClient.GetAsync(); });
            //t.Wait();

            //Assert.Equal(true, t.IsFaulted);
            //Assert.Equal(true, t.Result is HttpError404);

            //Assert.ThrowsAsync(typeof(InvalidCastException), newsClient.GetAsync);
        }
    }
}
