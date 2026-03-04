using Singleton;

namespace UTs.Executor
{
    public class Singleton
    {
        [Fact]
        public void Execute()
        {
            // given
            var singleton = SingletonPattern.Instance;
            singleton.Data = "Hello, Singleton!";
            Console.WriteLine(singleton.Data);

            // when
            var second = SingletonPattern.Instance;
            Console.WriteLine(second.Data);
            second.Data = "Changed data";

            // then
            Console.WriteLine(second.Data);
            Console.WriteLine(singleton.Data);
        }
    }
}
