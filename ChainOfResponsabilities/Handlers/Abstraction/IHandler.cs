using ChainOfResponsabilitiesAndFacade.Model;

namespace ChainOfResponsabilitiesAndFacade.Handlers.Abstraction
{
    public interface IHandler {
        IHandler SetNext(IHandler handler);

        Task<object> Handle(DummyInput files);
    }
}
