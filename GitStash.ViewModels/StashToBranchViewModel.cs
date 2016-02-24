using GitWrapper;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using TeamExplorer.Common;

namespace GitStash.ViewModels
{
    public class StashToBranchViewModel : INotifyPropertyChanged
    {
        public StashToBranchViewModel(IGitStashWrapper wrapper, ITeamExplorerBase page)
        {
        }

        bool _isVisible = false;
        public bool IsVisible
        {
            get { return _isVisible; }
            set { _isVisible = value; OnPropertyChanged(); }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
