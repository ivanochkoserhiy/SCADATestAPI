using FluentAssertions;
using ScadaAPI.Logic.API;

namespace ScadaAPITest.Tests;

public class ActivitiesTests
{
    private readonly ActivitiesApi _activitiesApi = new ();
    
    [Fact]
    public void GetActivitiesTest()
    {
        var activities = _activitiesApi.GetActivities();

        activities.Count.Should().Be(30);

        var yesterdayDate = DateTime.Now.AddDays(-1).Date;
        var activitiesForYesterday = activities.Where(x => Convert.ToDateTime(x.DueDate).Date == yesterdayDate); 
        
        activitiesForYesterday.Should().BeEmpty("Activities for yesterday should not be present");
    }
}