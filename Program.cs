using System;
using System.Threading.Tasks;
using Statiq.App;
using Statiq.Common;
using Statiq.Markdown;
using Statiq.Web;

namespace LuzFaltex.Web
{
    public class Program
    {
        public const string GitHubToken = "GITHUB_TOKEN";
        public static async Task<int> Main(string[] args)
        {
            return await Bootstrapper
            .Factory
            .CreateWeb(args)
            .ConfigureSettings(settings =>
            {
                settings[WebKeys.GitHubToken] = Config.FromSetting<string>(GitHubToken);
                // settings[WebKeys.GitHubToken] = Environment.GetEnvironmentVariable(GitHubToken);
            })
            .AddShortcode(Constants.EditLink, (content, parameters, document, context) => document[Constants.EditLink] is string editLink ? editLink : "https://github.com/LuzFaltex/luzfaltex.github.io")
            .RunAsync();
        }
    }
}
