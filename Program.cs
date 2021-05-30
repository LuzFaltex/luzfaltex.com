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
            return await Bootstrapper
            .Factory
            .CreateWeb(args)
            .ConfigureSettings(settings =>
            {
                settings[Keys.Host] = args.Contains("preview") ? string.Empty : "www.luzfaltex.com";
            })
            .AddShortcode(Constants.EditLink, 
                (content, parameters, document, context) 
                => document[Constants.EditLink] is string editLink ? editLink : "https://github.com/LuzFaltex/luzfaltex.github.io")
            .RunAsync();
        }
    }
}
