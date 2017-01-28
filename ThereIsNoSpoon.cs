using System;
using System.Linq;
using System.IO;
using System.Text;
using System.Collections;
using System.Collections.Generic;

/**
 * Don't let the machines win. You are humanity's last hope...
 **/

public class Dot
{
    public int dotX { get; set; }
    public int dotY { get; set; }

    public int rightX { get; set; }
    public int rightY { get; set; }

    public int bottomX { get; set; }
    public int bottomY { get; set; }

    public Dot(int x, int y)
    {
        dotX = x;
        dotY = y;
    }
}
public class Player
{
    public static void Main(string[] args)
    {
        int width = int.Parse(Console.ReadLine()); // the number of cells on the X axis
        int height = int.Parse(Console.ReadLine()); // the number of cells on the Y axis
        List<Dot> dot = new List<Dot>();
        for (int i = 0; i < height; i++)
        {
            string line = Console.ReadLine(); // width characters, each either 0 or .
            
            int x = GetNextDot(line, 0);
            while (x != -1)
            {
                x = GetNextDot(line, x);
                dot.Add(new Dot(x, i));
                x = GetNextDot(line, x + 1);
            };
            
        }
        dot.ForEach(
            d => {
                var rightNeighbour = dot.Where(w => w.dotX > d.dotX && w.dotY == d.dotY).OrderBy(o => o.dotX).FirstOrDefault();
                d.rightX = rightNeighbour == null ? -1 : rightNeighbour.dotX;
                d.rightY = rightNeighbour == null ? -1 : rightNeighbour.dotY;
                var bottomNeighbour = dot.Where(w => w.dotY > d.dotY && w.dotX== d.dotX).OrderBy(o => o.dotY).FirstOrDefault();
                d.bottomX = bottomNeighbour == null ? -1 : bottomNeighbour.dotX;
                d.bottomY = bottomNeighbour == null ? -1 : bottomNeighbour.dotY;
            }
            );
        dot.ForEach(d => Console.WriteLine(d.dotX + " " + d.dotY + " " + d.rightX + " " + d.rightY + " " + d.bottomX + " " + d.bottomY));
        // Write an action using Console.WriteLine()
        // To debug: Console.Error.WriteLine("Debug messages...");

    }

    public static int GetNextDot(string line, int start)
    {
        int retval = line.IndexOf('0',start);
        return retval;
    }
}
