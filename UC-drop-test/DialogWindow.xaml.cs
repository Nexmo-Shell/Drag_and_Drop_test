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
using System.Windows.Shapes;
using UC_drop_test.ViewModels;

namespace UC_drop_test
{
    /// <summary>
    /// Interaktionslogik für DialogWindow.xaml
    /// </summary>
    public partial class DialogWindow : Window
    {
        public DialogWindow()
        {
            InitializeComponent();
            var vm = this.DataContext as DialogWindowViewModel;
            vm.Ok += (o, e) => this.DialogResult = true;
            vm.Cancel += (o, e) => this.DialogResult = false;
        }
    }
}
