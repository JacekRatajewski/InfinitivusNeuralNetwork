namespace InfinitivusNeuralNetwork.Models
{
    public class Input
    {
        public string Word { get; set; }
        public Prularization PrularizationType { get; set; }
    }

    public enum Prularization
    {
        Prular = 0,
        Singular = 1
    }
}
