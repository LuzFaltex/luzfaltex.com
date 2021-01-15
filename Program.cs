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
            var envVar = Environment.GetEnvironmentVariable(GitHubToken);
            var settingsVar = Config.FromSettings<string>(x => x.GetString(GitHubToken, string.Empty));

            WriteLineColor($"{GitHubToken} (registry): {envVar}{Environment.NewLine}{GitHubToken} (settings): {settingsVar}", ConsoleColor.Red);

            return await Bootstrapper
            .Factory
            .CreateWeb(args)
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
