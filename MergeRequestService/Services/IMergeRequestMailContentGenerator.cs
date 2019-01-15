using System.Collections.Generic;
using MergeRequestService.Models;

namespace MergeRequestService.Services
{
    public interface IMergeRequestMailContentGenerator
    {
        string Generate(List<MergeRequest> mergeRequests);
    }
}