using FluentAssertions;
using ScadaAPI.Logic.API;
using ScadaAPI.Logic.DataTransferObjects;

namespace ScadaAPITest.Tests;

[Collection("SequentialTests")]
public class AuthorsTest
{
    private readonly AuthorsApi _authorsApi = new ();
    
    [Fact]
    public void CreateAuthorTest()
    {
        var authorDto = new Author
        {
            Id = 123,
            IdBook = 234,
            FirstName = "Tim",
            LastName = "Cook",
        };

        var authorResponse = _authorsApi.CreateAuthor(authorDto);
        authorResponse.Should().BeEquivalentTo(authorDto);
    }

    [Fact]
    public void DeleteAuthorTest()
    {
        _authorsApi.DeleteAuthor(123);
    }
}