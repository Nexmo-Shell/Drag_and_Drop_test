using Drag_drop_observable_uc.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Drag_drop_observable_uc.ViewModel
{
    public class StartViewModel : BaseViewModel
    {

        public event EventHandler NewUi;

        public ICommand NewUiCommand { get; init; }

        public StartViewModel()
        {
            this.NewUiCommand = new DelegateCommand(
                (o) => { this.NewUi?.Invoke(this, EventArgs.Empty);  });

            
        }

    }
}
