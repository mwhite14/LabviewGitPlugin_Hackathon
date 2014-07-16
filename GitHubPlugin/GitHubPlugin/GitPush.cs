using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibGit2Sharp;

namespace GitHubPlugin
{
    class GitPush
    {
        private Repository repo;
        private Remote remote;

        public GitPush(string localRepoPath) 
        { 
            repo = new Repository(localRepoPath);
            remote = repo.Network.Remotes["orgin"];
        }

        /// <summary>
        /// pushes current repo
        /// </summary>
        /// <returns>string if error, else null</returns>
        public string push()
        {
            try { repo.Network.Push(remote, "HEAD", "refs/heads/orgin/"); }
            catch (Exception e) { return "Message: " + e.Message + " Cause: " + e.InnerException + " Error#: " + e.HResult; }
            return null;
        }
    }
    
}
