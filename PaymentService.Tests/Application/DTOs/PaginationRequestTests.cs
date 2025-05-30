using Xunit;
using PaymentService.Application.DTOs;

namespace PaymentService.Tests.DTOs
{
    public class PaginationRequestTests
    {
        [Fact]
        public void Constructor_ShouldSetDefaultValues()
        {
            var request = new PaginationRequest();

            Assert.Equal(1, request.Page);
            Assert.Equal(10, request.PageSize);
        }

        [Fact]
        public void Properties_ShouldStoreAndReturnCorrectValues()
        {
            var request = new PaginationRequest
            {
                Page = 3,
                PageSize = 50
            };

            Assert.Equal(3, request.Page);
            Assert.Equal(50, request.PageSize);
        }
    }
}
