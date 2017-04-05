using HelloWPF.Helper;
using HelloWPF.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Windows.Threading;

namespace HelloWPF.ViewModel
{
    class TeamViewModel : INotifyPropertyChanged
    {
        private ObservableCollection<Team> teams = new ObservableCollection<Team>();

        public ObservableCollection<Team> Teams
        {
            get
            {
                return teams;
            }

            set
            {
                teams = value;
                NotifyPropertyChanged("Teams");
            }
        }

        private String teamName;

        public String TeamName
        {
            get
            {
                return teamName;
            }
            set
            {
                teamName = value;
                NotifyPropertyChanged("TeamName");
            }
        }

        private int teamScore;

        public int TeamScore
        {
            get { return teamScore; }
            set
            {
                teamScore = value;
                NotifyPropertyChanged("TeamScore");
            }
        }

        private string teamDetails;

        public string TeamDetails
        {
            get { return teamDetails; }
            set
            {
                teamDetails = value;
                NotifyPropertyChanged("TeamDetails");
            }
        }

        private string elapsedTime = "00:00:000";

        public string ElapsedTime
        {
            get { return elapsedTime; }
            set
            {
                elapsedTime = value;
                NotifyPropertyChanged("ElapsedTime");
            }
        }

        private string firstLap = "00:00:000";

        public string FirstLap
        {
            get { return firstLap; }
            set
            {
                firstLap = value;
                NotifyPropertyChanged("FirstLap");
            }
        }

        private string secondLap = "00:00:000";

        public string SecondLap
        {
            get { return secondLap; }
            set
            {
                secondLap = value;
                NotifyPropertyChanged("SecondLap");
            }
        }

        private string thirdLap = "00:00:000";

        public string ThirdLap
        {
            get { return thirdLap; }
            set
            {
                thirdLap = value;
                NotifyPropertyChanged("ThirdLap");
            }
        }

        private int lapCounter;

        private Stopwatch stopWatch = new Stopwatch();
        private DispatcherTimer dt;

        void dt_Tick(object sender, EventArgs e)
        {
            if (stopWatch.IsRunning)
            {
                TimeSpan ts = stopWatch.Elapsed;
                ElapsedTime = String.Format("{0:00}:{1:00}:{2:000}", ts.Minutes, ts.Seconds, ts.Milliseconds);
            }
        }

        void AddTeamExecute()
        {
            if (teamName == null || teamName == "")
            {
                MessageBox.Show("Csapat hozzáadásához add meg a csapat nevét!", "Nincs csapatnév", MessageBoxButton.OK, MessageBoxImage.Warning);
                
            }
            else
            {
                foreach (Team team in teams)
                {
                    if (team.Name.Equals(teamName))
                    {
                        MessageBox.Show("Már van ilyen nevű csapat a listában! Válassz másik nevet!", "Foglalt csapatnév", MessageBoxButton.OK, MessageBoxImage.Warning);
                        return;
                    }
                }

                teams.Add(new Team { Name = teamName, Score = 0, Details = "new team" });
                MessageBox.Show("Új csapat hozzáadva!", "Sikeres rögzítés", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            
        }

        bool CanAddTeamExecute()
        {
            return true;
        }

        void StartStopperExecute()
        {
            if (!stopWatch.IsRunning)
            {
                InitTimers();
                lapCounter = 0;
                stopWatch.Reset();
                dt = new DispatcherTimer();
                dt.Tick += new EventHandler(dt_Tick);
                dt.Interval = new TimeSpan(0, 0, 0, 0, 1);
                stopWatch.Start();
                dt.Start();
            }
        }

        void StopStopperExecute()
        {
            if (lapCounter < 3)
            {
                stopWatch.Stop();
                TimeSpan ts = stopWatch.Elapsed;
                ElapsedTime = String.Format("{0:00}:{1:00}:{2:000}", ts.Minutes, ts.Seconds, ts.Milliseconds);
                AddLapTime();
                lapCounter++;
                if (lapCounter < 3)
                {
                    stopWatch.Restart();
                }
            }
            else
            {
                if (stopWatch.IsRunning)
                {
                    stopWatch.Stop();
                }

            }
            
        }

        void ResetStopperExecute()
        {
            if (stopWatch.IsRunning)
            {
                stopWatch.Reset();
            }
            lapCounter = 3;
            InitTimers();
        }

        void InitTimers()
        {
            ElapsedTime = FirstLap = SecondLap = ThirdLap = "00:00:000";
        }

        void AddLapTime()
        {
            switch (lapCounter)
            {
                case 0:
                    FirstLap = ElapsedTime;
                    break;
                case 1:
                    SecondLap = ElapsedTime;
                    break;
                case 2:
                    ThirdLap = ElapsedTime;
                    break;
            }
        }

        public ICommand AddTeam { get { return new DelegateCommand(AddTeamExecute); } }

        public ICommand StartStopper { get { return new DelegateCommand(StartStopperExecute); } }

        public ICommand StopStopper { get { return new DelegateCommand(StopStopperExecute); } }

        public ICommand ResetStopper { get { return new DelegateCommand(ResetStopperExecute); } }

        public event PropertyChangedEventHandler PropertyChanged;

        public void NotifyPropertyChanged(string propName)
        {
            if (this.PropertyChanged != null)
                this.PropertyChanged(this, new PropertyChangedEventArgs(propName));
        }
    }
}
