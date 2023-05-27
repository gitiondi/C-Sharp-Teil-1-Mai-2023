public class DPoint
{
    public int X; 
    public int Y;
}

public class DTriangle
{
    public DPoint A;
    public DPoint B;
    public DPoint C;
}

public class CoordinatesTransformation
{
    public DPoint Scale(DPoint pointBefore, int scaleFactor)
    {
        int xAfter = pointBefore.X * scaleFactor;
        int yAfter = pointBefore.Y * scaleFactor;
        DPoint pointAfter = new DPoint();
        pointAfter.X = xAfter;
        pointAfter.Y = yAfter;
        return pointAfter;
    }

    public DPoint ReverseY(DPoint pointBefore, int maxY)
    {
        int yAfter = maxY - pointBefore.Y;
        DPoint pointAfter = new DPoint();
        pointAfter.X = pointBefore.X;
        pointAfter.Y = yAfter;
        return pointAfter;
    }

    public DPoint TransForm(DPoint pointBefore, int scaleFactor, int maxY)
    {
        DPoint pointAfterScaling = Scale(pointBefore, scaleFactor);
        DPoint pointAfterReversing = ReverseY(pointAfterScaling, maxY);
        return pointAfterReversing;
    }

}

public class Program
{
    const int scaleFactor = 56;
    const int maxY = scaleFactor * 10;

    static void Main()
    {
        DPoint A = new DPoint();
        A.X = 2; A.Y = 3;

        DPoint B = new DPoint();
        B.X = 14; B.Y = 5;

        DPoint C = new DPoint();
        C.X = 6; C.Y = 9;

        DTriangle triangle = new DTriangle();
        triangle.A = A;
        triangle.B = B;
        triangle.C = C;

        //todo test
        DPoint testPoint = new DPoint();
        testPoint.X = 18; testPoint.Y = 10;
        CoordinatesTransformation ct = new CoordinatesTransformation();
        DPoint testPointAfterScaling = ct.Scale(testPoint, scaleFactor);
        DPoint testPointAfterReversing = ct.ReverseY(testPointAfterScaling, maxY);
        DPoint afterTransForming = ct.TransForm(testPoint, scaleFactor, maxY);

        // todo real calcs

        DPoint Atr = ct.TransForm(A, scaleFactor, maxY);
        DPoint Btr = ct.TransForm(B, scaleFactor, maxY);
        DPoint Ctr = ct.TransForm(C, scaleFactor, maxY);


        int a = 42;

        using (StreamWriter writetext = new StreamWriter("d:\\tmp\\delete_me\\write.html", false))
        {
            writetext.WriteLine("<!DOCTYPE html>");
            writetext.WriteLine("<html>");
            writetext.WriteLine("<body>");
            writetext.WriteLine("");
            writetext.WriteLine("<svg width=\"1000\" height=\"560\" style=\"background-color: lightskyblue;\">");
            //writetext.WriteLine("  <polygon points=\"200, 10 250, 190 160, 210\" style=\"fill: lime; stroke: purple; stroke - width:1\" />");
            writetext.WriteLine($"  <polygon points=\"{Atr.X}, {Atr.Y} {Btr.X}, {Btr.Y} {Ctr.X}, {Ctr.Y}\" style=\"fill: lime; stroke: purple; stroke - width:1\" />");
            writetext.WriteLine("  Sorry, your browser does not support inline SVG.");
            writetext.WriteLine("</svg>");
            writetext.WriteLine("");
            writetext.WriteLine("</body>");
            writetext.WriteLine("</html>");
        }
    }
}
