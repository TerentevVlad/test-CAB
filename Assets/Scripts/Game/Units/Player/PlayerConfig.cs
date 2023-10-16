using Game.Movement;

namespace Game.Units.Player
{
    public class PlayerConfig
    {
        public PlayerView PlayerView { get; }
        public MovementConfig MovementConfig { get; }
        
        public float Health { get; }

        public PlayerConfig(MovementConfig movementConfig, PlayerView playerView, float health)
        {
            MovementConfig = movementConfig;
            PlayerView = playerView;
            Health = health;
        }
    }
}