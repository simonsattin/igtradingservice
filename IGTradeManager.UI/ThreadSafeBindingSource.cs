﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IGTradeManager.UI
{
    public class ThreadSafeBindingSource : BindingSource
    {
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger
                (System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public Control ControlToInvokeOn { get; set; }

        public ThreadSafeBindingSource()
        {

        }

        public ThreadSafeBindingSource(IContainer container)
            : base(container)
        {

        }

        public ThreadSafeBindingSource(object dataSource, string dataMember)
            : base(dataSource, dataMember)
        {

        }

        protected override void OnBindingComplete(BindingCompleteEventArgs e)
        {
            //makes sure that the Control to Invoke on is set
            if (ControlToInvokeOn == null)
                throw new InvalidOperationException("No ControlToInvokeOn has been set for this BindingSource");

            base.OnBindingComplete(e);
        }

        protected override void OnPositionChanged(EventArgs e)
        {
            try
            {
                var control = ControlToInvokeOn;
                if (control != null && control.InvokeRequired)
                {
                    //log.InfoFormat("Threadsafe binding source invoke required: {0}", ControlToInvokeOn.Name);
                    control.Invoke(new Action<ListChangedEventArgs>(OnPositionChanged), e);
                }
                else
                {
                    base.OnPositionChanged(e);
                }
            }
            catch (Exception exception)
            {
                throw new Exception(string.Format("Unexpected error occurred invoking position changed on thread safe binding source for view {0}",
                    (ControlToInvokeOn == null) ? "" : ControlToInvokeOn.Name), exception);
            }
        }

        /// <summary>
        /// Pass the call the the main thread for windows forms
        /// </summary>
        /// <param name="e"></param>
        protected override void OnListChanged(ListChangedEventArgs e)
        {
            try
            {
                var control = ControlToInvokeOn;
                if (control != null && control.InvokeRequired)
                {
                    //log.InfoFormat("Threadsafe binding source invoke required: {0}", ControlToInvokeOn.Name);
                    if (IsControlValid(control))
                        control.Invoke(new Action<ListChangedEventArgs>(OnListChanged), e);
                }
                else
                {
                    base.OnListChanged(e);
                }
            }
            catch (ObjectDisposedException exception)
            {

            }
            catch (Exception exception)
            {
                throw new Exception(string.Format("Unexpected error occurred invoking list changed on thread safe binding source for view {0}",
                    (ControlToInvokeOn == null) ? "" : ControlToInvokeOn.Name), exception);
            }
        }

        private bool IsControlValid(Control myControl)
        {
            if (myControl == null) return false;
            if (myControl.IsDisposed) return false;
            if (myControl.Disposing) return false;
            if (!myControl.IsHandleCreated) return false;
            //if (AbortThread) return false; // the signal to the thread to stop processing
            return true;
        }
    }
}
