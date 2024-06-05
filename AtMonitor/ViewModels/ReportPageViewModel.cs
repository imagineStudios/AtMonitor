using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AtMonitor.ViewModels
{
    public partial class ReportPageViewModel : ObservableObject
    {
        //[RelayCommand]
        //private Task AddTeamAsync()
        //{
        //    //return NavigationService.NavigateToAsync("Settings");
        //}

        public ObservableCollection<ReportViewModel> Reports { get; } = new ObservableCollection<ReportViewModel>();
    }
}
