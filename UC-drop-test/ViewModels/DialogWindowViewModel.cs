using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using UC_drop_test.Commands;

namespace UC_drop_test.ViewModels
{
    public class DialogWindowViewModel : NotifyableBaseObject
    {
        public event EventHandler Ok;
        public event EventHandler Cancel;

        public DialogWindowViewModel()
        {
            this.OkCommand = new DelegateCommand((o) => this.Ok?.Invoke(this, EventArgs.Empty));
            this.CancelCommand = new DelegateCommand((o) => this.Cancel?.Invoke(this, EventArgs.Empty));
        }

        string name = string.Empty;

        public string Name
        {
            get => name;
            set
            {
                name = value;
            }
        }

        public ICommand OkCommand { get; init; }
        public ICommand CancelCommand { get; init; }
    }
}
