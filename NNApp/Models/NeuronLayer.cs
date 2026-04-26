using System.Text;

namespace NNApp.Models
{
    public class NeuronLayer
    {
        public required List<Neuron> NeuronList { get; set; }

        public double[] Execute(double[] input)
        {
            double[] result = new double[NeuronList.Count];

            for (int i = 0; i < this.NeuronList.Count; i++)
            {
                result[i] = NeuronList[i].Execute(input);
            }

            return result;
        }

        public double[] Train(double[] deltaPartial) //(x1, x2)
        {
            //delta[l-1] = (W[l].T * delta[l]) .* pochodna(z[l-1])
            double[] backPropDeltaPartial = new double[NeuronList.First().Weights.Length]; // (y1, y2, y3) bo (w1, w2, w3) ale neuronow mam 2
            for(int i = 0; i < backPropDeltaPartial.Length;i++)
            {
                double sum = 0;
                for(int j = 0; j < NeuronList.Count; j++)
                {
                    sum += NeuronList[j].Weights[i] * deltaPartial[j];
                }

                backPropDeltaPartial[i] = sum;
            }

            for (int i = 0; i < this.NeuronList.Count; i++)
            {
                var neuron = this.NeuronList[i];

                var neuronDelta = deltaPartial[i] * neuron.ActivationFunctionContainer.DerivativeActivationFunction(neuron.Z);

                NeuronList[i].Train(neuronDelta);
            }

            return backPropDeltaPartial;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("----------------------------------------------");
            foreach (Neuron neuron in NeuronList)
            {
                sb.AppendLine(neuron.ToString());
            }
            sb.AppendLine("----------------------------------------------");
            return sb.ToString();
        }
    }
}
