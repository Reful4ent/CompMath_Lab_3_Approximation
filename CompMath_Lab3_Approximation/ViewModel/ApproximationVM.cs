﻿using System.Collections.ObjectModel;
using CompMath_Lab3_Approximation.Model;
using CompMath_Lab3_Approximation.Model.Methods;
using CompMath_Lab3_Approximation.ViewModel.Commands;

namespace CompMath_Lab3_Approximation.ViewModel
{
    public class ApproximationVM : BaseVM
    {
        private ITable tableOY;
        private int indexMethod = 0;
        private int countOfElements = 0;
        private int countOfRatio = 0;
        private int indexElement = 0;
        private int indexDegree = 0;
        private int[] Degrees = { 1, 2, 3, 4 };
        private ObservableCollection<Points> pointsList;
        private ObservableCollection<Ratios> ratioList;

        public Action<Func<double, double>, double[,]>? DrowAction;
        public Action<int>? ErrorProgram;

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
        
        public int IndexDegree
        {
            get => indexDegree;
            set => Set(ref indexDegree, value);
        }

        public ObservableCollection<Points> PointsList
        {
            get => pointsList;
            set => Set(ref pointsList, value);
        }
        
        public ObservableCollection<Ratios> RatioList
        {
            get => ratioList;
            set => Set(ref ratioList, value);

        }

        public Array MethodsArray => MethodsList.methods;
        public Array DegreesArray => Degrees;

        public int CountOfRatio
        {
            get => countOfRatio;
            set
            {
                Set(ref countOfRatio, value);
                List<Ratios> list = new List<Ratios>();
                for (int i = 0; i < countOfRatio; i++)
                    list.Add(new Ratios());
                RatioList = new ObservableCollection<Ratios>(list);
            }
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
            }
        }

        /// <summary>
        /// Вызывает создание и заполнение таблицы
        /// </summary>
        public Command SetTableCommand => Command.Create(SetTable);
        
        public void SetTable()
        {
            if (PointsList == null && RatioList == null)
            {
                ErrorProgram?.Invoke(0);
                return;
            }
            else if (PointsList == null && !(RatioList == null))
            {
                double[] tempRatios = new double[RatioList.Count];
                for (int i = 0; i < RatioList.Count; i++)
                    tempRatios[i] = RatioList[i].Ratio;
                if(!(tableOY.SetRatios(tempRatios)))
                    ErrorProgram?.Invoke(0);
                return;
            }
            else if (!(PointsList == null) && RatioList == null)
            {
                double[] tempX = new double[PointsList.Count];
                double[] tempY = new double[PointsList.Count];
                for (int i = 0; i < PointsList.Count; i++)
                {
                    tempX[i] = PointsList[i].X;
                    tempY[i] = PointsList[i].Y;
                }
                if(!(tableOY.SetTable(tempX, tempY)))
                    ErrorProgram?.Invoke(0);
                return;
            }
            else
            {
                double[] tempX = new double[PointsList.Count];
                double[] tempY = new double[PointsList.Count];
                double[] tempRatios = new double[RatioList.Count];
                for (int i = 0; i < PointsList.Count; i++)
                {
                    tempX[i] = PointsList[i].X;
                    tempY[i] = PointsList[i].Y;
                }

                for (int i = 0; i < RatioList.Count; i++)
                    tempRatios[i] = RatioList[i].Ratio;
                if(!(tableOY.SetTable(tempX, tempY) && tableOY.SetRatios(tempRatios)))
                    ErrorProgram?.Invoke(0);
                return;
            }
        }
        
        /// <summary>
        /// Вызывает очистку таблицы
        /// </summary>
        public Command ClearTableCommand => Command.Create((() =>
        {
            if (tableOY.Table == null && tableOY.RatiosList == null)
            {
                ErrorProgram?.Invoke(1);
                return;
            }
            else if(!(tableOY.Table == null) && tableOY.RatiosList == null)
            {
                tableOY.ClearTable();
                CountOfElements = 0;
                return;
            }
            else if (tableOY.Table == null && !(tableOY.RatiosList == null))
            {
                tableOY.ClearRatios();
                CountOfRatio = 0;
                return;
            }
            else
            {
                tableOY.ClearTable();
                tableOY.ClearRatios();
                CountOfRatio = 0;
                CountOfElements = 0;
                return;
            }
        }));
        
        /// <summary>
        /// Вызывает метод необходимый метод (Лагранжа и тд)
        /// </summary>
        public Command CallMethodCommand => Command.Create(CallMethod);

        public void CallMethod()
        {
            if (tableOY.Table == null)
            {
                ErrorProgram?.Invoke(1);
                return;
            }
            switch (indexMethod)
            {
                case 0: DrowAction?.Invoke(LagrangeMethod.CreateLagrange(tableOY.GetX(),tableOY.GetY()),tableOY.Table); break;
                case 1: DrowAction?.Invoke(NutonMethod.CreateNuton(tableOY.GetX(),tableOY.GetY()),tableOY.Table); break;
                case 2: DrowAction?.Invoke(SmoothPolMethod.CreateSmooth(tableOY.GetX(),tableOY.GetY(),IndexDegree+1),tableOY.Table); break;
                case 3: DrowAction?.Invoke(SplineMethod.CubicSplineInterpolation(tableOY.GetX(),tableOY.GetY()),tableOY.Table); break;
                case 4: DrowAction?.Invoke(RatiosMethod.CreateRation(tableOY.GetRatios()),null); break;
                default: break;
            }
        }
    }
}
