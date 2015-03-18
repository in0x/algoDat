using System;
using myVector;
using System.Collections.Generic;

namespace GO
{
    public abstract class GeometryObject
    {
        public string color {get; internal set;}
        public Vector center {get; internal set;}

        public GeometryObject(string _color, Vector _center)
        {
            color = _color;
            center = _center;
        }

        public virtual string draw() { return ""; }
    }

    public class Rectangle : GeometryObject
    {
        public double width;
        public double height;

        public Rectangle(double _width, double _height, string _color, Vector _center) : base(_color, _center) 
        {
            width = _width;
            height = _height;
        }

        public override string draw()
        {
            double[] points = getPoints();
            return "fill " + this.color + " rectangle " + points[0] + "," + points[1] + " " + points[2] + "," +  points[3];
        }

        //Returns coordinates of upper left and lower rigth point
            //[0] leftUpper:x
            //[1] leftUpper:y
            //[2] rightLower:x
            //[3] rightLower:y
        public double[] getPoints() {
            double[] points = new double[4];
            double xOffset = this.width/2;
            double yOffset = this.height/2;
            points[0] = (this.center.x - xOffset);
            points[1] = (this.center.y - yOffset);
            points[2] = (this.center.x + xOffset);
            points[3] = (this.center.y + yOffset);
            return points;  
        }

    }

    public class Circle : GeometryObject
    {
        double radius;

        public Circle(double _radius, string _color, Vector _center) : base(_color, _center) {
            radius = _radius;
        }

        //points[0] = xc;
        //points[1] = xy;
        //points[2] = xc + radius;
        public double[] getPoints() {
            double[] points = new double[3];
            points[0] = this.center.x;
            points[1] = this.center.y;
            points[2] = this.center.x + radius;
            return points;
        }

        public override string draw()
        {
            double[] points = getPoints();
            return "fill " + this.color + " circle " + points[0] + "," + points[1] + " " + points[2] + "," + points[1]; 
        }
    }

    public class Square : GeometryObject
    {
        double width;

        public Square(double _width, string _color, Vector _center) : base(_color, _center) {
            width = _width;
        }

        public override string draw()
        {
            double[] points = getPoints();
            return "fill " + this.color + " rectangle " + points[0] + "," + points[1] + " " + points[2] + "," +  points[3]; 
        }

        public  double[] getPoints() {
            double[] points = new double[4];
            double Offset = this.width/2;
            points[0] = (this.center.x - Offset);
            points[1] = (this.center.y - Offset);
            points[2] = (this.center.x + Offset);
            points[3] = (this.center.y + Offset);
            return points;  
        }

    }

    public class Canvas : GeometryObject { 
        
        private List<GeometryObject> objectList;
        private Vector center;
        private double height;
        private double width;

        public Canvas(string _color, Vector _center, double _width, double _height) : base(_color, _center) { 
            objectList = new List<GeometryObject>();
            height = _height;
            width = _width;
            center = _center;
        }

        public void addGeometryObject(GeometryObject g) {
            objectList.Add(g);
        }

        public string output() {
            string[] objectStrings = new string[objectList.Count];
            for (int i = 0; i < objectList.Count; i++) {
                objectStrings[i] = objectList[i].draw();
            }
            string output = "convert -size " + this.width + "x" + this.height + " xc:transparent -draw \"fill " + this.color + " rectangle 0,0 " + this.width + "," + this.height + " ";
            foreach(string s in objectStrings) {
                output += s + " ";
            }
            output += "\"";
            return output;
        }
    }
}
