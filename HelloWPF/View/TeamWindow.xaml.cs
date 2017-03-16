using HelloWPF.Model;
using HelloWPF.ViewModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace HelloWPF.View
{
    /// <summary>
    /// Interaction logic for TeamWindow.xaml
    /// </summary>
    public partial class TeamWindow : Window
    {
        private ObservableCollection<Team> teams = new ObservableCollection<Team>();

        TeamViewModel tmViewModel = new TeamViewModel();

        public TeamWindow()
        {
            InitializeComponent();
            //DataContext = tmViewModel;

            lbTeams.ItemsSource = teams;
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            teams.Add(new Team() { Name = txtIn.Text });
        }
    }
}
