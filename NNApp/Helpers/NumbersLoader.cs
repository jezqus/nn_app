using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace NNApp
{
    public static class NumbersLoader
    {
        public static double[] LoadNumberExample(int number)
        {
            double[] result = new double[16];

            string fileContent = System.IO.File.ReadAllText($"../../../Numbers/{number}.txt");

            for (int i = 0; i < 15; i++)
            {
                result[i] = Convert.ToDouble($"{fileContent[i]}");
            }

            return result;
        }
    }
}
