using Xunit;

using PaymentService.Application.DTOs;

namespace PaymentService.Tests.DTOs
{
    public class PaginatedResponseTests
    {
        [Fact]
        public void TotalPages_ShouldCalculateCorrectly()
        {

            var response = new PaginatedResponse<string>
            {
                TotalItems = 23,
                PageSize = 10
            };

            var totalPages = response.TotalPages;


            Assert.Equal(3, totalPages);
        }

        [Fact]
        public void Items_ShouldBeInitializedAsEmpty()
        {
            var response = new PaginatedResponse<int>();

            Assert.NotNull(response.Items);
            Assert.Empty(response.Items);
        }

        [Fact]
        public void Properties_ShouldStoreAndReturnCorrectValues()
        {
            // Arrange
            var items = new List<string> { "a", "b" };

            var response = new PaginatedResponse<string>
            {
                Items = items,
                TotalItems = 2,
                Page = 1,
                PageSize = 2
            };

            // Act & Assert
            Assert.Equal(items, response.Items);
            Assert.Equal(2, response.TotalItems);
            Assert.Equal(1, response.Page);
            Assert.Equal(2, response.PageSize);
            Assert.Equal(1, response.TotalPages);
        }
    }
}
