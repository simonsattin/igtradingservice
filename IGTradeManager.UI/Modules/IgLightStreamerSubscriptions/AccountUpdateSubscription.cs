using IGPublicPcl;
using Lightstreamer.DotNet.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IGTradeManager.UI.Modules.IgLightStreamerSubscriptions
{
    public class AccountUpdateSubscription : HandyTableListenerAdapter, IAccountUpdateSubscription
    {
        public delegate void AccountSubscriptionUpdateEventHandler(AccountSubscriptionUpdateEventArgs e);
        public event AccountSubscriptionUpdateEventHandler AccountSubscriptionUpdate;

        public override void OnUpdate(int itemPos, string itemName, IUpdateInfo update)
        {
            var handler = AccountSubscriptionUpdate;
            if (handler != null)
            {
                var eventArgs = new AccountSubscriptionUpdateEventArgs();

                var pnl = update.GetNewValue("PNL");
                var deposit = update.GetNewValue("DEPOSIT");
                var usedMargin = update.GetNewValue("USED_MARGIN");
                var amountDue = update.GetNewValue("AMOUNT_DUE");
                var availableCash = update.GetNewValue("AVAILABLE_CASH");
                var funds = update.GetNewValue("FUNDS");
                var margin = update.GetNewValue("MARGIN");
                var equity = update.GetNewValue("EQUITY");
                var equityUsed = update.GetNewValue("EQUITY_USED");

                if (!String.IsNullOrEmpty(pnl))
                {
                    eventArgs.PNL = Convert.ToDecimal(pnl);
                }
                if (!String.IsNullOrEmpty(deposit))
                {
                    eventArgs.Deposit = Convert.ToDecimal(deposit);
                }
                if (!String.IsNullOrEmpty(usedMargin))
                {
                    eventArgs.UsedMargin = Convert.ToDecimal(usedMargin);
                }
                if (!String.IsNullOrEmpty(amountDue))
                {
                    eventArgs.AmountDue = Convert.ToDecimal(amountDue);
                }
                if (!String.IsNullOrEmpty(availableCash))
                {
                    eventArgs.AvailableCash = Convert.ToDecimal(availableCash);
                }
                if (!String.IsNullOrEmpty(equity))
                {
                    eventArgs.Equity = Convert.ToDecimal(equity);
                }
                if (!String.IsNullOrEmpty(funds))
                {
                    eventArgs.Funds = Convert.ToDecimal(funds);
                }

                handler(eventArgs);
            }

            base.OnUpdate(itemPos, itemName, update);
        }
    }
}
