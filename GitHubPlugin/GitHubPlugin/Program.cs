using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibGit2Sharp;

namespace GitHubPlugin
{
    class Program
    {
        private static string source_localRepo = "C:/TestRepo";
        private static string target_remoteRepo = "C:/TestRepo2";

        static void Main(string[] args)
        {
            GitInit init = new GitInit(source_localRepo);
            init.InitializeRepo();

            string rootPath = Repository.Init(target_remoteRepo, true);
            if (rootPath.Contains(".git"))
                System.Console.WriteLine("Success");

            Console.ReadKey();

            string[] test = { "Test text line 1", "line 2" };
            System.IO.File.WriteAllLines(source_localRepo + "/testFile.txt", test);

            GitCommit committer = new GitCommit(source_localRepo, "Colton", "@awesome");
            committer.commitFiles(new List<string>() { "testFile.txt" }, "Test commit");

            Console.ReadKey();

            GitPush pusher = new GitPush(source_localRepo);
            pusher.push(source_localRepo, target_remoteRepo, "", "");

            Console.ReadKey();

            string[] testFile2 = { "This is a new test file to pull" };
            System.IO.File.WriteAllLines(target_remoteRepo + "/testFile.txt", test);

            GitPull puller = new GitPull(source_localRepo);
            puller.PullChanges("", "", source_localRepo, target_remoteRepo);

            Console.ReadKey();
        }
    }
}
