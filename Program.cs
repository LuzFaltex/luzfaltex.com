using System.Threading.Tasks;
using Octokit;
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
            .RunAsync();
    }
}
