using State.Abstraction;

namespace State.Model.Context
{
    public class PlayerContext
    {
        private IPlayerState _state;

        public PlayerContext(IPlayerState initialState)
        {
            _state = initialState;
        }

        public void SetState(IPlayerState newState)
        {
            _state = newState;
        }

        public void Play() => _state.Play(this);
        public void Pause() => _state.Pause(this);
    }
}
