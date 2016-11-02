using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

class Solution
{

    static void Main(string[] args)
    {
        int N = int.Parse(Console.ReadLine()); // Number of elements which make up the association table.
        int Q = int.Parse(Console.ReadLine()); // Number Q of file names to be analyzed.

        Dictionary<string, string> fileExtension = new Dictionary<string, string>();

        for (int i = 0; i < N; i++)
        {
            string[] inputs = Console.ReadLine().Split(' ');
            string EXT = inputs[0].ToLower(); // file extension
            string MT = inputs[1]; // MIME type.
            fileExtension.Add(EXT, MT);
        }
        for (int i = 0; i < Q; i++)
        {
            string FNAME = Console.ReadLine().ToLower(); // One file name per line.
            var lastind = FNAME.LastIndexOf('.');

            if (lastind > -1)
            {
                var fileext = FNAME.Substring(lastind + 1);
                string ext;
                fileExtension.TryGetValue(fileext, out ext);
                Console.WriteLine(fileExtension.ContainsKey(fileext) ? ext: "UNKNOWN");
            }
            else
            {
                Console.WriteLine("UNKNOWN");
            }

        }

    }
}
