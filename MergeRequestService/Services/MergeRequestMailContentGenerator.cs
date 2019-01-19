using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MergeRequestService.Models;
using Microsoft.Extensions.Configuration;

namespace MergeRequestService.Services
{
    public class MergeRequestMailContentGenerator : IMergeRequestMailContentGenerator
    {
        private readonly IMailContentTemplate _mailContentTemplate;

        public MergeRequestMailContentGenerator(IMailContentTemplate mailContentTemplate)
        {
            _mailContentTemplate = mailContentTemplate;
        }

        public string Generate(List<MergeRequest> mergeRequests)
        {
            var contentBuilder = new StringBuilder();

            AddQaChangeSets(contentBuilder, mergeRequests, TargetBranchListFactory.BranchQa);
            AddDevChangeSets(contentBuilder, mergeRequests, TargetBranchListFactory.BranchDev);

            return contentBuilder.ToString();
        }

        private void AddQaChangeSets(StringBuilder contentBuilder, List<MergeRequest> mergeRequests, string qaBranchName)
        {
            var requestsMergeToQa = RequestsMergeToTargetBranch(mergeRequests, qaBranchName);
            if (!requestsMergeToQa.Any())
            {
                return;
            }

            var qaChangeSets = from request in requestsMergeToQa
                group request by request.SourceBranch
                into qaGroup
                orderby qaGroup.Key
                select new
                {
                    SourceBranch = qaGroup.Key,
                    ChangeSets = string.Join(',', qaGroup.OrderBy(r => r.DevChangeSetId).Select(r => r.DevChangeSetId).Distinct())
                };

            contentBuilder.AppendLine(_mailContentTemplate.GenerateSectionTitle("DEV", "QA"));
            qaChangeSets.ToList()
                .ForEach(changeSetGroup => { contentBuilder.AppendLine(_mailContentTemplate.GenerateQaChangeSet(changeSetGroup.SourceBranch, changeSetGroup.ChangeSets)); });

            contentBuilder.Append(_mailContentTemplate.GenerateNewLine());
        }

        private void AddDevChangeSets(StringBuilder contentBuilder, List<MergeRequest> mergeRequests, string devBranchName)
        {
            var requestsMergeToDev = RequestsMergeToTargetBranch(mergeRequests, devBranchName);
            if (!requestsMergeToDev.Any())
            {
                return;
            }

            var devChangeSets = from request in requestsMergeToDev
                group request by request.SourceBranch
                into devGroup
                orderby devGroup.Key
                select new
                {
                    SourceBranch = devGroup.Key,
                    Requests = devGroup
                };

            devChangeSets.ToList()
                .ForEach(changeSetGroup =>
                {
                    contentBuilder.AppendLine(_mailContentTemplate.GenerateSectionTitle(changeSetGroup.SourceBranch, "DEV"));
                    changeSetGroup.Requests
                        .OrderBy(r => r.ChangeSetId)
                        .ToList().ForEach(request => { contentBuilder.AppendLine(_mailContentTemplate.GenerateDevChangeSet(request.ChangeSetId.ToString(), request.Memo)); });
                    contentBuilder.Append(_mailContentTemplate.GenerateNewLine());
                });
        }

        private static List<MergeRequest> RequestsMergeToTargetBranch(IEnumerable<MergeRequest> mergeRequests, string devBranchName)
        {
            return mergeRequests
                .Where(r => string.Equals(r.TargetBranch, devBranchName, StringComparison.InvariantCultureIgnoreCase))
                .ToList();
        }
    }
}