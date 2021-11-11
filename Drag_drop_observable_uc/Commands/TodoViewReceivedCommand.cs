using Drag_drop_observable_uc.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Drag_drop_observable_uc.Commands
{
    public class TodoViewReceivedCommand :CommandBase
    {
        private readonly ToDoListViewModel _todoItemListingViewModel;

        public TodoViewReceivedCommand(ToDoListViewModel todoItemListingViewModel)
        {
            _todoItemListingViewModel = todoItemListingViewModel;
        }

        public override void Execute(object parameter)
        {
            _todoItemListingViewModel.AddTodoItem(_todoItemListingViewModel.IncomingTodoView);
        }

    }
}
