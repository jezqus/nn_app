namespace NNApp.Models
{
    public class ActivationFunctionModel
    {
        public required Func<double, double> ActivationFunction { get; set; }

        public required Func<double, double> DerivativeActivationFunction { get; set; }
    }
}
