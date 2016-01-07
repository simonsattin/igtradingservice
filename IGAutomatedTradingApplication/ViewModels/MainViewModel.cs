using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IGAutomatedTradingApplication.ViewModels
{
    public class MainViewModel : PropertyChangedBase
    {
        private const string WindowTitleDefault = "So. Just Note It";

        private string _windowTitle = WindowTitleDefault;

        public string WindowTitle
        {
            get { return _windowTitle; }
            set
            {
                _windowTitle = value;
                NotifyOfPropertyChange(() => WindowTitle);
            }
        }

    }
}
