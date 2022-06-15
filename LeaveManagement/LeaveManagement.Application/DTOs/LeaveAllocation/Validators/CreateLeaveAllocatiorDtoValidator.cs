using FluentValidation;
using LeaveManagement.Application.Persistence.Contracts;

namespace LeaveManagement.Application.DTOs.LeaveAllocation.Validators
{
    public class CreateLeaveAllocatiorDtoValidator : AbstractValidator<CreateLeaveAllocationDto>
    {
        public CreateLeaveAllocatiorDtoValidator(ILeaveTypeRepository leaveTypeRepository)
        {
            Include(new ILeaveAllocationDtoValidator(leaveTypeRepository));
        }
    }
}
