using ChainOfResponsabilitiesAndFacade.Handlers.Abstraction;
using ChainOfResponsabilitiesAndFacade.Model;

namespace ChainOfResponsabilitiesAndFacade.Handlers
{
    internal class HandlerC : AbstractHandler, IHandler
    {
        public override Task<object> Handle(DummyInput files)
        {
            Console.WriteLine("HandlerC is processing the files..." + files.Data.ToUpperInvariant());

            return base.Handle(files);
        }
    }
}