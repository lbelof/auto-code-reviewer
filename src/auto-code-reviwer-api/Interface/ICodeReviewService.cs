using auto_code_reviewer_domain.Entities;

namespace auto_code_reviwer_api.Interface
{
    public interface ICodeReviewService
    {
        Task<string> GetCodeReview(PullRequestEntity pullRequestEntity);
    }
}
