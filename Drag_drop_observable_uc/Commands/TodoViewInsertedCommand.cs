using Drag_drop_observable_uc.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Drag_drop_observable_uc.Commands
{
    public class TodoViewInsertedCommand : CommandBase
    {
        private readonly ToDoListViewModel _viewModel;

        public TodoViewInsertedCommand(ToDoListViewModel viewModel)
        {
            _viewModel = viewModel;
        }

        public override void Execute(object parameter)
        {
            _viewModel.InsertTodoItem(_viewModel.InsertedTodoView, _viewModel.TargetTodoView);
        }
    }
}
