using NNApp.Models;

namespace NNApp.Factories
{
    public class NetworkBuilder
    {
        private Network network = new Network();

        public NetworkBuilder AddInputLayer(int numberOfNeuronsInLayer, int inputLength, double bias, ActivationFunctionModel activationFunction, double learningFactor)
        {
            if (this.network.Layers.Count > 0)
            {
                throw new Exception("Cannot add input layer when other layers exists.");
            }

            this.network.Layers.Add(
                NeuronLayerFactory.CreateNeuronLayer(numberOfNeuronsInLayer, inputLength, bias, activationFunction, learningFactor));

            return this;
        }

        public NetworkBuilder AddHiddenLayer(int numberOfNeuronsInLayer, double bias, ActivationFunctionModel activationFunction, double learningFactor)
        {
            if (this.network.Layers.Count < 1)
            {
                throw new Exception("Cannot add hidden layer when no input layer.");
            }
            
            this.network.Layers.Add(
                NeuronLayerFactory.CreateNeuronLayer(numberOfNeuronsInLayer, this.network.Layers.Last().NeuronList.Count, bias, activationFunction, learningFactor));

            return this;
        }

        public Network Build()
        {
            return network;
        }

        public void Reset()
        {
            this.network = new Network();
        }
    }
}
