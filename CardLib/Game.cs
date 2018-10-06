using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;

namespace CardLib
{
    public class Game : INotifyPropertyChanged
    {
        public ObservableCollection<Card> bankCards = new ObservableCollection<Card>();
        public ObservableCollection<Card> availableCards = new ObservableCollection<Card>();
        private Bank bank;
        public Bank Bank
        {
            get
            {
                return bank;
            }
            private set
            {
                bank = value;
            }
        }
        private Date date;
        public Date Date {
            get
            {
                return date;
            }
            private set
            {
                date = value;
                OnPropertyChanged("Date");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged(string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }

        public Game()
        {
            Date = new Date(0);
            bank = new Bank();
            Card.game = this;
            Card.bank = bank;

            refreshAvailableCards();

        }

        public void nextStep()
        {
            Date += 1;
            foreach (Card card in bankCards.ToArray())
            {
                card.checkAndApply();
            }
            refreshAvailableCards();
        }

        private void refreshAvailableCards()//нужно дописать, чтобы было рандомное количество разных карт
        {
            availableCards.Clear();
            availableCards.Add(Credit.getNewRandomCard());
            availableCards.Add(Deposit.getNewRandomCard());
        }


        //public void addExCards()
        //{
        //    Card card1 = new ExCard(Date + 2);
        //    Card card2 = new ExCard(Date + 4);
        //    card1.initialApply();
        //    card2.initialApply();

        //    Card card3 = new ExCard(Date + 1);
        //    Card card4 = new ExCard(Date + 3);
        //    Card card5 = new ExCard(Date + 5);
        //    availableCards.Add(card3);
        //    availableCards.Add(card4);
        //    availableCards.Add(card5);
        //}

    }
}
