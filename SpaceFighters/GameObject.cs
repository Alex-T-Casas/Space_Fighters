using SFML.Graphics;
using SFML.System;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceFighters
{
    public class GameObject
    {
        public GameObject(Shape shape, Texture texture, float PosX, float PosY)
        {
            _shape = shape;
            _shape.Texture = texture;
            _shape.Origin = new Vector2f(_shape.GetLocalBounds().Width / 2, _shape.GetLocalBounds().Height / 2);
            Position = new Vector2f(PosX, PosY);
            Program.GetGameInstance().AddGameObjects(this);
        }

        virtual public void Start()
        {

        }

        virtual public void Update()
        {
            if (IsOutOfWindow())
            {
                Destroy();
            }
            else
            {
                CheckCollision();
            }

        }

        public void Destroy()
        {
            Program.GetGameInstance().RemoveFromGame(this);
        }

        private Shape _shape;

        public Shape Shape
        {
            get { return _shape; }
        }

        public Vector2f Position
        {
            set { _shape.Position = value; }
            get { return _shape.Position; }
        }

        bool IsOutOfWindow()
        {
            bool OutofX = Position.X < 0 - Shape.GetLocalBounds().Width || Position.X > Program.GetGameInstance().Window.Size.X + Shape.GetLocalBounds().Width;
            bool OutofY = Position.Y < 0 - Shape.GetLocalBounds().Height || Position.Y > Program.GetGameInstance().Window.Size.Y + Shape.GetLocalBounds().Height;
            return OutofX || OutofY;
        }

        public Vector2f GetForwardVector()
        {
            float rotation = Shape.Rotation;
            Vector2f UpVector = new Vector2f(0, -1);
            Transform RotationTrans = Transform.Identity;
            RotationTrans.Rotate(rotation);
            return RotationTrans.TransformPoint(UpVector);
        }

        void CheckCollision()
        {
            GameObject[] objects = Program.GetGameInstance().GetAllGameObjects();
            for (int i = 0; i < objects.Length; i++)
            {
                if (objects[i] != null && objects[i] != this)
                {
                    Shape otherShape = objects[i].Shape;
                    if (Shape.GetGlobalBounds().Intersects(otherShape.GetGlobalBounds()))
                    {
                        OnCollisionEnter(objects[i]);
                    }
                }
            }
        }
        public virtual void OnCollisionEnter(GameObject other)
        {

        }
        GameObject _owner;

        public GameObject Owner
        {
            set { _owner = value; }
            get { return _owner; }
        }
    }
}

