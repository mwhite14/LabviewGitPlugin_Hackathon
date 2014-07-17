using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibGit2Sharp;

namespace GitHubPlugin
{
    public class GitPull
    {
        private Repository repo;

        public GitPull()
        { }

        public GitPull(string localRepoPath)
        {
            repo = new Repository(localRepoPath);
        }

        public string PullChanges(string username, string password, string repoPath, string remotePath)
        {
            PullOptions pullOps = new PullOptions();

            FetchOptions fetchOps = new FetchOptions();
            MergeOptions mergeOps = new MergeOptions();

            UsernamePasswordCredentials creds = new UsernamePasswordCredentials();
            creds.Username = username;
            creds.Password = password;

            fetchOps.Credentials = creds;


            pullOps.FetchOptions = fetchOps;
            pullOps.MergeOptions = mergeOps;

            var remote = repo.Network.Remotes["upstream"];
            if (remote == null)
            {
                repo.Network.Remotes.Add("upstream", remotePath);
                remote = repo.Network.Remotes["upstream"];
            }

            try
            {
                repo.Network.Fetch(repo.Network.Remotes["upstream"], fetchOps);

                MergeResult results = repo.Network.Pull(new Signature("","",DateTime.Now),pullOps);
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
