using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardLib
{
    class Credit : Card
    {
        public static Credit getNewRandomCard()//добавить рандом в статы карты
        {
            Date timeOut = 6;
            int percent = 20;
            Money initialMoney = 500;
            Money applyMoney = initialMoney + initialMoney * percent * timeOut / 12 / 100;
            
            return new Credit(timeOut, percent, initialMoney, applyMoney);
        }

        public Credit(Date timeOut, int percent, Money initialMoney, Money applyMoney) : base(timeOut, percent, initialMoney, applyMoney)
        {
        }

        public override string Title
            => "Кредит частному лицу\nсумма   " + initialMoney + "\nпроцент " + percent;

        public override string AvailableDescription
            => Title + "\nсрок    " + TimeOut;

        public override string ActiveDescription
            => Title + "\nвозврат " + TimeOut;

        protected bool canBeApplied => initialMoney <= bank.Account;

        public override void initialApply()
        {
            if (canBeApplied)
            {
                game.bankCards.Add(this);
                game.availableCards.Remove(this);
                bank.subMoney(initialMoney);
            }
        }

        protected override void apply()
        {
            game.bankCards.Remove(this);
            bank.addMoney(applyMoney);
        }

        public override string ToString()
        {
            return "Кредит частному лицу ToString";
        }

        
    }
}
