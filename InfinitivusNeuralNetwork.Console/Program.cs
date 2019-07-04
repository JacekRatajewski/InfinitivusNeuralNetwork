using InfinitivusNeuralNetwork;
using InfinitivusNeuralNetwork.Interfaces;
using InfinitivusNeuralNetwork.Neurons.InfinitivusLayer;
using InfinitivusNeuralNetwork.Neurons.InputLayer;
using InfinitivusNeuralNetwork.Neurons.OutputLayer;
using System;
using System.Collections.Generic;

namespace SimpleNeuralNetwork.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Write word: ");
            var input = Console.ReadLine();
            var InfinitivusLayer = new List<INeuron>()
            {
                new SimpleInfinitivusNeuron("ić", "ił"),
                new SimpleInfinitivusNeuron("yć", "ył"),
                new SimpleInfinitivusNeuron("uć", "uł"),
                new SimpleInfinitivusNeuron("eć", "eli;eły"),
                new SimpleInfinitivusNeuron("ać", "ali;ały"),
                new SimpleInfinitivusNeuron("ąć", "ęli;ęły"),
                new SimpleInfinitivusNeuron("ść", "sę;tę;dę;dzę"),
                new SimpleInfinitivusNeuron("żć", "zę"),
                new SimpleInfinitivusNeuron("c", "kę;gę")
            };
            var layers = new List<INeuralLayer>
            {
                new NeuralLayer(new List<INeuron>{new InputNeuron(input)}, "InputLayer", 1),
                new NeuralLayer(InfinitivusLayer, "InfinitivusLayer", 1),
                new NeuralLayer(new List<INeuron>{new OutputNeuron()}, "OutputLayer", 1)
            };
            var Network = new InfinitivusNetwork(layers);
            Network.InitLayers();
            Network.BuildNetwork();
            Console.WriteLine(Network.NeuralLayers[2].Neurons[0].OutputPulse.Value);
            Console.ReadLine();
        }
    }
}
