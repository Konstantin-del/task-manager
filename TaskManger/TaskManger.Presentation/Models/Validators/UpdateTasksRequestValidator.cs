using FluentValidation;

namespace TaskManger.Presentation.Models.Validators;

public class UpdateTasksRequestValidator : AbstractValidator<UpdateTasksRequestModel>
{
    public UpdateTasksRequestValidator() 
    {
        RuleFor(x => x.Id).NotEmpty();
        RuleFor(x => x.CreatedBy).MinimumLength(2);
        RuleFor(x => x.Title).MinimumLength(2);
        RuleFor(x => x.Description).MinimumLength(10);
        RuleFor(x => x.Status).IsInEnum();
        RuleFor(x => x.Index).NotEmpty(); 
    }
}
