using InfinitivusNeuralNetwork.Interfaces;
using System.Collections.Generic;

namespace InfinitivusNeuralNetwork
{
    public abstract class Neuron : INeuron
    {
        private List<IDendrite> _dendrites;
        private double _weight;
        private IPulse _outputPulse;
        public List<IDendrite> Dendrites { get => _dendrites; set => _dendrites = value; }
        public IPulse OutputPulse { get => _outputPulse; set => Fire(value); }
        public double Weight { get => _weight; set => _weight = value; }
        public int Bias => 1;

        protected Neuron() => Dendrites = new List<IDendrite>();

        public abstract void Activation();
        public abstract string GetOutputValue();
        public IPulse Fire(IPulse pulse)
        {
            _outputPulse = pulse;
            _outputPulse.Value = GetOutputValue();
            return _outputPulse;
        }
    }
}
