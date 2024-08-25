using System.Net;
using RestSharp;
using ScadaAPI.Logic.DataTransferObjects;

namespace ScadaAPI.Logic.API;

public class AuthorsApi : BaseApi
{
    public IList<Author> GetAuthors() => ExecuteWithDeserialization<IList<Author>>(Method.Get, "Authors", null, HttpStatusCode.OK);

    public Author CreateAuthor(Author body) => ExecuteWithDeserialization<Author>(Method.Post, "Authors", body, HttpStatusCode.OK);
    
    public Author GetAuthorByBookId(int idBook) => ExecuteWithDeserialization<Author>(Method.Get, $"Authors/authors/books/{idBook}", null, HttpStatusCode.OK);
    
    public Author GetAuthor(int id) => ExecuteWithDeserialization<Author>(Method.Get, $"Authors/{id}", null, HttpStatusCode.OK);
    
    public Author UpdateAuthor(int id, Author body) => ExecuteWithDeserialization<Author>(Method.Put, $"Authors/{id}", body, HttpStatusCode.OK);
    
    public void DeleteAuthor(int id) => ExecuteWithoutDeserialization(Method.Delete, $"Authors/{id}", null, HttpStatusCode.OK);
}