using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CompMath_Lab3_Approximation.ViewModel.Commands;

namespace CompMath_Lab3_Approximation.ViewModel
{
    public class ApproximationVM : BaseVM
    {
        private int indexMethod = 0;
        private ObservableCollection<int> X;
        private ObservableCollection<int> Y;
        public int IndexMethod
        {
            get => indexMethod;
            set => Set(ref indexMethod, value);
        }

        public Command SetTableCommand => Command.Create(SetTable);
        public void SetTable()
        {
            
        }
    }
}
