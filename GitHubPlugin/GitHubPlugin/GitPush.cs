using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibGit2Sharp;

namespace GitHubPlugin
{
    public class GitPush
    {
        private Repository repo;
        private Remote remote;

        public GitPush(string localRepoPath) 
        { 
            repo = new Repository(localRepoPath);
            remote = repo.Network.Remotes["origin"];
        }
        /// <summary>
        /// pushes current repo
        /// </summary>
        /// <param name="username">Git username</param>
        /// <param name="pw">Git pw</param>
        /// <returns>string if error, else null</returns>
        public string push(string repoPath, string remotePath, string username, string pw)
        {
            PushOptions pushOps = new PushOptions();
            UsernamePasswordCredentials creds = new UsernamePasswordCredentials();
            creds.Username = username;
            creds.Password = pw;
            pushOps.Credentials = creds;

            var remote = repo.Network.Remotes["upstream"];
            if(remote == null)
            {
                repo.Network.Remotes.Add("upstream", remotePath);
                remote = repo.Network.Remotes["upstream"];
            }

            try { repo.Network.Push(repo.Network.Remotes["remotes"], "HEAD", "refs/heads/master", pushOps); }
            catch (Exception e) { return "Message: " + e.Message + " Cause: " + e.InnerException + " Error#: " + e.HResult; }
            return null;
        }
    }
    
}
