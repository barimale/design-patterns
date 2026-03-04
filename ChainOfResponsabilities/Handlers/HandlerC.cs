using ChainOfResponsabilities.Model;
using UploadStreamToQuestDB.Application.Handlers.Abstraction;

namespace ChainOfResponsabilities.Handlers
{
    internal class HandlerC : AbstractHandler, IHandler
    {
        public override Task<object> Handle(DummyInput files)
        {
            Console.WriteLine("HandlerC is processing the files...");

            return base.Handle(files);
        }
    }
}