using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibGit2Sharp;

namespace GitHubPlugin
{
    class GitPull
    {
        private Repository repo;

        public GitPull()
        { }

        public GitPull(string localRepoPath)
        {
            repo = new Repository(localRepoPath);
        }

        public string PullChanges()
        {
            PullOptions pullOps = new PullOptions();

            FetchOptions fetchOps = new FetchOptions();
            MergeOptions mergeOps = new MergeOptions();

            UsernamePasswordCredentials creds = new UsernamePasswordCredentials();
            creds.Username = "coltonhurt@live.com";
            creds.Password = "Irithos11!";

            fetchOps.Credentials = creds;


            pullOps.FetchOptions = fetchOps;
            pullOps.MergeOptions = mergeOps;

            try
            {
                repo.Network.Fetch(repo.Network.Remotes["origin"], fetchOps, new Signature("colon", "email", DateTime.Now), "Fetched crap");

                MergeResult results = repo.Network.Pull(new Signature("colon", "email", DateTime.Now), pullOps);
                Console.WriteLine(results.Status.ToString());
            }
            catch (Exception e)
            {
                return "Message: " + e.Message + " Cause: " + e.InnerException + " Error#" + e.HResult;
            }

            return null;
        }
    }
}
