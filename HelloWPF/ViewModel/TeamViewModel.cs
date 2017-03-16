using HelloWPF.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelloWPF.ViewModel
{
    class TeamViewModel
    {
        private ObservableCollection<Team> teams = new ObservableCollection<Team>();

        public TeamViewModel()
        {
            
        }
    }
}
