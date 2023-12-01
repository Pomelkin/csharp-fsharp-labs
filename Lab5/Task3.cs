using System.Runtime.CompilerServices;

namespace Lab5
{
    public class Point1
    {
        // Поля класса (свойства)
        private double x;
        private double y;

        // Конструктор класса
        public Point1(double x, double y)
        {
            this.x = x;
            this.y = y;
        }

        // Методы класса

        public static Point1 operator ++(Point1 a)
        {
            return new Point1(a.x + 1, a.y);
        }

        public static Point1 operator --(Point1 a)
        {
            return new Point1(a.x - 1, a.y);
        }

        public static explicit operator int(Point1 a) => (int) a.x;
        public static implicit operator double(Point1 a) => a.y;

        public static double operator +(Point1 p1, Point1 p2)
        {
            return Math.Sqrt(Math.Pow(p2.x - p1.x, 2) + Math.Pow(p2.y - p1.y, 2));
        }

        public static Point1 operator +(Point1 p, int n)
        {   
            return new Point1(p.x + n, p.y);;
        }

        public static Point1 operator +(int n, Point1 p)
        {
            return p + n;
        }


        // Перегрузка метода ToString
        public override string ToString()
        {
            return $"x: {this.x}, y: {this.y}";
        }

    }

    internal class Task3
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
            Point1 point1 = new Point1(ReadAndCheckUserInput("x"), ReadAndCheckUserInput("y"));
            Console.WriteLine($"First point has the following coordinates: {point1.ToString()}\n");

            Console.WriteLine("Enter x and y for the second point: ");
            Point1 point2 = new Point1(ReadAndCheckUserInput("x"), ReadAndCheckUserInput("y"));
            Console.WriteLine($"Second point has the following coordinates: {point2.ToString()}\n\n");

           Console.WriteLine("---Unary operations---\n");
           point1++;
           Console.WriteLine($"First point after increment: {point1.ToString()}");
           point2--;
           Console.WriteLine($"Second point after decrement: {point2.ToString()}\n\n");

           Console.WriteLine("---Type Conversion Operations---\n");
           int x = (int)point1;
           Console.WriteLine($"Explicit conversion from Point1 (int x = (int)point1); X of first point = {x}");
           double y = point2;
           Console.WriteLine($"Implicit conversion from Point2 (double y = point2); Y of second point = {y}\n\n");

           Console.WriteLine("---Binary operations---\n");
           Console.WriteLine($"The distance between the points is (point1 + point2): {point1 + point2}");
           Console.WriteLine($"The coordinates of the first point plus 5 (point1 + 5) is: {(point1 + 5).ToString()}");
           Console.WriteLine($"The coordinates of the second point plus 3 (3 + point2) is: {(3 + point2).ToString()}");
        }
    }
}