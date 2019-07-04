using System.Collections.Generic;

namespace InfinitivusNeuralNetwork.Interfaces
{
    public interface INeuralLayer
    {
        List<INeuron> Neurons { get; }
        string Name { get; }
        double Weight { get; set; }
        void Activation();
    }
}
