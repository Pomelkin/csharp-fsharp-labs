using System;
using System.Drawing;

namespace Lab5
{
    public class Point3D
    {
        // Поля класса (свойства)
        protected int x;
        protected int y;
        protected int z;

        // Конструктор класса
        public Point3D(int x, int y, int z)
        {
            this.x = x;
            this.y = y;
            this.z = z;
        }

        //Конструктор копирования
        public Point3D(Point3D point)
        {
            this.x = point.x;
            this.y = point.y;
            this.z = point.z;
        }

        // Методы класса
        public int FindMax()
        {
            if (this.x > this.y){
                if (this.x > this.z){
                    return x;
                }
                else{
                    return z;
                }
            }

            else{
                if (this.y > this.z){
                    return y;
                }
                else{
                    return z;
                }
            }
        }

        // Перегрузка метода ToString
        public override string ToString()
        {
            return $"x: {this.x}, y: {this.y}, z: {this.z}";
        }
    }

    public class ColoredPoint3D : Point3D
    {
        protected Color color;

        public ColoredPoint3D(int x, int y, int z, Color color) : base(x, y, z)
        {
           this.color = color;
        }

        // Методы класса
        public void ChangeColorToRandom()
        {
            Console.WriteLine("\n--Changing color to random--");
            Random random = new Random();
            this.color = Color.FromArgb(random.Next(256), random.Next(256), random.Next(256));
        }
        
        public void MovePointTo(int newX, int newY, int newZ)
        {
            Console.WriteLine($"\n--Moving point from ({this.x}, {this.y}, {this.z}) to ({newX}, {newY}, {newZ})--");
            this.x = newX;
            this.y = newY;
            this.z = newZ;
        }


        // Перегрузка метода ToString
        public override string ToString()
        {
            return $"x: {this.x}, y: {this.y}, z: {this.z}, color: {this.color.R}, {this.color.G}, {this.color.B}";
        }

    }

    internal class Task1
    {
        public static void Run()
        {
            Random random = new Random();
            Console.WriteLine("--Point3D--");
            // -- Создание объектов класса 2 способами и проверка перегрузки метода ToString --
            Point3D point = new Point3D(random.Next(1,20), random.Next(1,20), random.Next(1,20));
            Console.WriteLine($"Point: {point.ToString()}");

            Point3D pointCopy = new Point3D(point);
            Console.WriteLine($"PointCopy: {pointCopy.ToString()}");

            // -- Проверка максимального значения поля --
            int max = point.FindMax();
            Console.WriteLine($"Max - {max}");

            max = pointCopy.FindMax();
            Console.WriteLine($"Max of Copy - {max}");

            // -- Создание нового экземпляра класса ColoredPoint3D - Дочернего класса Point3D --
            Console.WriteLine("\n--ColoredPoint3D--");
            ColoredPoint3D coloredPoint = new ColoredPoint3D(random.Next(1,20), random.Next(1,20), random.Next(1,20), Color.FromArgb(random.Next(256), random.Next(256), random.Next(256)));
            Console.WriteLine(coloredPoint.ToString());

            // -- Проверка метода ChangeColorToRandom --
            coloredPoint.ChangeColorToRandom();
            Console.WriteLine(coloredPoint.ToString());

            // -- Проверка метода MovePointTo --
            coloredPoint.MovePointTo(random.Next(1,100), random.Next(1,100), random.Next(1,100));
            Console.WriteLine(coloredPoint.ToString());
        }
    }
   
}