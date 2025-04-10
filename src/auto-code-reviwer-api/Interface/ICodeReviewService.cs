using auto_code_reviwer_api.Models;

namespace auto_code_reviwer_api.Interface
{
    public interface ICodeReviewService
    {
        Task<string> GetCodeReview(PullRequestModel pullRequestModel);
    }
}
