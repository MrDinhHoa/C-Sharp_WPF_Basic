using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using System.Windows.Shapes;

namespace _13.WPF_Canvas.MVVM.Model
{
    class MainModel
    {
        public static PathGeometry GetStirrupPath(int Width, int Height, int Radius)
        {
            PathGeometry stirrupPath = new PathGeometry();
                PathFigure pthFigure = new PathFigure();
                    pthFigure.StartPoint = new System.Windows.Point(Width - Radius - Radius * Math.Sqrt(2) / 1.5, Radius * Math.Sqrt(2) / 1.5);// starting cordinates of arcs
                LineSegment lineSegA = new LineSegment();
                    lineSegA.Point = new System.Windows.Point(Width - Radius, 0);
                ArcSegment arcSegA = new ArcSegment();
                    arcSegA.Point = new System.Windows.Point(Width, Radius);   // ending cordinates of arcs
                    arcSegA.Size = new System.Windows.Size(Radius, Radius);
                    arcSegA.IsLargeArc = false;
                    arcSegA.SweepDirection = SweepDirection.Clockwise;
                LineSegment lineSeg1 = new LineSegment();
                    lineSeg1.Point = new System.Windows.Point(Width, Height-Radius);
                ArcSegment arcSegB = new ArcSegment();
                    arcSegB.Point = new System.Windows.Point(Width-Radius, Height);   // ending cordinates of arcs
                    arcSegB.Size = new System.Windows.Size(Radius, Radius);
                    arcSegB.IsLargeArc = false;
                    arcSegB.SweepDirection = SweepDirection.Clockwise;
                LineSegment lineSeg2 = new LineSegment();
                    lineSeg2.Point = new System.Windows.Point(Radius, Height);
                ArcSegment arcSegC = new ArcSegment();
                    arcSegC.Point = new System.Windows.Point(0, Height-Radius);   // ending cordinates of arcs
                    arcSegC.Size = new System.Windows.Size(Radius, Radius);
                    arcSegC.IsLargeArc = false;
                    arcSegC.SweepDirection = SweepDirection.Clockwise;
                LineSegment lineSeg3 = new LineSegment();
                    lineSeg3.Point = new System.Windows.Point(0, Radius);
                ArcSegment arcSegD = new ArcSegment();
                    arcSegD.Point = new System.Windows.Point(Radius, 0);   // ending cordinates of arcs
                    arcSegD.Size = new System.Windows.Size(Radius, Radius);
                    arcSegD.IsLargeArc = false;
                    arcSegD.SweepDirection = SweepDirection.Clockwise;
                LineSegment lineSeg4 = new LineSegment();
                    lineSeg4.Point = new System.Windows.Point(Width - Radius, 0);
                LineSegment lineSegB = new LineSegment();
                    lineSegB.Point = new System.Windows.Point(Width - Radius * Math.Sqrt(2) / 1.5, Radius + Radius * Math.Sqrt(2) / 1.5);

            PathSegmentCollection myPathSegmentCollection = new PathSegmentCollection();
                myPathSegmentCollection.Add(lineSegA);
                myPathSegmentCollection.Add(arcSegA);
                myPathSegmentCollection.Add(lineSeg1);
                myPathSegmentCollection.Add(arcSegB);
                myPathSegmentCollection.Add(lineSeg2);
                myPathSegmentCollection.Add(arcSegC);
                myPathSegmentCollection.Add(lineSeg3);
                myPathSegmentCollection.Add(arcSegD);
                myPathSegmentCollection.Add(lineSeg4);
                myPathSegmentCollection.Add(arcSegA);
                myPathSegmentCollection.Add(lineSegB);
                pthFigure.Segments = myPathSegmentCollection;
            PathFigureCollection pthFigureCollection = new PathFigureCollection();
                pthFigureCollection.Add(pthFigure);
            stirrupPath.Figures = pthFigureCollection;
            
            return stirrupPath;
        }
    }
}
