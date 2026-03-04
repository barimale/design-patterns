using ChainOfResponsabilitiesAndFacade.Handlers.Abstraction;
using ChainOfResponsabilitiesAndFacade.Model;

namespace ChainOfResponsabilitiesAndFacade.Handlers
{
    internal class HandlerB : AbstractHandler, IHandler
    {
        public override Task<object> Handle(DummyInput files)
        {
            Console.WriteLine("HandlerB is processing the files..." + files.Data.ToLowerInvariant());
            return base.Handle(files);
        }
    }
}