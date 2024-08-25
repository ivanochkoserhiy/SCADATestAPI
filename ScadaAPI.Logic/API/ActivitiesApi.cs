using System.Net;
using RestSharp;
using ScadaAPI.Logic.DataTransferObjects;

namespace ScadaAPI.Logic.API;

public class ActivitiesApi : BaseApi
{
    public IList<Activity> GetActivities() => ExecuteWithDeserialization<IList<Activity>>(Method.Get, "Activities", null, HttpStatusCode.OK);

    public Activity CreateActivity(Activity body) => ExecuteWithDeserialization<Activity>(Method.Post, "Activities", body, HttpStatusCode.OK);
    
    public Activity GetActivity(int id) => ExecuteWithDeserialization<Activity>(Method.Get, $"Activities/{id}", null, HttpStatusCode.OK);
    
    public Activity UpdateActivity(int id, Activity body) => ExecuteWithDeserialization<Activity>(Method.Put, $"Activities/{id}", body, HttpStatusCode.OK);
    
    public void DeleteActivity(int id) => ExecuteWithoutDeserialization(Method.Delete, $"Activities/{id}", null, HttpStatusCode.OK);
}