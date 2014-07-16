﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibGit2Sharp;

namespace GitHubPlugin
{
    class GitCommit
    {        
        private Repository repo;
        private Signature author;

        public GitCommit(string repo, string author, string handle)
        {
            this.repo = new Repository(repo);
            this.author = new Signature(author, handle, DateTime.Now);
        }

        public string commitFiles(List<string> files, string comMsg)
        {
            foreach (string s in files)
            {
                repo.Index.Stage(s);
            }
            try
            {
                Commit commit = repo.Commit(comMsg, author, author);
            }
            catch (Exception e)
            {
                return "Message: " + e.Message + " Cause: " + e.InnerException + " Error#: " + e.HResult;
            }
            return null;
        }
    }
}
