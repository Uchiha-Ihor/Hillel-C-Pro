using LB4.Task_1;
using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LB4.Task_3
{
    internal class CreditCard (int _money, int _CVC) : ObjectService<CreditCard>(_money)
    {
        private int money = _money;
        private int CVC = _CVC;

        protected override CreditCard CreateInstance(int newValue)
        {
            return new CreditCard(newValue, this.CVC);
        }

        public static bool operator ==(CreditCard card, int _CVC)
        {
            return card.CVC == _CVC;
        }

        public static bool operator !=(CreditCard card, int _CVC)
        {
            return card.CVC != _CVC;
        }

        public override string ToString()
        {
            return "Money:" + money.ToString() + " CVC:" + CVC.ToString();
        }
    }
}
