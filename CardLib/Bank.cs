using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel;
using System.Text;
using System.Threading.Tasks;

namespace CardLib
{
    [Serializable]
    public class Bank : INotifyPropertyChanged
    {
        private Money account;
        public Money Account {
            get
            {
                return account;
            }
            private set
            {
                account = value;
                OnPropertyChanged("Account");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged(string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }

        public Bank()
        {
            account = new Money(1000);
        }


        public void addMoney(Money money)
        {
            Account += money;
        }
        public void subMoney(Money money)
        {
            Account -= money;
            if (Account.Value < 0) throw new Exception("account < 0");
        }
        
        public int Share { get; private set; }
        public void addShare(int percent)
        {
            Share += percent;
        }
        public void subShare(int percent)
        {
            Share -= percent;
            if (Share < 0) throw new Exception("share < 0");
        }
        
    }
}
