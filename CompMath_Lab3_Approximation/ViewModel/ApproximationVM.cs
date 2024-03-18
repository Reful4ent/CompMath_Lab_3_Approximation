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
        private ITable tableOY;
        private int indexMethod = 0;
        private int countOfElements = 0;
        private int indexElement = 0;
        private ObservableCollection<Points> pointsList;

        public Action<Func<double, double>, double[,]>? LagrangeAction;

        public ApproximationVM()
        {
            tableOY = new TableXY();
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

        public Array MethodsArray => MethodsList.methods;

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
            }
        }

        /// <summary>
        /// Вызывает создание и заполнение таблицы
        /// </summary>
        public Command SetTableCommand => Command.Create(SetTable);
        
        public void SetTable()
        {
            double[] tempX = new double[PointsList.Count];
            double[] tempY = new double[PointsList.Count];
            for (int i = 0; i < PointsList.Count; i++)
            {
                tempX[i] = PointsList[i].X;
                tempY[i] = PointsList[i].Y;
            }
            tableOY.SetTable(tempX, tempY);
        }
        
        /// <summary>
        /// Вызывает очистку таблицы
        /// </summary>
        public Command ClearTableCommand => Command.Create((() =>
        {
            tableOY.ClearTable();
            CountOfElements = 0;
        }));
        
        /// <summary>
        /// Вызывает метод необходимый метод (Лагранжа и тд)
        /// </summary>
        public Command CallMethodCommand => Command.Create(CallMethod);

        public void CallMethod()
        {
            switch (indexMethod)
            {
                case 0: LagrangeAction?.Invoke(LagrangeMethod.CreateLagrange(tableOY.GetX(),tableOY.GetY()),tableOY.Table); break;
                case 2: 
                default: break;
            }
        }
    }
}
