using System.Net;
using RestSharp;
using ScadaAPI.Logic.DataTransferObjects;

namespace ScadaAPI.Logic.API;

public class CoverPhotosApi : BaseApi
{
    public IList<CoverPhoto> GetCoverPhotos() => ExecuteWithDeserialization<IList<CoverPhoto>>(Method.Get, "CoverPhotos", null, HttpStatusCode.OK);

    public CoverPhoto CreateCoverPhoto(CoverPhoto body) => ExecuteWithDeserialization<CoverPhoto>(Method.Post, "CoverPhotos", body, HttpStatusCode.OK);
    
    public CoverPhoto GetCoverPhotoByBookId(int idBook) => ExecuteWithDeserialization<CoverPhoto>(Method.Get, $"CoverPhotos/books/covers/{idBook}", null, HttpStatusCode.OK);
    
    public CoverPhoto GetCoverPhoto(int id) => ExecuteWithDeserialization<CoverPhoto>(Method.Get, $"CoverPhotos/{id}", null, HttpStatusCode.OK);
    
    public CoverPhoto UpdateCoverPhoto(int id, CoverPhoto body) => ExecuteWithDeserialization<CoverPhoto>(Method.Put, $"CoverPhotos/{id}", body, HttpStatusCode.OK);
    
    public void DeleteCoverPhoto(int id) => ExecuteWithoutDeserialization(Method.Delete, $"CoverPhotos/{id}", null, HttpStatusCode.OK);
}