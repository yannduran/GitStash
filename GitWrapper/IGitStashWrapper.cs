using System.Collections.Generic;
using System.ComponentModel;

namespace GitWrapper
{
    public interface IGitStashWrapper
    {
        IList<IGitStash> Stashes { get; }
        string CurrentBranch { get; }
        IGitStashResults ApplyStash(IGitStashApplyOptions options, int index);
        IGitStashResults DropStash(IGitStashDropOptions options, int index);
        IList<string> GetUntrackedChangesList(int stashIndex);
        IGitStashResults PopStash(IGitStashPopOptions options, int index);
        IGitStashResults SaveStash(IGitStashSaveOptions options);
        IGitStashResults CreateBranchFromStash(IGitStashCreateBranchOptions options, int index);
        bool WorkingDirHasChanges();
        event GitStashWrapper.StashesChangedEventHandler StashesChangedEvent;
        int GetUntrackedFileCount();
        int GetIgnoredFileCount();
    }
}