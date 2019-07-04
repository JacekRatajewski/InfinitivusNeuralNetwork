namespace InfinitivusNeuralNetwork.Interfaces
{
    public interface IDendrite
    {
        IPulse PulseInput { get; set; }
        double Weight { get; set; }
    }
}
