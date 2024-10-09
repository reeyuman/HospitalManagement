using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.BLL.Abstraction
{
    public interface IEmailSender
    {
        void send(string to, string subject, string message);   
    }
}
