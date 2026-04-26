using NNApp.Models;

namespace NNApp.Repositories
{
    public static class ActivationFunctionsRepository
    {
        public static ActivationFunctionModel StepFunction()
        {
            return new ActivationFunctionModel()
            {
                ActivationFunction = x => { return x > 0 ? 1 : 0; },
                DerivativeActivationFunction = x => { return 1; },
            };
        }

        public static ActivationFunctionModel LineActivation()
        {
            return new ActivationFunctionModel()
            {
                ActivationFunction = x => { return x; },
                DerivativeActivationFunction = x => { return 1; },
            };
        }

        public static ActivationFunctionModel Line_1_3_Activation()
        {
            return new ActivationFunctionModel()
            {
                ActivationFunction = x => { return x / 3; },
                DerivativeActivationFunction = x => { return (double)1 / 3; },
            };
        }

        public static ActivationFunctionModel Line_1_6_Activation()
        {
            return new ActivationFunctionModel()
            {
                ActivationFunction = x => { return x / 6; },
                DerivativeActivationFunction = x => { return (double)1 / 6; },
            };
        }

        public static ActivationFunctionModel Line_1_12_Activation()
        {
            return new ActivationFunctionModel()
            {
                ActivationFunction = x => { return x / 12; },
                DerivativeActivationFunction = x => { return (double)1 / 12; },
            };
        }
    }
}
