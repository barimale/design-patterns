using Composite.Abstraction;

namespace Composite
{
    public class Neuron: Scalar<Neuron>
    {
        public List<Neuron> In = new List<Neuron>();
        public List<Neuron> Out = new List<Neuron>();
    }
}
