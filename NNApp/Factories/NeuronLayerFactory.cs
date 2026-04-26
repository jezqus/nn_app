using NNApp.Models;

namespace NNApp.Factories
{
    public class NeuronLayerFactory
    {
        public static NeuronLayer CreateNeuronLayer(int numberOfNeuronsInLayer, int inputLength, double bias, ActivationFunctionModel activationFunction, double learningFactor)
        {
            var layer = new NeuronLayer()
            {
                NeuronList = new List<Neuron>()
            };

            for (int i = 0; i < numberOfNeuronsInLayer; i++)
            {
                layer.NeuronList.Add(NeuronFactory.CreateNeuron(inputLength, bias, activationFunction, learningFactor));
            }

            return layer;
        }
    }
}
