using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Drag_drop_observable_uc.ViewModel
{
    public class AnzeigeBasisViewModel : BaseViewModel
    {
        public ToDoListViewModel NeueAnzeige { get; }

        public AnzeigeBasisViewModel(ToDoListViewModel neueanzeige)
        {
            NeueAnzeige = neueanzeige;
        }
    }
}
