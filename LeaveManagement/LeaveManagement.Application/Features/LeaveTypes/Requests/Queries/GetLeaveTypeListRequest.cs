using LeaveManagement.Application.DTOs;
using MediatR;
using System.Collections.Generic;

namespace LeaveManagement.Application.Features.LeaveTypes.Requests.Queries
{
    public class GetLeaveTypeListRequest : IRequest<List<LeaveTypeDto>>
    {

    }
}
