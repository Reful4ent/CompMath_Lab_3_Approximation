using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CompMath_Lab3_Approximation.Model;
using CompMath_Lab3_Approximation.ViewModel.Commands;

namespace CompMath_Lab3_Approximation.ViewModel
{
    public class ApproximationVM : BaseVM
    {
        private ITableOY tableOY;
        private int indexMethod = 0;
        private int countOfElements = 0;
        private int indexElement = 0;
        private ObservableCollection<Points> pointsList;

        public Action<int>? countOfRowsChanged;

        public ApproximationVM()
        {
            tableOY = new TableOY();
        }
        public int IndexMethod
        {
            get => indexMethod;
            set => Set(ref indexMethod, value);
        }
        
        public int IndexElement
        {
            get => indexElement;
            set => Set(ref indexElement, value);
        }

        public ObservableCollection<Points> PointsList
        {
            get => pointsList;
            set => Set(ref pointsList, value);

        }

        public int CountOfElements
        {
            get => countOfElements;
            set
            {
                Set(ref countOfElements, value);
                List<Points> list = new List<Points>();
                for (int i = 0; i < countOfElements; i++)
                    list.Add(new Points());
                PointsList = new ObservableCollection<Points>(list);
                //countOfRowsChanged?.Invoke(CountOfElements);
            }
        }

        public Command SetTableCommand => Command.Create(SetTable);

        public void SetTable()
        {
            float[] tempX = new float[PointsList.Count];
            float[] tempY = new float[PointsList.Count];
            for (int i = 0; i < PointsList.Count; i++)
            {
                tempX[i] = PointsList[i].X;
                tempY[i] = PointsList[i].Y;
            }
            tableOY.SetTable(tempX, tempY);
        }
    }
}
