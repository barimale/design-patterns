using ProxyProperties.Model;

namespace UTs.Executor
{
    public class ProxyProperties
    {
        [Fact]
        public void Execute()
        {
            // given
            var creature = new Creature();
            creature.Agility = 10;

            // when
            creature.Agility = 12;

            // then
        }
    }
}
