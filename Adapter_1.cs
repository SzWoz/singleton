using System;

namespace ConsoleApp4
{
    interface IShapeAdapter
    {
        double GetArea();
    }

    class Square
    {
        private double side;

        public Square(double side)
        {
            this.side = side;
        }

        public double GetSide()
        {
            return side;
        }
    }

    class Adapter : IShapeAdapter
    {
        private Square square;

        public Adapter(Square square)
        {
            this.square = square;
        }

        public double GetArea()
        {
            double side = square.GetSide();
            return side * side;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Square square = new Square(5);
            Adapter adapter = new Adapter(square);

            Function(adapter); 
        }

        static void Function(IShapeAdapter shape)
        {
            double area = shape.GetArea();
            Console.WriteLine("Obszar kształtu wynosi: " + area);
        }
    }
}
