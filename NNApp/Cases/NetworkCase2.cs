using NNApp.Models;
using NNApp.Factories;
using NNApp.Repositories;
using System.Text;

namespace NNApp
{
    public static class NetworkCase2
    {
        public static void Execute()
        {
            Console.WriteLine("NN APP create simple network");
            Console.WriteLine("Numbers recognition in ASCII art from non-binary recognition expected correct in value(~).");

            NetworkBuilder builder = new NetworkBuilder();
            builder.AddInputLayer(60, 15, 0, ActivationFunctionsRepository.Line_1_12_Activation(), 0.2);
            
            builder.AddHiddenLayer(1, 0, ActivationFunctionsRepository.Line_1_12_Activation(), 0.2);

            var network = builder.Build();

            Console.WriteLine(network.ToString());

            double[][] input = new double[10][]
            {
                NumbersLoader.LoadNumberExample(0),
                NumbersLoader.LoadNumberExample(1),
                NumbersLoader.LoadNumberExample(2),
                NumbersLoader.LoadNumberExample(3),
                NumbersLoader.LoadNumberExample(4),
                NumbersLoader.LoadNumberExample(5),
                NumbersLoader.LoadNumberExample(6),
                NumbersLoader.LoadNumberExample(7),
                NumbersLoader.LoadNumberExample(8),
                NumbersLoader.LoadNumberExample(9),
            };

            Random rand = new Random(DateTime.Now.Millisecond);
            for (int j = 0; j < 6000; j++)
            {
                int index = rand.Next(0, 9);

                network.Train(input[index], [index]);
            }

            Console.WriteLine(network.ToString());

            Console.WriteLine(PrintResult(0, network.Execute(NumbersLoader.LoadNumberExample(0))));
            Console.WriteLine(PrintResult(1, network.Execute(NumbersLoader.LoadNumberExample(1))));
            Console.WriteLine(PrintResult(2, network.Execute(NumbersLoader.LoadNumberExample(2))));
            Console.WriteLine(PrintResult(3, network.Execute(NumbersLoader.LoadNumberExample(3))));
            Console.WriteLine(PrintResult(4, network.Execute(NumbersLoader.LoadNumberExample(4))));
            Console.WriteLine(PrintResult(5, network.Execute(NumbersLoader.LoadNumberExample(5))));
            Console.WriteLine(PrintResult(6, network.Execute(NumbersLoader.LoadNumberExample(6))));
            Console.WriteLine(PrintResult(7, network.Execute(NumbersLoader.LoadNumberExample(7))));
            Console.WriteLine(PrintResult(8, network.Execute(NumbersLoader.LoadNumberExample(8))));
            Console.WriteLine(PrintResult(9, network.Execute(NumbersLoader.LoadNumberExample(9))));

            Console.ReadKey();
        }

        private static double[] GetResult(int i)
        {
            return [i];
        }

        private static string PrintResult(int expectedResult, double[] result)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append($"{expectedResult} => (");
            foreach (double i in result)
            {
                sb.Append($"{i:0.##}|");
            }
            sb.AppendLine(")");

            return sb.ToString();
        }
    }
}
