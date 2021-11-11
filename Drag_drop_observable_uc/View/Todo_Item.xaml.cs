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
    /// Interaktionslogik für Todo_Item.xaml
    /// </summary>
    public partial class Todo_Item : UserControl
    {
        public Todo_Item(string name)
        {
            InitializeComponent();

            ((TodoItemViewModel)DataContext).Name = name;
        }
    }
}
