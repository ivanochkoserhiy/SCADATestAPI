namespace ScadaAPI.Logic.DataTransferObjects;

public class Activity
{
    public int Id { get; set; }
    
    public string Title { get; set; }
    
    public string DueDate { get; set; }
    
    public bool Completed { get; set; }
}