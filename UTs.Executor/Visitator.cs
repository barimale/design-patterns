using ChainOfResponsabilities;
using ChainOfResponsabilities.Model;
using Visitator;
using Visitator.Elements;
using Visitator.Visitators;

namespace UTs.Executor
{
    public class Visitator
    {
        [Fact]
        public void Execute()
        {
            // given
            List<IServiceItem> services = new List<IServiceItem>
            {
                new ServiceA("URL A"),
                new ServiceB("URL B"),
                new ServiceB("URL C")
            };

            IVisitor notifier = new NotifyManager();

            // when
            foreach (var service in services)
            {
                service.Accept(notifier);
            }

            // then
        }
    }
}
