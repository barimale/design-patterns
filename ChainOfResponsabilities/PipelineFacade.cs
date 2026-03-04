using ChainOfResponsabilities.Handlers;
using ChainOfResponsabilities.Model;

namespace ChainOfResponsabilities
{
    public class PipelineFacade
    {
        private readonly HandlerA handlerA;
        private readonly HandlerB handlerB;
        private readonly HandlerC handlerC;

        public PipelineFacade()
        {
            handlerA = new HandlerA();
            handlerB = new HandlerB();
            handlerC = new HandlerC();
        }
        public void Initialize()
        {
            handlerA
               .SetNext(handlerB)
               .SetNext(handlerC);
        }

        public async Task Run(DummyInput dummy)
        {
            await handlerA.Handle(dummy);
        }
    }
}
