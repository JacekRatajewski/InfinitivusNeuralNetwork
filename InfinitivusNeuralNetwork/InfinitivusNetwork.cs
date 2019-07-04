using InfinitivusNeuralNetwork.Interfaces;
using System.Collections.Generic;

namespace InfinitivusNeuralNetwork
{
    public class InfinitivusNetwork : INetwork
    {
        public List<INeuralLayer> NeuralLayers;

        public InfinitivusNetwork(List<INeuralLayer> neuralLayers) => NeuralLayers = neuralLayers;

        private void InitLayer(INeuralLayer Layer)
        {
            foreach (var Neuron in Layer.Neurons)
            {
                Neuron.Dendrites.Add(new Dendrite());
            }
        }

        public void InitConnection(INeuralLayer FromLayer, INeuralLayer ToLayer)
        {
            FromLayer.Activation();
            foreach (var FromNeuron in FromLayer.Neurons)
            {
                foreach (var ToNeuron in ToLayer.Neurons)
                {
                    if (ToNeuron.Dendrites[ToNeuron.Dendrites.Count - 1].PulseInput == null)
                    {
                        foreach (var Dendrite in ToNeuron.Dendrites)
                        {

                            Dendrite.PulseInput = FromNeuron.OutputPulse;
                            Dendrite.Weight = FromNeuron.Weight;
                        }
                    }
                    else
                    {
                        ToNeuron.Dendrites.Add(new Dendrite() { PulseInput = FromNeuron.OutputPulse, Weight = FromNeuron.Weight });
                    }
                }
            }
            ToLayer.Activation();
        }
        public void InitLayers()
        {
            foreach (var Layer in NeuralLayers)
            {
                InitLayer(Layer);
            }
        }
        public void BuildNetwork()
        {
            int i = 0;
            foreach (var Layer in NeuralLayers)
            {
                if (i >= NeuralLayers.Count - 1)
                {
                    break;
                }
                InitConnection(Layer, NeuralLayers[i + 1]);
                i++;
            }
        }
    }
}
