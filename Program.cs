using System;
using System.Threading.Tasks;
using System.Linq;
using Statiq.App;
using Statiq.Common;
using Statiq.Web;

namespace LuzFaltex.Web
{
    public class Program
    {
        public static async Task<int> Main(string[] args)
        {

            var bootstrapper = Bootstrapper
            .Factory
            .CreateWeb(args)
            .ConfigureSettings(settings =>
            {
                settings[Constants.Environment] = args.Contains("--development") || args.Contains("preview") ? Constants.Development : Constants.Production;
                settings[Keys.Host] = settings[Constants.Environment] is Constants.Development ? string.Empty : "www.luzfaltex.com";
            })
            .AddShortcode(Constants.EditLink, 
                (content, parameters, document, context) 
                => document[Constants.EditLink] as string ?? "https://github.com/LuzFaltex/luzfaltex.com");

            if (args.Contains("--development"))
            {
                bootstrapper.DeployToGitHubPagesBranch(
                    "LuzFaltex",
                    "luzfaltex.com",
                    Config.FromSetting<string>("GITHUB_TOKEN"),
                    "gh_pages"
                );
            }

            return await bootstrapper.RunAsync();
        }
    }
}
