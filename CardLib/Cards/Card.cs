using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel;
using System.Text;
using System.Threading.Tasks;

namespace CardLib
{
    abstract public class Card : INotifyPropertyChanged
    {
        static public Game game;
        static public Bank bank;

        
        //protected Date dateToAction;

        protected Date timeOut;
        public Date TimeOut
        {
            get
            {
                return timeOut;
            }
            protected set
            {
                timeOut = value;
                OnPropertyChanged("TimeOut");
                OnPropertyChanged("ActiveDescription");
                OnPropertyChanged("AvailableDescription");
            }
        }

        public readonly Money initialMoney;
        public readonly Money applyMoney;
        public readonly int percent;
    
        public Card(Date timeOut, int percent, Money initialMoney, Money applyMoney)
        {
            this.TimeOut = timeOut;
            this.percent = percent;
            this.initialMoney = initialMoney;
            this.applyMoney = applyMoney;
        }
        
        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged(string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
        
        public void checkAndApply()
        {
            TimeOut -= 1;
            if (TimeOut == 0)
            {
                apply();
            }
        }
        
        abstract public string Title { get; }
        abstract public string ActiveDescription { get; }
        abstract public string AvailableDescription { get; }
        abstract protected void apply();
        abstract public void initialApply();
        abstract public override string ToString();
        //abstract public Card getNewRandomCard();

    }
}
