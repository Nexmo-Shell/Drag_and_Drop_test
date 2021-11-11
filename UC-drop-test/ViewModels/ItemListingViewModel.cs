using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using UC_drop_test.Commands;
using UC_drop_test.UC;

namespace UC_drop_test.ViewModels
{
    class ItemListingViewModel : BaseViewModel
    {

        public event EventHandler OpenDialog;
        //public event EventHandler NewUC;

        public ItemListingViewModel()
        {
            this.OpenDialogCommand = new DelegateCommand(
                (o) =>
            {
                this.OpenDialog?.Invoke(this, EventArgs.Empty);

            });
        }

        public ICommand OpenDialogCommand { get; init; }

        string name = string.Empty;
        public string Name
        {
            get => name;
            set
            {
                name = value;
            }
        }


    }
}
