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
            var circle = new Circle(10, new Point(20, 100));
            circle.Draw();

            var circle2 = new Circle(5, new Point(50, 60));
            circle2.Draw();

            //var a = Math.PI * Math.Pow(circle2.GetRadius(), 2) ;

            var area = circle2.GetArea();
            area = circle.GetArea();

        }
    }
}
