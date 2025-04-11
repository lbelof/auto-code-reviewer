using auto_code_reviewer_domain.Entities;
using auto_code_reviewer_infra.Interface;
using auto_code_reviewer_infra.Repository;
using auto_code_reviwer_api.Interface;
using auto_code_reviwer_api.Services;
using Scalar.AspNetCore;
var builder = WebApplication.CreateBuilder(args);

builder.Services.AddScoped<ICodeReviewService, CodeReviewService>();
//builder.Services.AddScoped<IOpenAiRepository, OpenAiRepository>();
builder.Services.AddHttpClient<IOpenAiRepository, OpenAiRepository>();



builder.Services.AddOpenApi();



var app = builder.Build();

if (app.Environment.IsDevelopment())
{   
    app.MapOpenApi();

    app.MapScalarApiReference();
}


app.MapPost("/v1/codereview", async (PullRequestEntity pullRequestEntity, ICodeReviewService codeReviewService) =>
{
    var result =await codeReviewService.GetCodeReview(pullRequestEntity);

    return Results.Ok(result);
});


app.Run();