using VisitatorAndOthers;

namespace UTs.Executor
{
    public class Neurons
    {
        [Fact]
        public void Execute()
        {
            // given
            var neuron1 = new Neuron();
            var neuron2 = new Neuron();
            var layer1 = new NeuronLayer(3);
            var layer2 = new NeuronLayer(4);

            neuron1.ConnectTo(neuron2);

            neuron2.ConnectTo(layer1);
            layer1.ConnectTo(layer2);
            //layer2.ConnectTo(neuron1);

            // when

            // then
        }
    }
}
