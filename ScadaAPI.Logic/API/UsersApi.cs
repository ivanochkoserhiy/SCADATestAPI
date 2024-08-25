using System.Net;
using RestSharp;
using ScadaAPI.Logic.DataTransferObjects;

namespace ScadaAPI.Logic.API;

public class UsersApi : BaseApi
{
    public IList<User> GetUsers() => ExecuteWithDeserialization<IList<User>>(Method.Get, "Users", null, HttpStatusCode.OK);

    public User CreateUser(User body) => ExecuteWithDeserialization<User>(Method.Post, "Users", body, HttpStatusCode.OK);
    
    public User GetUser(int id) => ExecuteWithDeserialization<User>(Method.Get, $"Users/{id}", null, HttpStatusCode.OK);
    
    public User UpdateUser(int id, User body) => ExecuteWithDeserialization<User>(Method.Put, $"Users/{id}", body, HttpStatusCode.OK);
    
    public void DeleteUser(int id) => ExecuteWithoutDeserialization(Method.Delete, $"Users/{id}", null, HttpStatusCode.OK);
}