using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibGit2Sharp;

namespace GitHubPlugin
{
    class GitInit
    {
        private string _relativeFilePath;

        public string RelativeFilePath { get { return _relativeFilePath; } }

        /// <summary>
        /// Constructor
        /// </summary>
        public GitInit()
        { }

        public GitInit(string relativePath)
        {
            _relativeFilePath = relativePath;
        }

        public void setRelativeFilePath(string newPath)
        {
            _relativeFilePath = newPath;
        }

        /// <summary>
        /// Initializes the repository with the given relative path name
        /// </summary>
        /// <returns></returns>
        public bool InitializeRepo()
        {
            //If the string is empty
            //Need to ensure that the path is a relative path, can be done later
            if (_relativeFilePath.Length < 1)
                return false;

            //Initi the repo
            string rootPath = Repository.Init(_relativeFilePath);

            if (rootPath.Contains(".git"))
                return true;
            else
                return false;
        }

        
    }
}
