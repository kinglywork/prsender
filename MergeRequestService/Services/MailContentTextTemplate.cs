using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MergeRequestService.Services
{
    public class MailContentTextTemplate : IMailContentTemplate
    {
        public string GenerateSectionTitle(string fromBranch, string toBranch)
        {
            return $"{fromBranch} -> {toBranch}:";
        }

        public string GenerateQaChangeSet(string sourceBranch, string devChangeSetIds)
        {
            return $"{sourceBranch}: {devChangeSetIds}";
        }

        public string GenerateDevChangeSet(string changeSetId, string memo)
        {
            return $"{changeSetId} {memo}";
        }

        public string GenerateNewLine()
        {
            return Environment.NewLine;
        }
    }
}