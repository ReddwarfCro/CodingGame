using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

class Defib
{
    public int No { get; set; }
    public string Name { get; set; }
    public string Adress { get; set; }
    public string Phone { get; set; }
    public string Long { get; set; }
    public string Lat { get; set; }
    public double distance { get; set; }

    public Defib(int no, string name, string adress, string phone, string lng, string lat, double d)
    {
        No = no;
        Name = name;
        Adress = adress;
        Phone = phone;
        Long = lng;
        Lat = lat;
        distance = d;
    }

}
class Solution
{
    static void Main(string[] args)
    {
        string LON = Console.ReadLine().Replace(',', '.');  
        string LAT = Console.ReadLine().Replace(',', '.');  
        int N = int.Parse(Console.ReadLine());
        List<Defib> defibrillator = new List<Defib>(); 
        for (int i = 0; i < N; i++)
        {
            string DEFIB = Console.ReadLine();
            var defibArr = DEFIB.Split(';');
            var x = (Math.Abs(double.Parse(defibArr[4].Replace(',', '.')) - double.Parse(LON))) * (Math.Cos(Math.Abs((double.Parse(LAT) + double.Parse(defibArr[5].Replace(',', '.'))) / 2)));
            var y = (Math.Abs(double.Parse(defibArr[5].Replace(',', '.')) - double.Parse(LAT)));
            var d = Math.Sqrt(Math.Abs((x * 2) + (y * 2))) * 6371;
            defibrillator.Add(new Defib(int.Parse(defibArr[0]),defibArr[1], defibArr[2], defibArr[3], defibArr[4], defibArr[5], d));
        }

        Console.WriteLine(defibrillator.OrderBy(o => o.distance).FirstOrDefault().Name);
    }
}
