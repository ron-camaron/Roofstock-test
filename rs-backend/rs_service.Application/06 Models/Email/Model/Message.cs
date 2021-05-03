using System.Collections.ObjectModel;
using System.Net.Mail;

namespace rs_service.Application.Models.Email.Model
{
    public class Message
    {
        public string FromDisplayedName { get; set; }
        public string To { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }
        public Collection<AlternateView> AlternateViews { get; set; }
        public bool BodyHasHtml { get; set; }
    }
}
