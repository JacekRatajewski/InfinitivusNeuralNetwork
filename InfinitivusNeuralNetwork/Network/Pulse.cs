using InfinitivusNeuralNetwork.Interfaces;

namespace InfinitivusNeuralNetwork
{
    public class Pulse : IPulse
    {
        private string _value;
        public string Value { get => _value; set => _value = value; }
    }
}
