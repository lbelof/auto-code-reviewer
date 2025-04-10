namespace auto_code_reviwer_api.Models
{
    public class PullRequestModel
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string Author { get; set; }
        public string RepositoryName { get; set; }
        public string BranchName { get; set; }
        public List<CodeModel> CodeBefore { get; set; } = new List<CodeModel>();
        public List<CodeModel> CodeAfter { get; set; } = new List<CodeModel>();
    }
}

