using rs_service.Application.Models.Email.Model;
using System.Threading.Tasks;

namespace rs_service.Application.Interfaces
{
    public interface IEmailService
    {
        Task SendEmailAsync(Message message);
    }
}
