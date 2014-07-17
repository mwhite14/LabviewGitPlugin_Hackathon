using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibGit2Sharp;
using System.Globalization;

namespace GitHubPlugin
{
    public class GitCommitLogs
    {
        private string _relativeRepoPath;

        public string RelativeRepoPath { get { return _relativeRepoPath; } }

        public GitCommitLogs()
        { }

        public GitCommitLogs(string repoPath)
        {  
            _relativeRepoPath = repoPath;   
        }

        /// <summary>
        /// Simply retrieves a list of Commits from the repository
        /// </summary>
        /// <param name="numberOfCommits"></param>
        /// <returns>A list of string lists that each contain 
        /// Author name, author email, time (formatted), and commit message</returns>
        public List<List<string>> RetrieveCommitLogs(int numberOfCommits = 50)
        {
            List<List<string>> commitLogs = new List<List<string>>();

            string RFC2822Format = "ddd d MMM HH:mm:ss yyyy K";

            Repository repo = new Repository(_relativeRepoPath);

            foreach(Commit c in repo.Commits.Take(numberOfCommits))
            {
                commitLogs.Add(new List<string>() {c.Author.Name, c.Author.Email, 
                                                   c.Author.When.ToString(RFC2822Format, CultureInfo.InvariantCulture), c.Message});
            }

            return commitLogs;
        }

    }
}
