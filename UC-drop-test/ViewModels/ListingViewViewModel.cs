using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UC_drop_test.ViewModels
{
    public class ListingViewViewModel  : BaseViewModel
    {
        public ListingViewViewModel()
        {
            
        }

        private string name = string.Empty;
        public string Name
        {
            get => name;
            set
            {
                name = value;
                RaisePropertyChanged();
            }
        }
    }
}
