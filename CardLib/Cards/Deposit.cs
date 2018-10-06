using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardLib
{
    class Deposit : Card
    {
        public static Deposit getNewRandomCard()//добавить рандом в статы карты
        {
            Date timeOut = 6;
            int percent = 40;
            Money initialMoney = 400;
            Money applyMoney = initialMoney + initialMoney * percent * timeOut / 12 / 100;

            return new Deposit(timeOut, percent, initialMoney, applyMoney);
        }

        public Deposit(Date timeOut, int percent, Money initialMoney, Money applyMoney) : base(timeOut, percent, initialMoney, applyMoney)
        {
        }

        public override string Title
            => "Депозит от частного лица\nсумма   " + initialMoney + "\nпроцент " + percent;

        public override string AvailableDescription
            => Title + "\nсрок    " + TimeOut;

        public override string ActiveDescription
            => Title + "\nвозврат " + TimeOut;

        protected bool canBeApplied => applyMoney <= bank.Account;

        public override void initialApply()
        {
            game.bankCards.Add(this);
            game.availableCards.Remove(this);
            bank.addMoney(initialMoney);
        }

        protected override void apply()
        {
            if (canBeApplied)
            {
                game.bankCards.Remove(this);
                bank.subMoney(applyMoney);
            }
            else
            {
                throw new Exception("GameOver");
            }
        }

        public override string ToString()
        {
            return "Депозит частному лицу ToString";
        }
        
    }
}
