using State.Abstraction;
using State.Model.Context;

namespace State.Model.States
{
    public class PlayingState : IPlayerState
    {
        public void Play(PlayerContext context)
        {
            Console.WriteLine("Already playing.");
        }

        public void Pause(PlayerContext context)
        {
            Console.WriteLine("Pausing...");
            context.SetState(new PausedState());
        }
    }
}
