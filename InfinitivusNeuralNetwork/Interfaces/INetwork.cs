namespace InfinitivusNeuralNetwork.Interfaces
{
    interface INetwork
    {
        void InitConnection(INeuralLayer FromLayer, INeuralLayer ToLayer);
        void InitLayers();
        void BuildNetwork();
    }
}
