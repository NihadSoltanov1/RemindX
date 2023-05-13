using RemindX.Domain.Enums;

namespace RemindX.UI.Models
{
    public class RemindUI
    {
        public int Id { get; set; }
        public string Receiver { get; set; }
        public string Content { get; set; }
        public DateTime RemindDate { get; set; }
        public Method MetodType { get; set; }
    }
}
