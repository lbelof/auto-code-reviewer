using auto_code_reviwer_api.Interface;
using auto_code_reviwer_api.Models;
using auto_code_reviwer_api.Services;
using Scalar.AspNetCore;
var builder = WebApplication.CreateBuilder(args);

builder.Services.AddScoped<ICodeReviewService, CodeReviewService>();
builder.Services.AddOpenApi();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{   
    app.MapOpenApi();

    app.MapScalarApiReference();
}


app.MapPost("/", (PullRequestModel pullRequestModel, ICodeReviewService codeReviewService) =>
{
    var result = codeReviewService.GetCodeReview(pullRequestModel);

    return Results.Ok(result);
});


app.Run();