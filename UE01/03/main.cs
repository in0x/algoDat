using System;
using GO;
using myVector;
using System.Collections.Generic;

class MainClass
{
    static void Main()
    {
		Canvas canvas = new Canvas("yellow", new Vector(300,100), 600, 200);
        Rectangle rectangle = new Rectangle(80, 40, "blue", new Vector(100,100));
        Square square = new Square(100, "green", new Vector(300,100));
        Circle circle = new Circle(60, "red", new Vector(500,100));

        //Console.WriteLine(rectangle.draw());
        //Console.WriteLine(square.draw());
        //Console.WriteLine(circle.draw());

        canvas.addGeometryObject(rectangle);
        canvas.addGeometryObject(square);
        canvas.addGeometryObject(circle);
        Console.WriteLine(canvas.output());
    }
}