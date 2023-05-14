using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RemindX.Application.Abstractions.Services
{
    public interface ISenderService
    {
        void RemindByEmail(string to, string content,DateTime remindDate);

        Task RemingByTelegram(string to, string content, DateTime remindDate);
        DateTime Time();
    }
}
