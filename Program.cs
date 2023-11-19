using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
namespace Лр4_2
{
    public class Triangle
    {
        protected double x1;
        protected double x2;
        protected double x3;
        protected double p;
        //Конструктор
        public Triangle(double x1, double x2, double x3)
        {
            this.x1 = x1;
            this.x2 = x2;
            this.x3 = x3;
        }
        //висновок значень полів на екран
        public void Print()
        {
            Console.WriteLine("a={0} b={1} c={2}", x1, x2, x3);
        }
        //знаходження периметра трикутника
        public double Perimeter()
        {
            double p = x1 + x2 + x3;
            return p;
        }
        //знаходження площі трикутника за формулою Герона
        virtual public double Sqr()
        {
            double p = (x1 + x2 + x3) / 2;
            double s = Math.Sqrt(p * (p - x1) * (p - x2) * (p - x3));
            return s;
        }
        //умова існування трикутника
        static bool Exists(double x1, double x2, double x3)
        {
            return x1 + x2 > x3 && x1 + x3 > x2 && x2 + x3 > x1;
        }
        public class Equilateral : Triangle
        {
            public Equilateral(double x1, double x2, double x3) : base(x1, x2, x3) { }
            public override double Sqr()
            {
                int s = (int)(Math.Sqrt(3) / 4 * Math.Pow(x1, 2));
                return s;
            }
            public double Radius()
            {
                double r = x1 / (2 * Math.Sqrt(3));
                return r;
            }
        }
        internal class Program
        {
            static void Main(string[] args)
            {
                double p, s, r = 0;
                double x1, x2, x3;
                Random random = new Random();
                //Через цикл задаємо значення сторін
                for (int i = 0; i < 3; i++)
                {
                    x1 = random.Next(1, 11); // випадкова довжина першої сторони від 1 до 10
                    x2 = random.Next(1, 11); // випадкова довжина другої сторони від 1 до 10
                    x3 = random.Next(1, 11); // випадкова довжина третьої сторони від 1 до 10
                    Triangle t;
                    //Виконується коли трикутник рівносторонній
                    if (x1 == x2)
                    {
                        //привласнюємо цій змінній об'єкт дочірнього класу
                        t = new Equilateral(x1, x2, x3);
                        //цей об'єкт потрібний, щоб викликати власний
                        //метод Radius із дочірнього класу
                        Equilateral t1 = new Equilateral(x1, x2, x3);
                        r = t1.Radius();
                    }
                    //Виконується коли трикутник не рівносторонній
                    else
                    {
                        //привласнюємо цей змінний об'єкт батьківського класу
                        t = new Triangle(x1, x2, x3);
                    }
                    t.Print(); p = t.Perimeter();
                    s = t.Sqr();
                    //Виводиться рівносторонній трикутник
                    if (x1 == x2)
                        Console.WriteLine("R={0:F2} \nS={1:F3} \nP={2}", r, s, p);
                    //Виводиться не рівносторонній трикутник
                    else
                    {
                        Console.WriteLine("P={0} \nS={1:F3}", p, s);
                    }
                    //Якщо трикутник існує
                    if (Exists(x1, x2, x3))
                    {
                        Console.WriteLine("Трикутник iснує.");
                    }
                    //Якщо трикутник не існує
                    else
                    {
                        Console.WriteLine("Трикутник не iснує.");
                    }
                    Console.ReadKey();
                }
            }
        }
    }
}
