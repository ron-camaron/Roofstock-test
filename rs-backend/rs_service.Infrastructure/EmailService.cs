using rs_service.Application.Models.Email.Model;
using rs_service.Application.Interfaces;
using System.Threading.Tasks;
using System;

namespace rs_service.Infrastructure
{
    public class EmailService : IEmailService
    {
        public Task SendEmailAsync(Message message)
        {
            throw new NotImplementedException();
        }
    }
}
