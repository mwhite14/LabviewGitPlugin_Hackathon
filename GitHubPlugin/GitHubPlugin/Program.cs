using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GitHubPlugin
{
    class Program
    {
        private static string localRepo = "C:/Users/colto_000/Documents/GitHubPluginProj/Proj";

        static void Main(string[] args)
        {
            GitPull pull = new GitPull(localRepo);
            string test = pull.PullChanges();

            Console.Write(test);
            Console.ReadKey();
        }
    }
}
