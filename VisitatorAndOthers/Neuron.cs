using VisitatorAndOthers.Abstraction;

namespace VisitatorAndOthers
{
    public class Neuron: Scalar<Neuron>
    {
        public List<Neuron> In = new List<Neuron>();
        public List<Neuron> Out = new List<Neuron>();
    }
}
