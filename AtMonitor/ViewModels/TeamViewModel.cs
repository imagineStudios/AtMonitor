using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
namespace AtMonitor.ViewModels
{
    public partial class TeamViewModel : ObservableObject
    {
        public TeamViewModel(string name, IEnumerable<PersonViewModel> members)
        {
            Name = name;
            Members = members.ToArray();
        }

        public string Name { get; }

        public PersonViewModel[] Members { get; }
    }
}
