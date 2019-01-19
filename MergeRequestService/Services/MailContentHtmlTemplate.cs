using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MergeRequestService.Services
{
    public class MailContentHtmlTemplate : IMailContentTemplate
    {
        public string GenerateSectionTitle(string fromBranch, string toBranch)
        {
            return $"<div><strong><u>{fromBranch} -> {toBranch}:</u></strong></div>";
        }

        public string GenerateQaChangeSet(string sourceBranch, string devChangeSetIds)
        {
            return $"<div>{sourceBranch}: {devChangeSetIds}</div>";
        }

        public string GenerateDevChangeSet(string changeSetId, string memo)
        {
            return $"<div>{changeSetId} {memo}</div>";
        }

        public string GenerateNewLine()
        {
            return "<br>";
        }
    }
}