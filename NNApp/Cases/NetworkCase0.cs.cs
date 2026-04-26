using NNApp.Models;
using NNApp.Factories;
using NNApp.Repositories;

namespace NNApp
{
    public static class NetworkCase0
    {
        public static void Execute()
        {
            Console.WriteLine("NN APP create simple network");
            Console.WriteLine("Binary clasyfication is on last charcter 1");

            NetworkBuilder builder = new NetworkBuilder();
            var network = builder.AddInputLayer(1, 5, 0, ActivationFunctionsRepository.StepFunction(), 0.2)
                .Build();

            Console.WriteLine(network.ToString());

            double[][] input = new double[8][]
            {
                new double[] { 0, 0, 0, 0, 1, 1 },
                new double[] { 1, 0, 0, 0, 0, 0 },
                new double[] { 1, 0, 0, 0, 1, 1 },
                new double[] { 0, 1, 0, 0, 1, 1 },
                new double[] { 0, 0, 1, 0, 0, 0 },
                new double[] { 0, 0, 1, 0, 1, 1 },
                new double[] { 0, 0, 0, 1, 0, 0 },
                new double[] { 0, 0, 0, 1, 1, 1 }
            };


            for (int j = 0; j < 100; j++)
            {
                for (int i = 0; i < 8; i++)
                {
                    network.Train(input[i][..5], [input[i][5]]);
                }
            }

            Console.WriteLine(network.ToString());

            ExecuteEntry(network, [0, 0, 0, 1, 0]);
            ExecuteEntry(network, [0, 1, 0, 0, 0]);
            ExecuteEntry(network, [0, 0, 1, 0, 0]);
            ExecuteEntry(network, [1, 0, 0, 1, 0]);   
            ExecuteEntry(network, [0, 0, 0, 0, 1]);
            ExecuteEntry(network, [0, 0, 1, 0, 1]);
            ExecuteEntry(network, [0, 1, 0, 0, 1]);
            Console.ReadKey();
        }

        private static void ExecuteEntry(Network network, double[] input)
        {
            input.ToList().ForEach(item => Console.Write($"{item}|"));
            
            var result = network.Execute(input);

            Console.WriteLine($" => {result[0]}");
        }
    }
}
