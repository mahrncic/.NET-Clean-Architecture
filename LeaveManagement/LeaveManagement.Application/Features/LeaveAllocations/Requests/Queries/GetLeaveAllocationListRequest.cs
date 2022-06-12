using LeaveManagement.Application.DTOs.LeaveAllocation;
using MediatR;
using System.Collections.Generic;

namespace LeaveManagement.Application.Features.LeaveAllocations.Requests.Queries
{
    public class GetLeaveAllocationListRequest : IRequest<List<LeaveAllocationDto>>
    {
    }
}
