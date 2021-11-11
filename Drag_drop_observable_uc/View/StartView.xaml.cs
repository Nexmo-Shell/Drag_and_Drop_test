using Drag_drop_observable_uc.ViewModel;
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
    /// Interaktionslogik für StartView.xaml
    /// </summary>
    public partial class StartView : UserControl
    {
        public StartView()
        {
            InitializeComponent();
        }

        private void UC_Loaded(object sender, RoutedEventArgs e)
        {
            var vm = ((StartViewModel)DataContext);
            vm.NewUi += (s, ev) =>
            {

                DialogWindow dialog = new DialogWindow();
                if (dialog.ShowDialog() == true)
                {
                    var dialogViewModel = (DialogWindowViewModel)dialog.DataContext;
                    string name = dialogViewModel.Name;
                    AddnewUi(name);
                }
            };
        }
        private void AddnewUi(string name)
        {
            ToDoListViewModel neu = new ToDoListViewModel();
            neu.AddTodoItem(new Todo_Item(name));
            AnzeigeBasisViewModel neueanzeige = new AnzeigeBasisViewModel(neu);
            AnzeigeBasisView neueAnzeige = new AnzeigeBasisView();
            neueAnzeige.DataContext = neueanzeige;
            anzeiger.Children.Add(neueAnzeige);
           
        }
    }
}
