using ChainOfResponsabilities.Model;
using UploadStreamToQuestDB.Application.Handlers.Abstraction;

namespace ChainOfResponsabilities.Handlers
{
    internal class HandlerB : AbstractHandler, IHandler
    {
        public override Task<object> Handle(DummyInput files)
        {
            Console.WriteLine("HandlerB is processing the files..." + files.Data);
            return base.Handle(files);
        }
    }
}