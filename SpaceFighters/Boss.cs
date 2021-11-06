using SFML.Graphics;
using SFML.System;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceFighters
{
    class Boss : SpaceShip
    {
        public Boss(Shape shape, Texture texture, float PosX, float PosY, float MoveSpeed, float Health, float ShootRate) : base(shape, texture, PosX, PosY, MoveSpeed, Health, ShootRate)
        {
            Shape.Rotation = 180;
            ownerID = OwnerID.Boss;
        }

        public override void Update()
        {
            base.Update();
            Position = new Vector2f(Position.X, Position.Y + MoveSpeed * Time.DeltaTime);
            BossFire();
        }

        public override void OnCollisionEnter(GameObject other)
        {
            base.OnCollisionEnter(other);
        }
    }
}
