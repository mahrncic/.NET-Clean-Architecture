using FluentValidation;
using LeaveManagement.Application.Contracts.Persistence;
using System;

namespace LeaveManagement.Application.DTOs.LeaveAllocation.Validators
{
    public class ILeaveAllocationDtoValidator : AbstractValidator<ILeaveAllocationDto>
    {
        public ILeaveAllocationDtoValidator(ILeaveTypeRepository leaveTypeRepository)
        {
            RuleFor(p => p.NumberOfDays)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .GreaterThan(0)
                .LessThan(100);

            RuleFor(p => p.Period)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .GreaterThanOrEqualTo(DateTime.Now.Year);

            RuleFor(p => p.LeaveTypeId)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .GreaterThan(0)
                .MustAsync(async (leaveTypeId, cancellation) =>
                {
                    var leaveTypeExists = await leaveTypeRepository.Exists(leaveTypeId);
                    return !leaveTypeExists;
                }).WithMessage("Invalid ID is provided for the Leave Type foreign key.");
        }
    }
}
