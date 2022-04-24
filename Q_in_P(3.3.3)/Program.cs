///Название неговорящее 
///Так, сама задача:
///Выпуклый n-угольник P задан координатами своих вершин в порядке обхода против часовой стрелки.
///необходимо определить, содержится ли точка Q внутри P или нет.
///Логика?
///думаю это можно определить проводя через точку Q и центр выпуклого многоугольника P луч.
///Если при этом луч пересекает многоугольник всего 1 раз, то точка находится внутри
///В противном случае происходит 2 пересечения: вход в многоугльник и выход за его пределы.
///В нашем случае не обязательно находить точный центр - хватит и понятия центра тяжести многоугольника
///Или
///Второй вариант (не буду уж перепроверять начальные мысли)
///Построить отрезок центра и точки Q
///Если этот отрезок имеет общую точку с отрезками многоугольника(таких отрезков 4), то точка находится вне Р
///если общих точек нет, то Q принадлежит P


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Q_in_P_3._3._3_
{
    class Program
    {
        static void Main(string[] args)
        {
            double[][] nums = new double[4][]; //пускай у нас будет 4 точки в многоугольнике — квадрат
            nums[0] = new double[2] { -2, 3 };          // выделяем память для первого подмассива
            nums[1] = new double[2] { -2, -9 };       // выделяем память для второго подмассива
            nums[2] = new double[2] { 10, -9 }; // выделяем память для третьего подмассива
            nums[3] = new double[2] { 10, 3 }; // выделяем память для четвертого подмассива

            Console.WriteLine("X:{0} Y:{1}", CenterOfGravity(nums)[0], CenterOfGravity(nums)[1]);
            Console.ReadLine();
        }

        /// <summary>
        /// функция возвращает центр тяжести выпуклого многоугольника в виде массива из 2 элементов - точки с координатами X и Y
        /// на вход поступает массив массивов точек
        /// </summary>
        /// <param name="points"></param>
        /// <returns></returns>
        public static double[] CenterOfGravity(double[][] points) 
        {
            double pointX = 0;
            double pointY = 0;
            double[] point = new double[2];
            for (int i = 0; i < points.Length; i++)
            {
                pointX += points[i][0];//складываем все точки X
            }
            pointX = pointX / points.Length;

            for (int i = 0; i < points.Length; i++)
            {
                pointY += points[i][1];//складываем все точки Y
            }
            pointY = pointY / points.Length;

            point[0] = pointX;
            point[1] = pointY;

            return point;
        }

        public static string IsQinP(double[] pointCenter, double[] pointQ, double[][] pointsP) //на вход идет центр P , координаты точки Q и точки многоугольника
        {
        //сначала проверяем параллельны ли прямые
        //k1:=(x2-x1)/(y2-y1);
        //k2:= (x4 - x3) / (y4 - y3);
            double K1, K2;
            K1 = (pointQ[0] - pointCenter[0]) / (pointQ[1] - pointCenter[1]);
            //K2 = (pointQ[0] - pointCenter[0]) / (pointQ[1] - pointCenter[1]);
            for(int i=0;i < pointsP.Length-1; i++)
            {
               K2 =  (pointsP[i+1][0]- pointsP[i][0])/(pointsP[i + 1][1] - pointsP[i][1]);//складываем все точки X
                if (K1 != K2) //если прямые не параллельны
                {
                    
                        double X = -((pointCenter[0] *pointQ[1] - pointQ[0] * pointCenter[1]) * (pointsP[i + 1][0] - pointsP[i + 1][0]) - (pointsP[i ][0] * pointsP[i + 1][1] - pointsP[i + 1][0] * pointsP[i ][1]) * (pointQ[0] - pointCenter[0])) / ((pointQ[1] -pointCenter[1])* (pointsP[i + 1][0] - pointsP[i][0]) - ( pointsP[i ][1] - pointsP[i + 1][1]) * (pointsP[i+1][0] - pointsP[i ][0]));
                        double Y = ((pointsP[i][1] - pointsP[i + 1][1]) * (-X) - (pointsP[i][0] * pointsP[i + 1][1] - pointsP[i][0] * pointsP[i ][1])) / (pointsP[i + 1][1] -  pointsP[i + 1][0]);
                    Console.WriteLine("Отрезки пересекаются в точке ( { 0 } , { 1 } )", X, Y);


                }
                //(((x1<=x)and(x2>=x)and(x3<=x)and(x4>=x))or((y1<=y) and(y2>=y)and(y3<=y)and(y4>=y)))
            }



            return "да";
        }


    }

   
}
