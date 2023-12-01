using System.Runtime.CompilerServices;

namespace Lab5
{
    public class Point
    {
        // Поля класса (свойства)
        private double x;
        private double y;
        // Конструктор класса
        public Point(double x, double y)
        {
            this.x = x;
            this.y = y;
        }

        // Методы класса
        public double ComputeDistance(Point point)
        {
            return Math.Sqrt(Math.Pow(point.x - this.x, 2) + Math.Pow(point.y - this.y, 2));
        }


        // Перегрузка метода ToString
        public override string ToString()
        {
            return $"x: {this.x}, y: {this.y}";
        }

    }

    internal class Task2
    {
        public static double ReadAndCheckUserInput(string var)
        {
            bool success = false;
            double number = 0;
            while (!success)
            {   
                Console.Write($"Enter {var}: ");
                success = double.TryParse(Console.ReadLine(), out number);
                if (!success)
                {
                    Console.Write($"Wrong input. Try again.\n");
                }
            }

            return number;

        }

        public static void Run()
        {
            Console.WriteLine("Enter x and y for the first point: ");
            Point point1 = new Point(ReadAndCheckUserInput("x"), ReadAndCheckUserInput("y"));
            Console.WriteLine($"First point has the following coordinates: {point1.ToString()}\n");

            Console.WriteLine("Enter x and y for the second point: ");
            Point point2 = new Point(ReadAndCheckUserInput("x"), ReadAndCheckUserInput("y"));
            Console.WriteLine($"Second point has the following coordinates: {point2.ToString()}\n");

            double distanceBetweenPoints = point1.ComputeDistance(point2);
            Console.WriteLine($"Distance between points: {distanceBetweenPoints:F3}");
        }
    }
}