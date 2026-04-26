using System.Text;

namespace NNApp.Models
{
    public class Network
    {
        public List<NeuronLayer> Layers { private set; get; }

        public Network()
        {
            this.Layers = new List<NeuronLayer>();
        }

        public double[] Execute(double[] input)
        {
            double[] layerInput = input, output = [];
            foreach (var layer in Layers)
            {
                output = layer.Execute(layerInput);

                layerInput = output;
            }

            return output;
        }

        public void Train(double[] input, double[] expectedResult)
        {
            //forward pass
            var result = this.Execute(input);

            //init loss
            double[] partialDelta = new double[result.Length];
            for(int i = 0; i < partialDelta.Length; i++)
            {
                partialDelta[i] = (result[i] - expectedResult[i]);
            }

            //train
            for(int i = Layers.Count; i > 0; i--)
            {
                var currentLayer = Layers[i - 1];

                partialDelta = currentLayer.Train(partialDelta);
            }
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            foreach (var layer in this.Layers)
            {
                sb.Append(layer.ToString());
            }
            
            return sb.ToString();
        }
    }
}
