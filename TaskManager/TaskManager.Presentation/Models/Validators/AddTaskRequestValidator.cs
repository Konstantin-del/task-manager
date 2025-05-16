using FluentValidation;

namespace TaskManager.Presentation.Models.Validators;

public class AddTaskRequestValidator : AbstractValidator<AddTaskRequestModel>
{
    public AddTaskRequestValidator()
    {
        RuleFor(x => x.CreatedBy).MinimumLength(2);
        RuleFor(x => x.Title).MinimumLength(2);
        RuleFor(x => x.Description).MinimumLength(2);
    }
}
