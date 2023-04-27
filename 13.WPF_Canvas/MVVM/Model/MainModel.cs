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
            lineSeg1.Point = new System.Windows.Point(Width, Height - Radius);
            ArcSegment arcSegB = new ArcSegment();
            arcSegB.Point = new System.Windows.Point(Width - Radius, Height);   // ending cordinates of arcs
            arcSegB.Size = new System.Windows.Size(Radius, Radius);
            arcSegB.IsLargeArc = false;
            arcSegB.SweepDirection = SweepDirection.Clockwise;
            LineSegment lineSeg2 = new LineSegment();
            lineSeg2.Point = new System.Windows.Point(Radius, Height);
            ArcSegment arcSegC = new ArcSegment();
            arcSegC.Point = new System.Windows.Point(0, Height - Radius);   // ending cordinates of arcs
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
        public static PathGeometry GetWidthDimRectangle(int Width)
        {
            PathGeometry pathWidthGeometry = new PathGeometry();
            PathFigure pthFigure = new PathFigure();
            pthFigure.StartPoint = new System.Windows.Point(-10, 0);// starting cordinates of arcs
            LineSegment lineSegA = new LineSegment();
            lineSegA.Point = new System.Windows.Point(0, 0);
            LineSegment lineSegB = new LineSegment();
            lineSegB.Point = new System.Windows.Point(-7.5*Math.Sqrt(2)/2, 7.5 * Math.Sqrt(2)/2);            
            LineSegment lineSegC = new LineSegment();
            lineSegC.Point = new System.Windows.Point(7.5 * Math.Sqrt(2)/2, -7.5 * Math.Sqrt(2)/2);
            LineSegment lineSegD = new LineSegment();
            lineSegD.Point = new System.Windows.Point(0, 0);
            LineSegment lineSegE = new LineSegment();
            lineSegE.Point = new System.Windows.Point(Width, 0);
            LineSegment lineSegF = new LineSegment();
            lineSegF.Point = new System.Windows.Point(Width - 7.5 * Math.Sqrt(2)/2, 7.5 * Math.Sqrt(2)/2);
            LineSegment lineSegG = new LineSegment();
            lineSegG.Point = new System.Windows.Point(Width + 7.5 * Math.Sqrt(2)/2, -7.5 * Math.Sqrt(2)/2);
            LineSegment lineSegH = new LineSegment();
            lineSegH.Point = new System.Windows.Point(Width, 0);
            LineSegment lineSegI = new LineSegment();
            lineSegI.Point = new System.Windows.Point(Width + 10, 0);
            LineSegment lineSegJ = new LineSegment();
            lineSegJ.Point = new System.Windows.Point(Width, 0);
            LineSegment lineSegK = new LineSegment();
            lineSegK.Point = new System.Windows.Point(Width, 10);
            LineSegment lineSegL = new LineSegment();
            lineSegL.Point = new System.Windows.Point(Width, -30);
            LineSegment lineSegR = new LineSegment();
            lineSegR.Point = new System.Windows.Point(Width, 0);
            LineSegment lineSegT = new LineSegment();
            lineSegT.Point = new System.Windows.Point(0, 0);
            LineSegment lineSegU = new LineSegment();
            lineSegU.Point = new System.Windows.Point(0, 10);
            LineSegment lineSegS = new LineSegment();
            lineSegS.Point = new System.Windows.Point(0, -30);
            PathSegmentCollection myPathSegmentCollection = new PathSegmentCollection();
                myPathSegmentCollection.Add(lineSegA);
                myPathSegmentCollection.Add(lineSegB);
                myPathSegmentCollection.Add(lineSegC);
                myPathSegmentCollection.Add(lineSegD);
                myPathSegmentCollection.Add(lineSegE);
                myPathSegmentCollection.Add(lineSegF);
                myPathSegmentCollection.Add(lineSegG);
                myPathSegmentCollection.Add(lineSegH);
                myPathSegmentCollection.Add(lineSegI);
                myPathSegmentCollection.Add(lineSegJ);
                myPathSegmentCollection.Add(lineSegK);
                myPathSegmentCollection.Add(lineSegL);
                myPathSegmentCollection.Add(lineSegR);
                myPathSegmentCollection.Add(lineSegT);
                myPathSegmentCollection.Add(lineSegU);
                myPathSegmentCollection.Add(lineSegS);
            pthFigure.Segments = myPathSegmentCollection;
            PathFigureCollection pthFigureCollection = new PathFigureCollection();
            pthFigureCollection.Add(pthFigure);
            pathWidthGeometry.Figures = pthFigureCollection;
            return pathWidthGeometry;
            
        }
        public static PathGeometry GetHeightDimRectangle(int Height)
        {
            PathGeometry pathHeightGeometry = new PathGeometry();
            PathFigure pthFigure = new PathFigure();
            pthFigure.StartPoint = new System.Windows.Point(0, -10);// starting cordinates of arcs
            LineSegment lineSegA = new LineSegment();
            lineSegA.Point = new System.Windows.Point(0, 0);
            LineSegment lineSegB = new LineSegment();
            lineSegB.Point = new System.Windows.Point(-7.5 * Math.Sqrt(2) / 2, 7.5 * Math.Sqrt(2) / 2);
            LineSegment lineSegC = new LineSegment();
            lineSegC.Point = new System.Windows.Point(7.5 * Math.Sqrt(2) / 2, -7.5 * Math.Sqrt(2) / 2);
            LineSegment lineSegD = new LineSegment();
            lineSegD.Point = new System.Windows.Point(0, 0);
            LineSegment lineSegE = new LineSegment();
            lineSegE.Point = new System.Windows.Point(0, Height);
            LineSegment lineSegF = new LineSegment();
            lineSegF.Point = new System.Windows.Point(7.5 * Math.Sqrt(2) / 2, Height - 7.5 * Math.Sqrt(2) / 2);
            LineSegment lineSegG = new LineSegment();
            lineSegG.Point = new System.Windows.Point(-7.5 * Math.Sqrt(2) / 2, Height + 7.5 * Math.Sqrt(2) / 2);
            LineSegment lineSegH = new LineSegment();
            lineSegH.Point = new System.Windows.Point(0, Height);
            LineSegment lineSegI = new LineSegment();
            lineSegI.Point = new System.Windows.Point(0, Height+10);
            LineSegment lineSegJ = new LineSegment();
            lineSegJ.Point = new System.Windows.Point(0, Height);
            LineSegment lineSegK = new LineSegment();
            lineSegK.Point = new System.Windows.Point(-10, Height);
            LineSegment lineSegL = new LineSegment();
            lineSegL.Point = new System.Windows.Point(30, Height);
            LineSegment lineSegR = new LineSegment();
            lineSegR.Point = new System.Windows.Point(0, Height);
            LineSegment lineSegT = new LineSegment();
            lineSegT.Point = new System.Windows.Point(0, 0);
            LineSegment lineSegU = new LineSegment();
            lineSegU.Point = new System.Windows.Point(-10, 0);
            LineSegment lineSegS = new LineSegment();
            lineSegS.Point = new System.Windows.Point(30, 0);
            PathSegmentCollection myPathSegmentCollection = new PathSegmentCollection();
                myPathSegmentCollection.Add(lineSegA);
                myPathSegmentCollection.Add(lineSegB);
                myPathSegmentCollection.Add(lineSegC);
                myPathSegmentCollection.Add(lineSegD);
                myPathSegmentCollection.Add(lineSegE);
                myPathSegmentCollection.Add(lineSegF);
                myPathSegmentCollection.Add(lineSegG);
                myPathSegmentCollection.Add(lineSegH);
                myPathSegmentCollection.Add(lineSegI);
                myPathSegmentCollection.Add(lineSegJ);
                myPathSegmentCollection.Add(lineSegK);
                myPathSegmentCollection.Add(lineSegL);
                myPathSegmentCollection.Add(lineSegR);
                myPathSegmentCollection.Add(lineSegT);
                myPathSegmentCollection.Add(lineSegU);
                myPathSegmentCollection.Add(lineSegS);
            pthFigure.Segments = myPathSegmentCollection;
            PathFigureCollection pthFigureCollection = new PathFigureCollection();
            pthFigureCollection.Add(pthFigure);
            pathHeightGeometry.Figures = pthFigureCollection;
            return pathHeightGeometry;

        }
    }
}
