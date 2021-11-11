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

namespace Drag_drop_observable_uc.View
{
    /// <summary>
    /// Interaktionslogik für ToDoListView.xaml
    /// </summary>
    public partial class ToDoListView : UserControl
    {
        public ToDoListView()
        {
            InitializeComponent();
        }




        public object IncomingViewList
        {
            get { return (object)GetValue(IncomingViewListProperty); }
            set { SetValue(IncomingViewListProperty, value); }
        }

        // Using a DependencyProperty as the backing store for IncomingViewList.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty IncomingViewListProperty =
            DependencyProperty.Register("IncomingViewList", typeof(object), typeof(ToDoListView), new FrameworkPropertyMetadata(null, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));



        public object RemovedViewList
        {
            get { return (object)GetValue(RemovedViewListProperty); }
            set { SetValue(RemovedViewListProperty, value); }
        }

        // Using a DependencyProperty as the backing store for RemovedViewList.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty RemovedViewListProperty =
            DependencyProperty.Register("RemovedViewList", typeof(object), typeof(ToDoListView), new FrameworkPropertyMetadata(null, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));




        public object TargetViewList
        {
            get { return (object)GetValue(TargetViewListProperty); }
            set { SetValue(TargetViewListProperty, value); }
        }

        // Using a DependencyProperty as the backing store for TargetViewList.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty TargetViewListProperty =
            DependencyProperty.Register("TargetViewList", typeof(object), typeof(ToDoListView), new FrameworkPropertyMetadata(null, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));



        public object InsertedViewList
        {
            get { return (object)GetValue(InsertedViewListProperty); }
            set { SetValue(InsertedViewListProperty, value); }
        }

        // Using a DependencyProperty as the backing store for InsertedViewList.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty InsertedViewListProperty =
            DependencyProperty.Register("InsertedViewList", typeof(object), typeof(ToDoListView), new FrameworkPropertyMetadata(null, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));



        public ICommand ViewListRemovedCommand
        {
            get { return (ICommand)GetValue(ViewListRemovedCommandProperty); }
            set { SetValue(ViewListRemovedCommandProperty, value); }
        }

        // Using a DependencyProperty as the backing store for ViewListRemovedCommand.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ViewListRemovedCommandProperty =
            DependencyProperty.Register("ViewListRemovedCommand", typeof(ICommand), typeof(ToDoListView), new PropertyMetadata(null));



        public ICommand ViewListInsertedCommand
        {
            get { return (ICommand)GetValue(ViewListInsertedCommandProperty); }
            set { SetValue(ViewListInsertedCommandProperty, value); }
        }

        // Using a DependencyProperty as the backing store for ViewListInsertedCommand.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ViewListInsertedCommandProperty =
            DependencyProperty.Register("ViewListInsertedCommand", typeof(ICommand), typeof(ToDoListView), new PropertyMetadata(null));



        public ICommand ViewListDropCommand
        {
            get { return (ICommand)GetValue(ViewListDropCommandProperty); }
            set { SetValue(ViewListDropCommandProperty, value); }
        }

        // Using a DependencyProperty as the backing store for ViewListDropCommand.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ViewListDropCommandProperty =
            DependencyProperty.Register("ViewListDropCommand", typeof(ICommand), typeof(ToDoListView), new PropertyMetadata(null));






        private void OverViewList_Drop(object sender, DragEventArgs e)
        {

            object viewList = e.Data.GetData(DataFormats.Serializable);
            AddViewListItem(viewList);
        }

        private void OverViewList_DragLeave(object sender, DragEventArgs e)
        {
            HitTestResult result = VisualTreeHelper.HitTest(OverViewList, e.GetPosition(OverViewList));
            if(result == null)
            {
                if(ViewListRemovedCommand?.CanExecute(null)??false)
                {
                    RemovedViewList = e.Data.GetData(DataFormats.Serializable);
                    ViewListRemovedCommand?.Execute(null);
                }
            }
        }


        private void AddViewListItem(object viewlist) 
        {
            if(ViewListDropCommand?.CanExecute(null)?? false)
            {
                IncomingViewList = viewlist;
                ViewListDropCommand?.Execute(null);
            }
        }

        private void ListViewItem_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed && sender is FrameworkElement frameworkElement)
            {
                object viewList = frameworkElement.DataContext;
                DragDropEffects dragdropResult = DragDrop.DoDragDrop(frameworkElement, new DataObject(DataFormats.Serializable, viewList), DragDropEffects.Move);

                if (dragdropResult == DragDropEffects.None)
                {
                    AddViewListItem(viewList);
                }
            }
        }

        private void ListViewItem_DragOver(object sender, DragEventArgs e)
        {
            if(ViewListInsertedCommand?.CanExecute(null) ?? false)
            {
                if(sender is FrameworkElement element)
                {
                    TargetViewList = element.DataContext;
                    InsertedViewList= e.Data.GetData(DataFormats.Serializable);

                    ViewListInsertedCommand?.Execute(null);
                }
            }
        }
    }
}
