using auto_code_reviewer_domain.Entities;
using auto_code_reviewer_infra.Interface;
using auto_code_reviwer_api.Interface;

namespace auto_code_reviwer_api.Services
{
    public class CodeReviewService : ICodeReviewService
    {
        private readonly IOpenAiRepository _openAiRepository;

        public CodeReviewService(IOpenAiRepository openAiRepository)
        {
            _openAiRepository = openAiRepository;
        }

        public async Task<string> GetCodeReview(PullRequestEntity pullRequestEntity)
        {

            var prompt = $" Você é um revisor de código experiente. Um Pull Request foi criado com as seguintes informações: Título: {pullRequestEntity.Title}  Descrição: {pullRequestEntity.Description}  Autor: {pullRequestEntity.Author}   Repositório: {pullRequestEntity.RepositoryName}  Branch: {pullRequestEntity.BranchName} A seguir estão as alterações realizadas em um ou mais arquivos de código. Para cada trecho de código alterado, identifique: Possíveis erros de código, Code smells ou padrões ruins, Erros de sintaxe ou lógica, Códigos duplicados ou desnecessários e Sugestão de refatoração (somente se necessário).";
            int countChangedFiles = pullRequestEntity.CodeBefore.Count();

            for(int i = 0; i < countChangedFiles; i++)
            {
                var codeBefore = pullRequestEntity.CodeBefore[i].Code;
                var codeAfter = pullRequestEntity.CodeAfter[i].Code;
                prompt += $"Arquivo: {pullRequestEntity.CodeBefore[i].FileName} Código antes da alteração: {codeBefore} Código após a alteração: {codeAfter} ";
            }
            

            return await _openAiRepository.AnalyzeCodeAsync(prompt);

        }
    }
}
