using Drag_drop_observable_uc.Commands;
using Drag_drop_observable_uc.View;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Drag_drop_observable_uc.ViewModel
{
    public class ToDoListViewModel : BaseViewModel
    {

        private readonly ObservableCollection<Todo_Item> _todoItemViewLists;

        public IEnumerable<Todo_Item> TodoItemViewList => _todoItemViewLists;

        private Todo_Item _incomingTodoView;
        public Todo_Item IncomingTodoView
        {
            get => _incomingTodoView;
            set => SetProperty(ref _incomingTodoView, value);
        }
        private Todo_Item _removedTodoView;
        public Todo_Item RemovedTodoView
        {
            get => _removedTodoView;
            set => SetProperty(ref _removedTodoView, value);
        }



        private Todo_Item _insertedTodoView;

        public Todo_Item InsertedTodoView
        {
            get => _insertedTodoView;
            set => SetProperty(ref _insertedTodoView, value);
        }

        private Todo_Item _targetTodoView;

        public Todo_Item TargetTodoView
        {
            get => _targetTodoView;
            set => SetProperty(ref _targetTodoView, value);
        }

        public ICommand TodoViewReceivedCommand { get; }
        public ICommand TodoViewRemovedCommand { get; }
        public ICommand TodoViewInsertedCommand {get;}

        public ToDoListViewModel()
        {
            _todoItemViewLists = new ObservableCollection<Todo_Item>();
            TodoViewReceivedCommand = new TodoViewReceivedCommand(this);
                TodoViewRemovedCommand = new TodoViewRemovedCommand(this);
            TodoViewInsertedCommand = new TodoViewInsertedCommand(this);
        }

        public void InsertTodoItem(Todo_Item insertedTodoItem, Todo_Item targetTodoItem)
        {
            if (insertedTodoItem == targetTodoItem)
            {
                return;
            }
            int oldIndex = _todoItemViewLists.IndexOf(insertedTodoItem);
            int nextIndex = _todoItemViewLists.IndexOf(targetTodoItem);

            if (oldIndex != -1 && nextIndex != -1)
            {
                _todoItemViewLists.Move(oldIndex, nextIndex);
            }
        }

        public void AddTodoItem(Todo_Item item)
        {
            if (!_todoItemViewLists.Contains(item))
            {
                _todoItemViewLists.Add(item);
            }
        }

        public void RemoveTodoItem(Todo_Item item)
        {
            _todoItemViewLists.Remove(item);
        }

        
    }
}
