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
        private int score;
        private string details;

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

        public int Score
        {
            get { return this.score; }
            set
            {
                if (this.score != value)
                {
                    this.score = value;
                }
            }
        }

        public string Details
        {
            get { return this.details; }
            set
            {
                if (this.details != value)
                {
                    this.details = value;
                }
            }
        }
    }
}
