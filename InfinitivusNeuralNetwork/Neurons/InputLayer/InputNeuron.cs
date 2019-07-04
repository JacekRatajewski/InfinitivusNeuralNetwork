using System.Linq;

namespace InfinitivusNeuralNetwork.Neurons.InputLayer
{
    public class InputNeuron : Neuron
    {
        private readonly string _input;
        public InputNeuron(string input) => _input = input;

        public override void Activation()
        {
            foreach (var Dendrite in Dendrites)
            {
                var result = Dictionary.Query().Where(x => x.Contains(_input)).Distinct().ToList();
                if (result.Count > 0)
                {
                    Dictionary.SaveToTempMem(result);
                    Dendrite.PulseInput = new Pulse() { Value = _input };
                    Dendrite.Weight = Weight;
                }
            }
            Weight = Dendrites.Count + Bias;
            OutputPulse = new Pulse();
        }

        public override string GetOutputValue()
        {
            return _input;
        }
    }
}
