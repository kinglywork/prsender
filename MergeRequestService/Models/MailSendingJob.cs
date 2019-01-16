using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MergeRequestService.Models
{
    public class MailSendingJob
    {
        public int Id { get; set; }
        public bool Active { get; set; }
        public DateTime NextExecuteTime { get; set; }
        public Recurring Recurring { get; set; }
        public DateTime LastExecuteTime { get; set; }
    }

    public enum Recurring
    {
        OneTime = 0,
        Daily = 1
    }
}
