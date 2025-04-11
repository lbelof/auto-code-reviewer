namespace auto_code_reviewer_infra.Interface
{
    public interface IOpenAiRepository
    {
        Task<string> AnalyzeCodeAsync(string prompt);
    }
}
