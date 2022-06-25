using LeaveManagement.Application.Models;
using System.Threading.Tasks;

namespace LeaveManagement.Application.Contracts.Infrastructure
{
    public interface IEmailSender
    {
        Task<bool> SendEmail(Email email);
    }
}
