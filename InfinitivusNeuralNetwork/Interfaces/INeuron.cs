using System.Collections.Generic;

namespace InfinitivusNeuralNetwork.Interfaces
{
    public interface INeuron
    {
        List<IDendrite> Dendrites { get; set; }
        IPulse OutputPulse { get; set; }
        IPulse Fire(IPulse pulse);
        double Weight { get; set; }
        int Bias { get; }
        void Activation();
        string GetOutputValue();
    }
}
