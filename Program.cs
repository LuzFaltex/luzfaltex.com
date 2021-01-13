using System.Threading.Tasks;
using Statiq.App;
using Statiq.Web;
using Statiq.Common;

namespace LuzFaltex.Web
{
    public class Program
    {
        public static async Task<int> Main(string[] args)
            => await Bootstrapper
            .Factory
            .CreateWeb(args)
            .DeployToGitHubPages(
                "LuzFaltex", 
                "www.luzfaltex.com", 
                Config.FromSetting<string>("GITHUB_TOKEN"))
            .RunAsync();
    }
}
