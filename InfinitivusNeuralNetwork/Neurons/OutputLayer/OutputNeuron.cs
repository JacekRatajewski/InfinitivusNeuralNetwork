using System.Linq;

namespace InfinitivusNeuralNetwork.Neurons.OutputLayer
{
    public class OutputNeuron : Neuron
    {
        public override void Activation()
        {
            Weight = Dendrites.Count + Bias;
            OutputPulse = new Pulse();
        }

        public override string GetOutputValue()
        {
            var value = "NonInfinitivus";
            if (Dendrites.Where(x => x.PulseInput.Value == "Infinitivus").FirstOrDefault() != null)
            {
                value = "Infinitivus";
            }
            return value;
        }
    }
}
