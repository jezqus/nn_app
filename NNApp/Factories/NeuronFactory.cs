using NNApp.Models;

namespace NNApp.Factories
{
    public static class NeuronFactory
    {
        public static Neuron CreateNeuron(int inputLength, double bias, ActivationFunctionModel activationFunction, double learningFactor)
        {
            var newNeuron = new Neuron()
            {
                Weights = new double[inputLength],
                Bias = bias,
                ActivationFunctionContainer = activationFunction,
                LearningFactor = learningFactor
            };

            Random random = new Random();
            for (int i = 0; i < newNeuron.Weights.Length; i++)
            {
                newNeuron.Weights[i] = (double)random.Next(-10, 10) / 5; // taki test
            }

            return newNeuron;
        }
    }
}
