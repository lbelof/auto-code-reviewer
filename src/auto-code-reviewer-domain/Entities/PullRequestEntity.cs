namespace auto_code_reviewer_domain.Entities
{
    public record PullRequestEntity(
        string Title,
        string Description,
        string Author,
        string RepositoryName,
        string BranchName,
        List<CodeEntity> CodeBefore = null,
        List<CodeEntity> CodeAfter = null
    )
    {
        public List<CodeEntity> CodeBefore { get; init; } = CodeBefore ?? new List<CodeEntity>();
        public List<CodeEntity> CodeAfter { get; init; } = CodeAfter ?? new List<CodeEntity>();
    }
}
