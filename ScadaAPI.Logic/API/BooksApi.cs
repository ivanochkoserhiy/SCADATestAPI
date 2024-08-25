using System.Net;
using RestSharp;
using ScadaAPI.Logic.DataTransferObjects;

namespace ScadaAPI.Logic.API;

public class BooksApi : BaseApi
{
    public IList<Book> GetBooks() => ExecuteWithDeserialization<IList<Book>>(Method.Get, "Books", null, HttpStatusCode.OK);

    public Book CreateBook(Book body) => ExecuteWithDeserialization<Book>(Method.Post, "Books", body, HttpStatusCode.OK);
    
    public Book GetBook(int id) => ExecuteWithDeserialization<Book>(Method.Get, $"Books/{id}", null, HttpStatusCode.OK);
    
    public Book UpdateBook(int id, Book body) => ExecuteWithDeserialization<Book>(Method.Put, $"Books/{id}", body, HttpStatusCode.OK);
    
    public void DeleteBook(int id) => ExecuteWithoutDeserialization(Method.Delete, $"Books/{id}", null, HttpStatusCode.OK);
}