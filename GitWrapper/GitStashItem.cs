using LibGit2Sharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace GitWrapper
{
    public class GitStashItem : IGitStash
    {
        public GitStashItem(Stash s)
        {
            var groups = Regex.Match(s.CanonicalName + s.Message, @"stash@{(\d+)}On (.*): (.*)\n").Groups;
            try
            {
                Index = Int32.Parse(groups[1].Value);
            }
            catch (FormatException ex)
            {
                throw new Exception($"{s.CanonicalName + s.Message}: {groups[1].Value}", ex);
            }
            Branch = groups[2].Value;
            Message = groups[3].Value;
        }

        public int Index { get; internal set; }
        public string Branch { get; internal set; }
        public string Message { get; internal set; }
    }
}
