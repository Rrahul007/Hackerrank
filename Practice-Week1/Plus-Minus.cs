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
     * Complete the 'plusMinus' function below.
     *
     * The function accepts INTEGER_ARRAY arr as parameter.
     */

    public static void plusMinus(List<int> arr)
    {
      float zratio;
      float posratio;
      float negratio;
      zratio=posratio=negratio=0;
      
      for(int i=0;i<arr.Count;i++)
      {
        if(arr[i]>0)
          ++posratio;
        else if (arr[i]<0)
          ++negratio;
        else
          ++zratio;
      }
      
      Console.WriteLine("{0:F6}",posratio/arr.Count);
      Console.WriteLine("{0:F6}",negratio/arr.Count);
      Console.WriteLine("{0:F6}",zratio/arr.Count);
    }
  
}

class Solution
{
    public static void Main(string[] args)
    {
        int n = Convert.ToInt32(Console.ReadLine().Trim());

        List<int> arr = Console.ReadLine().TrimEnd().Split(' ').ToList().Select(arrTemp => Convert.ToInt32(arrTemp)).ToList();

        Result.plusMinus(arr);
    }
}
