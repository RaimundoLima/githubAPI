using github.Domain.Interfaces;
using github.Domain.Mappers;
using github.Service;
using github.Service.GitHub;
using Octokit;

namespace githubAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddControllers();

            builder.Services.AddSingleton<IRepositoryService, RepositoryService>();
            builder.Services.AddSingleton<IBranchService, BranchService>();
            builder.Services.AddSingleton<IWebhookService, WebhookService>();
            builder.Services.AddSingleton<IGithubAPIService, GithubAPIService>();

            Credentials tokenAuth = new Credentials(builder.Configuration.GetSection("Token").Value);
            var githubClient = new GitHubClient(new ProductHeaderValue(builder.Configuration.GetSection("ProductHeaderValue").Value));
            githubClient.Credentials = tokenAuth;

            builder.Services.AddSingleton<IGitHubClient>(githubClient);

            builder.Services.AddAutoMapper(typeof(BranchMapper));
            builder.Services.AddAutoMapper(typeof(RepositoryMapper));
            builder.Services.AddAutoMapper(typeof(WebhookMapper));
            builder.Services.AddAutoMapper(typeof(GithubAPIMapper));

            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();


            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
}