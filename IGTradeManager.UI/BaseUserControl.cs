using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IGTradeManager.UI
{
    public partial class BaseUserControl : UserControl
    {
        /// <summary>
        /// Gets a controller of the given type.
        /// </summary>
        /// <typeparam name="T">The type of the controller to get.</typeparam>
        /// <returns>An instance of a controller of the given type.</returns>
        protected T GetController<T>() where T : class, IController
        {
            return ContainerProvider.Container.GetInstance<T>(); ;
        }

        public BaseUserControl()
        {
            InitializeComponent();
        }
    }
}
