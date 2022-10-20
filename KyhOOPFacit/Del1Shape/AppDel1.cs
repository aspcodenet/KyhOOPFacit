using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KyhOOPFacit.Del1Shape
{
    internal class AppDel1
    {
        public void Run()
        {
            var listOfGameObjects = new List<Shape>();
            var circle = new Circle(10, new Point(20, 100));
            listOfGameObjects.Add(circle);

            var circle2 = new Circle(5, new Point(50, 60));
            listOfGameObjects.Add(circle2);

            //var area = circle2.GetArea();
            //area = circle.GetArea();

            var rect = new Rectangle(20, 100, new Point(30, 30));
            listOfGameObjects.Add(rect);

            var rect2 = new Rectangle(200, 10, new Point(80, 450));
            listOfGameObjects.Add(rect2);

            while (true)
            {
                foreach(var shape in listOfGameObjects)
                    shape.Draw();
                //om hopp på bla bla  listOfGameObjects.Add(new Circle--- )
                //om 100 poäng listOfGameObjects.Add(new Rectangle--- )
            }



        }
    }
}
