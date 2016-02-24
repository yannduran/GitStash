using GitStash.Common;
using GitStash.UI;
using GitStash.ViewModels;
using GitWrapper;
using Microsoft.TeamFoundation.Controls;
using SecondLanguage;
using System.IO;
using TeamExplorer.Common;


namespace GitStash.Sections
{
    [TeamExplorerSection(GitStashPackage.StashToBranchSection, GitStashPackage.StashPage, 125)]
    public class StashToBranchSection : TeamExplorerBaseSection
    {
        private IGitStashWrapper wrapper;
        StashToBranchViewModel vm;
        public override void Initialize(object sender, SectionInitializeEventArgs e)
        {
            base.Initialize(sender, e);
            this.wrapper = GetService<IGitStashWrapper>();
            vm = new StashToBranchViewModel(wrapper, this);
            SectionContent = new StashToBranchControl(vm);
            Translator T = GetService<IGitStashTranslator>().Translator;
            Title = T["Create Branch From Stash"];
            IsVisible = vm.IsVisible;
            vm.PropertyChanged += Vm_PropertyChanged;
        }

        private void Vm_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            IsVisible = vm.IsVisible;
        }

        public override void Refresh()
        {
            var service = GetService<ITeamExplorerPage>();
            service.Refresh();
        }
    }
}
