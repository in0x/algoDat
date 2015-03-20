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

        canvas.addGeometryObject(rectangle);
        canvas.addGeometryObject(square);
        canvas.addGeometryObject(circle);
        Console.WriteLine(canvas.output() + "\n\n");

        Canvas cv1 = new Canvas("blue", new Vector(0,0), 500, 500);
        Circle c2 = new Circle(200, "yellow", new Vector(100, 100));
        Circle c3 = new Circle(150, "yellow", new Vector(300, 400));
        cv1.addGeometryObject(c2);
        cv1.addGeometryObject(c3);
        Console.WriteLine(cv1.output() + "\n\n");

        Canvas cv2 = new Canvas("black", new Vector(0,0), 1000, 1000);
        Square s2 = new Square(300, "red", new Vector(300,300));
        Square s3 = new Square(200, "red", new Vector(500,500));
        Square s4 = new Square(150, "red", new Vector(600,600));
        Square s5 = new Square(100, "red", new Vector(700,700));
        cv2.addGeometryObject(s2);
        cv2.addGeometryObject(s3);
        cv2.addGeometryObject(s4);
        cv2.addGeometryObject(s5);
        Console.WriteLine(cv2.output());
    }
}