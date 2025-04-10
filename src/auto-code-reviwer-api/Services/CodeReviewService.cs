using auto_code_reviwer_api.Interface;
using auto_code_reviwer_api.Models;

namespace auto_code_reviwer_api.Services
{
    public class CodeReviewService : ICodeReviewService
    {
        public CodeReviewService()
        {
        }

        public async Task<string> GetCodeReview(PullRequestModel pullRequestModel)
        {
            // Simulate a delay for the async method
            await Task.Delay(1000);
            return "Code review result";
        }
    }
}
