﻿using LeaveManagement.Application.Exceptions;
using LeaveManagement.Application.Features.LeaveAllocations.Requests.Commands;
using LeaveManagement.Application.Contracts.Persistence;
using LeaveManagement.Domain;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace LeaveManagement.Application.Features.LeaveAllocations.Handlers.Commands
{
    public class DeleteLeaveAllocationCommandHandler : IRequestHandler<DeleteLeaveAllocationCommand>
    {
        private readonly ILeaveAllocationRepository _leaveAllocationRepository;

        public DeleteLeaveAllocationCommandHandler(ILeaveAllocationRepository leaveAllocationRepository)
        {
            _leaveAllocationRepository = leaveAllocationRepository;
        }


        public async Task<Unit> Handle(DeleteLeaveAllocationCommand request, CancellationToken cancellationToken)
        {
            var leaveAllocation = await _leaveAllocationRepository.Get(request.Id);

            if (leaveAllocation == null)
            {
                throw new NotFoundException(nameof(LeaveAllocation), request.Id);
            }

            await _leaveAllocationRepository.Delete(leaveAllocation);

            return Unit.Value;
        }
    }
}
