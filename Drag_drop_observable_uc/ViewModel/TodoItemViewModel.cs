using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Drag_drop_observable_uc.ViewModel
{
    public class TodoItemViewModel : BaseViewModel
    {

        private string name;

        public string Name
        {
            get => name;
            set => SetProperty(ref name, value);
        }
    }
}
