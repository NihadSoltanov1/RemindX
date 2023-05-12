using RemindX.Domain.Entities.Common;
using RemindX.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RemindX.Domain.Entities
{
    public class Remind : BaseEntity
    {
        public string  Receiver { get; set; }
        public string Content { get; set; }
        public DateTime RemindDate { get; set; }
        public Method MetodType { get; set; }

    }
}
