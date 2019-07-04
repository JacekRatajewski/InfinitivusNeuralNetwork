using System.Data.Entity.Design.PluralizationServices;
using System.Globalization;
using static InfinitivusNeuralNetwork.Dictionary;

namespace InfinitivusNeuralNetwork.Neurons.InfinitivusLayers
{
    public class PluralNeuron : Neuron
    {
        private readonly PluralizationService _pluralizationService;
        public PluralNeuron() => _pluralizationService = PluralizationService.CreateService(new CultureInfo("en-US"));

        public override void Activation()
        {
            OutputPulse = new Pulse();
            Weight += Bias;
        }

        public override string GetOutputValue()
        {
            var output = "";
            foreach (var Dendrite in Dendrites)
            {
                if (_pluralizationService.IsPlural(Dictionary.TranslateText(Dendrite.PulseInput.Value, "pl", "en")))
                {
                    Weight += 1;
                }
                output = Dendrite.PulseInput.Value;
            }
            return output;
        }
    }
}
