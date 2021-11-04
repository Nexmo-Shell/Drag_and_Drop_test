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
    }
}
