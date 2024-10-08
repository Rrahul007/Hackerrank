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
     * Complete the 'caesarCipher' function below.
     *
     * The function is expected to return a STRING.
     * The function accepts following parameters:
     *  1. STRING s
     *  2. INTEGER k
     */

    public static string caesarCipher(string s, int k)
    {
        string answer = "";
        
        foreach(var c in s)
        {
            if(!((c >= 'a' && c <= 'z')||(c >= 'A' && c <= 'Z')))
            {
                answer += c;
            }
            else
            {
                var c1 = c.ToString().ToLower()[0];
                c1 += (char) (k % 26);
                
                if(c1 > 'z')
                {
                    c1 -= (char) 26;
                }
                
                if(!(c >= 'a' && c <= 'z'))
                {
                    c1 = c1.ToString().ToUpper()[0];
                }
                answer += c1;
            }
        }
        return answer;
    }

}

class Solution
{
    public static void Main(string[] args)
    {
        TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

        int n = Convert.ToInt32(Console.ReadLine().Trim());

        string s = Console.ReadLine();

        int k = Convert.ToInt32(Console.ReadLine().Trim());

        string result = Result.caesarCipher(s, k);

        textWriter.WriteLine(result);

        textWriter.Flush();
        textWriter.Close();
    }
}
