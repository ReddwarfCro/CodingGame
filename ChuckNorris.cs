using System;
using System.Linq;
using System.Text;

/**
 * Auto-generated code below aims at helping you parse
 * the standard input according to the problem statement.
 **/
class Solution
{

    public static byte[] ConvertToByteArray(string str, Encoding encoding)
    {
        return encoding.GetBytes(str);
    }

    public static String ToBinary(Byte[] data)
    {
        return string.Join(" ", data.Select(byt => Convert.ToString(byt, 2).PadLeft(7, '0')));
    }

    public static String GetNorrisCode(string msg)
    {
        char[] msgArray = msg.ToCharArray();
        string result = "";
        string prefix = "";

        for (int i = 0; i < msgArray.Length; i++)
        {
            string innerPrefix = msg[i].ToString() == "1" ? "0 " : "00 ";
            result = result + (innerPrefix != prefix ? (prefix != "" ? " " : "") + innerPrefix : "") + "0";
            prefix = innerPrefix;
        }

        return result;
    }

    static void Main(string[] args)
    {
        string MESSAGE = Console.ReadLine();

        // Write an action using Console.WriteLine()
        // To debug: Console.Error.WriteLine("Debug messages...");
        // Use any sort of encoding you like. 
        var binaryString = ToBinary(ConvertToByteArray(MESSAGE, Encoding.ASCII));


        Console.WriteLine(GetNorrisCode(binaryString.Replace(" ", "")));

    }
}