using LeaveManagement.Application.Persistence.Contracts;
using LeaveManagement.Domain;

namespace Persistence.Repositories
{
    public class LeaveTypeRepository : GenericRepository<LeaveType>, ILeaveTypeRepository
    {
        public LeaveTypeRepository(LeaveManagementDbContext dbContext) : base(dbContext)
        {
        }
    }
}
