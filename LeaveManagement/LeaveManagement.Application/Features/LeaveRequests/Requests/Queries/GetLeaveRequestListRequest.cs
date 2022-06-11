using LeaveManagement.Application.DTOs.LeaveRequest;
using MediatR;
using System.Collections.Generic;

namespace LeaveManagement.Application.Features.LeaveRequests.Requests.Queries
{
    public class GetLeaveRequestListRequest : IRequest<List<LeaveRequestListDto>>
    {
    }
}
