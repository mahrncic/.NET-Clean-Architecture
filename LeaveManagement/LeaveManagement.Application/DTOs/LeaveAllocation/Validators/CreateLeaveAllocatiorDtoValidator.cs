using FluentValidation;
using LeaveManagement.Application.Persistence.Contracts;

namespace LeaveManagement.Application.DTOs.LeaveAllocation.Validators
{
    public class CreateLeaveAllocatiorDtoValidator : AbstractValidator<CreateLeaveAllocationDto>
    {
        public CreateLeaveAllocatiorDtoValidator(ILeaveAllocationRepository leaveAllocationRepository)
        {
            RuleFor(p => p.NumberOfDays)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .GreaterThan(0)
                .LessThan(100);

            RuleFor(p => p.Period)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .GreaterThan(0)
                .LessThan(100);

            RuleFor(p => p.LeaveTypeId)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .GreaterThan(0)
                .MustAsync(async (leaveTypeId, cancellation) =>
                {
                    var leaveType = await leaveAllocationRepository.Get(leaveTypeId);
                    return leaveType != null;
                }).WithMessage("Invalid ID is provided for the Leave Type foreign key."); ;
        }
    }
}
