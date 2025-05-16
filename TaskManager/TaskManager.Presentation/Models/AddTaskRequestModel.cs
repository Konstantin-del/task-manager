namespace TaskManager.Presentation.Models;

public class AddTaskRequestModel
{
    public string CreatedBy { get; set; }

    public string Title { get; set; }

    public string Description { get; set; }

    public int Index { get; set; }
}
