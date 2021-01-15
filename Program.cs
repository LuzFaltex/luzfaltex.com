using System;
using System.Threading.Tasks;
using Statiq.App;
using Statiq.Web;
using Statiq.Common;

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
                // settings[WebKeys.GitHubToken] = Config.FromSetting<string>(GitHubToken);
                settings[WebKeys.GitHubToken] = Environment.GetEnvironmentVariable(GitHubToken);
            })
            .RunAsync();
        }
    }
}
