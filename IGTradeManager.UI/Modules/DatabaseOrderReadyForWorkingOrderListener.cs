using IGTradeManager.UI.Data;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IGTradeManager.UI.Modules
{
    public class DatabaseOrderReadyForWorkingOrderListener : IDatabaseOrderReadyForWorkingOrderListener
    {
        private readonly IDataCache _DataCache;

        public DatabaseOrderReadyForWorkingOrderListener(IDataCache dataCache)
        {
            _DataCache = dataCache;

            _DataCache.DatabaseOrders.ListChanged += DatabaseOrders_ListChanged;
        }

        private void DatabaseOrders_ListChanged(object sender, System.ComponentModel.ListChangedEventArgs e)
        {
            if (e.ListChangedType == System.ComponentModel.ListChangedType.ItemChanged)
            {
                if (e.PropertyDescriptor.Name == "IsValidForWorkingOrder")
                {
                    var changedorder = _DataCache.DatabaseOrders[e.OldIndex];

                    var correspondingWorkingOrder = _DataCache.IgWorkingOrders.FirstOrDefault(o => o.Epic == changedorder.IgInstrument);

                    //create working order
                    if (changedorder.IsValidForWorkingOrder)
                    {
                        if (correspondingWorkingOrder == null)
                        {
                            //create working order
                        }
                        else
                        {
                            //already has working order
                        }
                    }
                    else
                    {
                        //should delete working order if exists?
                    }

                    Debug.WriteLine(string.Format("{0} -> IsValidForWorkingOrder: {1}", changedorder.Ticker, changedorder.IsValidForWorkingOrder));
                }
            }
        }
    }
}
