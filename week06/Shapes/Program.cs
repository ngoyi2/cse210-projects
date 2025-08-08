using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        List<Shape> shapes = new List<Shape>();

        Square s1 = new Square("red", 5);
        shapes.Add(s1);

        Rectangle r1 = new Rectangle("blue", 4, 6);
        shapes.Add(r1);

        Circle c1 = new Circle("green", 3);
        shapes.Add(c1);

        // Iterate through the list of shapes and display their color and area
        foreach (Shape shape in shapes)
        {
            string color = shape.GetColor();
            double area = shape.GetArea();
            Console.WriteLine($"The {color} shape has an area of {area:F2}.");
        }
    }
}