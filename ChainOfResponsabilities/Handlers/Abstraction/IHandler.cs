using ChainOfResponsabilities.Model;

namespace UploadStreamToQuestDB.Application.Handlers.Abstraction {
    public interface IHandler {
        IHandler SetNext(IHandler handler);

        Task<object> Handle(DummyInput files);
    }
}
