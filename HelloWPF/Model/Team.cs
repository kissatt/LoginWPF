using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelloWPF.Model
{
    public class Team
    {
        private string name;

        public string Name
        {
            get { return this.name; }
            set
            {
                if(this.name != value)
                {
                    this.name = value;
                    
                }
            }
        }

        /*public event PropertyChangedEventHandler PropertyChanged;

        public void NotifyPropertyChanged(string propName)
        {
            if (this.PropertyChanged != null)
                this.PropertyChanged(this, new PropertyChangedEventArgs(propName));
        }*/
    }
}
