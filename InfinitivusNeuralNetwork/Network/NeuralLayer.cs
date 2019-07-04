using InfinitivusNeuralNetwork.Interfaces;
using System.Collections.Generic;

namespace InfinitivusNeuralNetwork
{
    public class NeuralLayer : INeuralLayer
    {
        private readonly List<INeuron> _neurons;
        private readonly string _name;
        private double _weight;

        public NeuralLayer(List<INeuron> neurons, string name, double initW)
        {
            _neurons = neurons;
            _name = name;
            _weight = initW;
        }
        public List<INeuron> Neurons => _neurons;
        public string Name => _name;
        public double Weight { get => _weight; set => _weight = value; }

        public void Activation()
        {
            foreach (var neuron in Neurons)
            {
                neuron.Activation();
                Weight += neuron.Weight;
            }
        }
    }
}
