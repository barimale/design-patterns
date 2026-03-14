using State.Abstraction;
using State.Model.Context;

namespace State.Model.States
{
    public class PausedState : IPlayerState
    {
        public void Play(PlayerContext context)
        {
            Console.WriteLine("Resuming playback...");
            context.SetState(new PlayingState());
        }

        public void Pause(PlayerContext context)
        {
            Console.WriteLine("Already paused.");
        }
    }
}
