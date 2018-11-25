//  Для решения задачи создать класс Matrix, содержащий
//      	закрытое поле-массив для хранения данных,
//      	конструктор без параметров для создания единичной матрицы 3×3,
//      	конструктор с параметрами (параметр – матрица целых чисел),
//      	метод ToString(), возвращающий строковое представление матрицы,
//      	индексатор для доступа к элементам поля-массива, 
//      	метод GetLenth – аналог одноименного метода из Array,
//      	закрытый(private) метод, возвращающий true, если столбец состоит из положительных элементов(параметр – номер столбца),
//      	метод, возвращающий сумму элементов столбцов, состоящих из положительных элементов,
//      	свойство, возвращающее сумму элементов диагоналей матрицы.
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW4
{
    class Matrix
    {
        // закрытое поле-массив для хранения данных
        int[,] arr;

        // конструктор без параметров для создания единичной матрицы 3×3
        public Matrix ()
        {
            arr = new int[3, 3];
            arr[0, 0] = 1;
            arr[1, 1] = 1;
            arr[2, 2] = 1;
        }

        // конструктор с параметрами (параметр – матрица целых чисел)
        public Matrix(int[,] matrix)
        {
            //double sizeMatrix = Math.Sqrt(matrix.Length);
            //if (sizeMatrix == (int)sizeMatrix)                                 //проверяем квадратная ли матрица
            //{
                arr = matrix;
            //}
        }

        // метод ToString(), возвращающий строковое представление матрицы
        public override string ToString()
        {
            string str = "";
            bool[] posSpace = new bool[arr.GetLength(1)]; // есть ли в колонке отрицательные числа
            for (int j = 0; j < arr.GetLength(1); j++)
            {
                for (int i = 0; i < arr.GetLength(0); i++)
                {
                    if (arr[i,j]<0)
                    {
                        posSpace[j] = true;     // в колонке j есть отрицательные числа, для положительных чисел j колонки нужен сдвиг
                        break;
                    }
                }
            }
            for (int i = 0; i < arr.GetLength(0); i++)
            {
                for (int j = 0; j < arr.GetLength(1); j++)
                {
                    if(j==0)
                    {
                        if (arr[i,j]>=0 && posSpace[j])
                            str += "║ " + arr[i, j] + " ";
                        else
                            str += "║" + arr[i, j] + " ";
                    }
                    else if (j<arr.GetLength(0)-1)
                    {
                        if (arr[i, j] >= 0 && posSpace[j])
                            str += " "+arr[i, j] + " ";
                        else 
                            str += arr[i, j] + " ";
                    }
                    else if (j==arr.GetLength(1)-1)
                    {
                        if (i!= arr.GetLength(0) - 1)
                        {
                            if (arr[i, j] >= 0 && posSpace[j])
                                str += " " + arr[i, j] + "║\n";
                            else
                                str += arr[i, j] + "║\n";
                        }
                        else
                        {
                            if (arr[i, j] >= 0 && posSpace[j])
                                str += " " + arr[i, j] + "║";
                            else
                                str += arr[i, j] + "║";
                        }
                    }
                }
            }
            return str;
        }

        // индексатор для доступа к элементам поля-массива
        public int this [int i, int j] { get => arr[i, j]; set => arr[i, j] = value; }

        // метод GetLenth – аналог одноименного метода из Array(возвращает количество элементов в заданном измерении массива)
        public int GetLength(int n)
        {
            if (n == 0 || n == 1)
            {
                int length0 = 0;
                try
                {
                    for (int i = 0, tmp = 0; i < arr.Length; i++)
                    {
                        tmp = arr[i, 0];  // обращаемся к массиву пока не выдаст исключение
                        length0++;        // просто return ((int)Math.Sqrt(arr.Length)); - для слабаков :)
                    }
                }
                catch (IndexOutOfRangeException)
                {
                    if (n == 0)
                        return (length0);
                    else
                    {
                        return ((int)(arr.Length / length0));
                    }
                }
            }
            return (0);
        }

        // закрытый(private) метод, возвращающий true, если столбец состоит из положительных элементов(параметр – номер столбца)
        private bool IsColPositiv (int j)
        {
            for (int i = 0; i < arr.GetLength(0); i++)
            {
                if (arr[i, j] < 0)
                    return (false);
            }
            return (true);
        }

        // метод, возвращающий сумму элементов столбцов, состоящих из положительных элементов
        public int SumColPositiv ()
        {
            int sumPositiv = 0;
            for (int j = 0; j < arr.GetLength(1); j++)
            {
                if (IsColPositiv(j))
                    for (int i = 0; i < arr.GetLength(0); i++)
                    {
                        sumPositiv += arr[i, j];
                    }
            }
            return (sumPositiv);
        }

        // свойство, возвращающее сумму элементов диагоналей матрицы
        public int SumDiagonal ()
        {
            int sumDiag = 0;
            for (int i = 0; i < arr.GetLength(0); i++)
            {
                for (int j = 0; j < arr.GetLength(1); j++)
                {
                    if (i==j || j == arr.GetLength(1)-1 - i)
                    {
                        sumDiag += arr[i, j];
                    }
                }
            }
            return (sumDiag);
        }
    }
}
