using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using UC_drop_test.ViewModels;

namespace UC_drop_test.UC
{
    /// <summary>
    /// Interaktionslogik für ItemListingView.xaml
    /// </summary>
    public partial class ItemListingView : UserControl
    {


        public object IncomingDisplayObject
        {
            get { return (object)GetValue(IncomingDisplayObjectProperty); }
            set { SetValue(IncomingDisplayObjectProperty, value); }
        }

        // Using a DependencyProperty as the backing store for MyProperty.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty IncomingDisplayObjectProperty =
            DependencyProperty.Register("IncomingDisplayObject", typeof(object), typeof(ItemListingView), new FrameworkPropertyMetadata(null, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));


        public ICommand displayObjectDropCommand
        {
            get { return (ICommand)GetValue(displayObjectDropCommandProperty); }
            set { SetValue(displayObjectDropCommandProperty, value); }
        }

        // Using a DependencyProperty as the backing store for displayObjectDropCommand.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty displayObjectDropCommandProperty =
            DependencyProperty.Register("displayObjectDropCommand", typeof(ICommand), typeof(ItemListingView), new PropertyMetadata(null));


        public object TargetTodoItem
        {
            get { return (object)GetValue(TargetTodoItemProperty); }
            set { SetValue(TargetTodoItemProperty, value); }
        }

        public static readonly DependencyProperty TargetTodoItemProperty =
            DependencyProperty.Register("TargetTodoItem", typeof(object), typeof(ItemListingView),
                new FrameworkPropertyMetadata(null, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));

        public object InserteddisplayObject
        {
            get { return (object)GetValue(InserteddisplayObjectProperty); }
            set { SetValue(InserteddisplayObjectProperty, value); }
        }

        public static readonly DependencyProperty InserteddisplayObjectProperty =
            DependencyProperty.Register("InsertedTodoItem", typeof(object), typeof(ItemListingView),
                new FrameworkPropertyMetadata(null, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));

        public ICommand ToDoItemInsertedCommand
        {
            get { return (ICommand)GetValue(ToDoItemInsertedCommandProperty); }
            set { SetValue(ToDoItemInsertedCommandProperty, value); }
        }

        // Using a DependencyProperty as the backing store for ToDoItemInsertCommand.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ToDoItemInsertedCommandProperty =
            DependencyProperty.Register("ToDoItemInsertedCommand", typeof(ICommand), typeof(ItemListingView), new PropertyMetadata(null));

        public ItemListingView()
        {
            InitializeComponent();


        }

        private void UC_Loaded(object sender, RoutedEventArgs e)
        {
            var vm = (ItemListingViewModel)DataContext;
            vm.OpenDialog += (s, ev) =>
            {
                DialogWindow dialog = new DialogWindow();
                if (dialog.ShowDialog() == true)
                {
                    var dialogViewModel = (DialogWindowViewModel)dialog.DataContext;
                    vm.Name = dialogViewModel.Name;
                    ListingView newuc = new ListingView(vm.Name);
                    _ = display_Panel.Children.Add(newuc);
                }
            };
        }

        private void display_Panel_Drop(object sender, DragEventArgs e)
        {
            object displayObject = e.Data.GetData(DataFormats.Serializable);
            AddDisplayObject(displayObject);
        }

        private void AddDisplayObject(object displayObject)
        {
            if(displayObjectDropCommand?.CanExecute(null)??false)
            {
                IncomingDisplayObject = displayObject;
                displayObjectDropCommand?.Execute(null);
            }
        }

        private void display_Panel_DragOver(object sender, DragEventArgs e)
        {
            if (ToDoItemInsertedCommand?.CanExecute(null) ?? false)
            {
                if (sender is FrameworkElement element)
                {
                    TargetTodoItem = element.DataContext;
                    InserteddisplayObject = e.Data.GetData(DataFormats.Serializable);

                    ToDoItemInsertedCommand?.Execute(null);
                }
            }
        }

        private void display_Panel_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed &&
            sender is FrameworkElement frameworkElement)
            {

                object todoItem = frameworkElement.DataContext;

                DragDropEffects dragdropResult = DragDrop.DoDragDrop(frameworkElement,
                    new DataObject(DataFormats.Serializable, todoItem),
                    DragDropEffects.Move);

                if (dragdropResult == DragDropEffects.None)
                {
                    AddDisplayObject(todoItem);
                }

            }
        }
    }
}
