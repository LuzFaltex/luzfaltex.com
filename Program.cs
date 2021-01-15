using System;
using System.Threading.Tasks;
using Statiq.App;
using Statiq.Web;
using Statiq.Common;

namespace LuzFaltex.Web
{
    public class Program
    {
        public const string GitHubOwner = "LuzFaltex";
        public const string GitHubName = "luzfaltex.github.io";
        public const string GitHubToken = "GITHUB_TOKEN";
        public static async Task<int> Main(string[] args)
        {
            /*
            var envVar = Environment.GetEnvironmentVariable(GitHubToken);
            var settingsVar = Config.FromSettings<string>(x => x.GetString(GitHubToken, string.Empty)).GetValueAsync();

            WriteLineColor($"{GitHubToken} (registry): {envVar}{Environment.NewLine}{GitHubToken} (settings): {settingsVar}", ConsoleColor.Red);
            */

            return await Bootstrapper
            .Factory
            .CreateWeb(args)
            .ConfigureSettings(config =>
            {
                config[WebKeys.GitHubOwner] = GitHubOwner;
                config[WebKeys.GitHubName] = GitHubName;
                config[WebKeys.GitHubToken] = Config.FromSetting<string>(GitHubToken);
            })
            .RunAsync();
        }

        private static void WriteLineColor(string message, ConsoleColor color)
        {
            var currentColor = Console.ForegroundColor;
            Console.ForegroundColor = color;
            Console.WriteLine(message);
            Console.ForegroundColor = currentColor;
        }
    }
}
