using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;
using System.Text.RegularExpressions;
using System.Text;
using System;

class Result
{

    /*
     * Complete the 'dynamicArray' function below.
     *
     * The function is expected to return an INTEGER_ARRAY.
     * The function accepts following parameters:
     *  1. INTEGER n
     *  2. 2D_INTEGER_ARRAY queries
     */

    public static List<int> dynamicArray(int n, List<List<int>> queries)
    {
List<List<int>> sequences = new List<List<int>>(new List<int>[n]);
        for (int i = 0; i < n; i++)
        {
            sequences[i] = new List<int>();
        }

        int lastAnswer = 0;
        List<int> result = new List<int>();

        foreach (var query in queries)
        {
            int type = query[0];
            int x = query[1];
            int y = query[2];

            int seqIndex = (x ^ lastAnswer) % n;

            if (type == 1)
            {
                // Append y to the sequence at index seqIndex
                sequences[seqIndex].Add(y);
            }
            else if (type == 2)
            {
                 int size = sequences[seqIndex].Count;
                lastAnswer = sequences[seqIndex][y % size];
                result.Add(lastAnswer);
            }
        }

        return result;
    }

}

class Solution
{
    public static void Main(string[] args)
    {
        TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

        string[] firstMultipleInput = Console.ReadLine().TrimEnd().Split(' ');

        int n = Convert.ToInt32(firstMultipleInput[0]);

        int q = Convert.ToInt32(firstMultipleInput[1]);

        List<List<int>> queries = new List<List<int>>();

        for (int i = 0; i < q; i++)
        {
            queries.Add(Console.ReadLine().TrimEnd().Split(' ').ToList().Select(queriesTemp => Convert.ToInt32(queriesTemp)).ToList());
        }

        List<int> result = Result.dynamicArray(n, queries);

        textWriter.WriteLine(String.Join("\n", result));

        textWriter.Flush();
        textWriter.Close();
    }
}
