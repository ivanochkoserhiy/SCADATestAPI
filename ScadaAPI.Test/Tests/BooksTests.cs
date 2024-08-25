using FluentAssertions;
using ScadaAPI.Logic.API;
using ScadaAPI.Logic.DataTransferObjects;
using ScadaAPITest.TestData;

namespace ScadaAPITest.Tests;

public class BooksTests
{
    private readonly BooksApi _booksApi = new ();
    
    [Fact]
    public void UpdateBookTest()
    {
        var bookDto = new Book
        {
            Id = 1,
            Title = "C# via CLR",
            Description = """
                          Dig deep and master the intricacies of the common language runtime, C#, and .NET development. 
                          Led by programming expert Jeffrey Richter, a longtime consultant to the Microsoft .NET team -
                           you’ll gain pragmatic insights for building robust, reliable, and responsive apps and components.
                          """,
            PageCount = 100,
            Excerpt = "Jeffrey Richter",
            PublishDate = DateTime.UtcNow.ToString("yyyy-MM-ddTHH:mm:ss.ffffff"),
        };

        var updatedBookResponse = _booksApi.UpdateBook(1, bookDto);
        updatedBookResponse.Should().BeEquivalentTo(bookDto);
    }

    [Theory]
    [ClassData(typeof(BooksCountTestData))]
    public void VerifyBooksCount(int bookId, int expectedPagesCount)
    {
        var book = _booksApi.GetBook(bookId);
        book.PageCount.Should().Be(expectedPagesCount, $"Book with id '{book.Id}' and name '{book.Title}' has incorrect pages count.");
    }
}