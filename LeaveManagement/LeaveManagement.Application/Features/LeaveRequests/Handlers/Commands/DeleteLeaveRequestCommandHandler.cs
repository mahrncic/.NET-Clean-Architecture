﻿using LeaveManagement.Application.Exceptions;
using LeaveManagement.Application.Features.LeaveRequests.Requests.Commands;
using LeaveManagement.Application.Contracts.Persistence;
using LeaveManagement.Domain;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace LeaveManagement.Application.Features.LeaveRequests.Handlers.Commands
{
    public class DeleteLeaveRequestCommandHandler : IRequestHandler<DeleteLeaveRequestCommand>
    {
        private readonly ILeaveRequestRepository _leaveRequestRepository;

        public DeleteLeaveRequestCommandHandler(ILeaveRequestRepository leaveRequestRepository)
        {
            _leaveRequestRepository = leaveRequestRepository;
        }

        public async Task<Unit> Handle(DeleteLeaveRequestCommand request, CancellationToken cancellationToken)
        {
            var leaveRequest = await _leaveRequestRepository.Get(request.Id);

            if (leaveRequest == null)
            {
                throw new NotFoundException(nameof(LeaveRequest), request.Id);
            }

            await _leaveRequestRepository.Delete(leaveRequest);
            
            return Unit.Value;
        }
    }
}
