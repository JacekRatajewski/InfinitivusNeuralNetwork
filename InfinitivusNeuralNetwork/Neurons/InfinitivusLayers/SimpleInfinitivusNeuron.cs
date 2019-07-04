using System.Collections.Generic;
using System.Linq;

namespace InfinitivusNeuralNetwork.Neurons.InfinitivusLayer
{
    public class SimpleInfinitivusNeuron : Neuron
    {
        private readonly string _wordEnd;
        private readonly List<string> _verbEnds;

        public SimpleInfinitivusNeuron(string wordEnd, string verbEnds)
        {
            _wordEnd = wordEnd;
            _verbEnds = verbEnds.Split(';').ToList();
        }

        public override void Activation()
        {
            foreach (var Dendrite in Dendrites)
            {
                OutputPulse = new Pulse();
            }
            Weight += Bias;
        }

        public override string GetOutputValue()
        {
            var output = "NonInfinitivus";
            foreach (var Dendrite in Dendrites)
            {
                var infitivus = Dendrite.PulseInput.Value.Substring(Dendrite.PulseInput.Value.Length - _wordEnd.Length);
                var isInfitivus = (infitivus == _wordEnd) ? true : false;
                if (isInfitivus)
                {
                    var simpleDict = Dictionary.GetFromTempMem();
                    foreach (var verbEnd in _verbEnds)
                    {
                        var verbs = new List<string>();
                        var sampleWord = Dendrite.PulseInput.Value.Substring(0, Dendrite.PulseInput.Value.Length - _wordEnd.Length) + verbEnd;
                        foreach (var line in simpleDict)
                        {
                            verbs.AddRange(line.Split(','));
                        }
                        var verb = verbs.Where(x => x.Replace(" ", string.Empty) == sampleWord).Select(x => x).ToList();
                        if (verb.Count() > 0)
                        {
                            output = "Infinitivus";
                            Weight += 1;
                        }
                    }
                }
            }
            return output;
        }
    }
}
