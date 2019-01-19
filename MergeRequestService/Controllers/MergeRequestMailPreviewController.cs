using System;
using System.Linq;
using MergeRequestService.Models;
using MergeRequestService.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;

namespace MergeRequestService.Controllers
{
    [Authorize] // todo admin only
    public class MergeRequestMailPreviewController : Controller
    {
        private readonly MergeRequestContext _context;
        private readonly IOptions<MailMessageConfig> _mailConfig;
        private readonly IMergeRequestMailContentGenerator _mergeRequestMailContentGenerator;

        private DateTime Now => DateTime.Now;

        public MergeRequestMailPreviewController(MergeRequestContext context,
            IOptions<MailMessageConfig> mailConfig,
            IMergeRequestMailContentGenerator mergeRequestMailContentGenerator)
        {
            _context = context;
            _mailConfig = mailConfig;
            _mergeRequestMailContentGenerator = mergeRequestMailContentGenerator;
        }

        public IActionResult Index()
        {
            var mergeRequests = _context.MergeRequests.Where(r => r.SubmitAt < Now.AddDays(1).Date && r.SubmitAt >= Now.Date).ToList();

            var mail = new MergeRequestMail
            {
                Receiver = _mailConfig.Value.Receiver,
                Cc = _mailConfig.Value.Cc,
                Subject = string.Format(_mailConfig.Value.SubjectTemplate, Now),
                Content = _mergeRequestMailContentGenerator.Generate(mergeRequests)
            };

            return View(mail);
        }
    }
}