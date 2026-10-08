using Raylib_cs;
using Space_Invaders_starter.Utils;

namespace Space_Invaders_starter.GameObjects
{
    public abstract class GameObject
    {
        private Vector2D _position;
        public Vector2D Position
        {
            get => _position;
            private set => _position = value;
        }
        public Vector2D Size { get; }
        public Color Color { get; }

        public bool IsActive { get; set; }

        protected GameObject(Vector2D position, Vector2D size, Color color)
        {
            _position = position;
            Size = size;
            Color = color;
            IsActive = true;
        }

        public void Move(Vector2D delta)
        {
            _position += delta;
        }

        public void SetPosition(Vector2D position)
        {
            _position = position;
        }

        public abstract void Update();

        public void Draw()
        {
            Raylib.DrawRectangle(
                (int)(Position.X - Size.X / 2),
                (int)(Position.Y - Size.Y / 2),
                (int)Size.X,
                (int)Size.Y,
                Color
            );
        }

        public bool CollidesWith(GameObject other)
        {
            return !(Position.X + Size.X / 2 < other.Position.X - other.Size.X / 2 ||
                     Position.X - Size.X / 2 > other.Position.X + other.Size.X / 2 ||
                     Position.Y + Size.Y / 2 < other.Position.Y - other.Size.Y / 2 ||
                     Position.Y - Size.Y / 2 > other.Position.Y + other.Size.Y / 2);
        }
    }
}