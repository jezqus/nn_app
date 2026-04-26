using System.Text;

namespace NNApp.Models
{
    public class Neuron
    {
        public required double[] Weights { get; set; }
        public double Bias { get; set; }
        public double LearningFactor { get; set; }

        public double[] Activation = [];

        public double Z;

        public required ActivationFunctionModel ActivationFunctionContainer { get; set; }

        public double Execute(double[] input)
        {
            this.Activation = input;

            double result = 0.0;

            for (int i = 0; i < Weights.Length; i++)
            {
                result += this.Weights[i] * input[i];
            }

            result += Bias;

            this.Z = result;

            return this.ActivationFunctionContainer.ActivationFunction(result);
        }

        public void Train(double delta)
        {
            ArgumentNullException.ThrowIfNull(this.Activation);

            for (int i = 0; i < Weights.Length; i++)
            {
                this.Weights[i] -= (delta * this.Activation[i]) * this.LearningFactor;    
            }
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            foreach (var weight in Weights)
            {
                sb.Append($"{weight:0.##};");
            }

            sb.Append($"b:{Bias}");

            return sb.ToString();
        }
    }
}
