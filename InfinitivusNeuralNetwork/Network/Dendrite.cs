using InfinitivusNeuralNetwork.Interfaces;

namespace InfinitivusNeuralNetwork
{
    public class Dendrite : IDendrite
    {
        private double _weight;
        private IPulse _pulse;
        public IPulse PulseInput { get => _pulse; set => _pulse = value; }
        public double Weight { get => _weight; set => _weight = value; }
    }
}
