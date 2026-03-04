using ChainOfResponsabilitiesAndFacade.Handlers.Abstraction;
using ChainOfResponsabilitiesAndFacade.Model;

namespace ChainOfResponsabilitiesAndFacade.Handlers
{
    internal class HandlerA : AbstractHandler, IHandler
    {
        public override Task<object> Handle(DummyInput files)
        {
            Console.WriteLine("HandlerA is processing the files..." + files.Data);
            return base.Handle(files);
        }
    }
}