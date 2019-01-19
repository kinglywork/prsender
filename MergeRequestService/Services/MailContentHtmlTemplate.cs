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
            throw new NotImplementedException();
        }

        public string GenerateQaChangeSet(string sourceBranch, string devChangeSetIds)
        {
            throw new NotImplementedException();
        }

        public string GenerateDevChangeSet(string changeSetId, string memo)
        {
            throw new NotImplementedException();
        }

        public string GenerateNewLine()
        {
            throw new NotImplementedException();
        }
    }
}