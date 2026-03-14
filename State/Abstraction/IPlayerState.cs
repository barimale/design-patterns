using State.Model.Context;

namespace State.Abstraction
{
    public interface IPlayerState
    {
        void Play(PlayerContext context);
        void Pause(PlayerContext context);
    }
}
