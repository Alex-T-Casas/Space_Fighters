using SFML.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceFighters 
{
    class Enemy : SpaceShip
    {
        public Enemy(Shape shape, Texture texture, float PosX, float PosY, float MoveSpeed, float Health, float ShootRate) : base(shape, texture, PosX, PosY, MoveSpeed, Health, ShootRate)
        {
            shape.Rotation = 180;
            ownerID = OwnerID.Enemy;
        }

        public override void Update()
        {
            base.Update();
            Fire();
            Position += GetForwardVector() * MoveSpeed * Time.DeltaTime;
        }

        public override void OnCollisionEnter(GameObject other)
        {
            base.OnCollisionEnter(other);
        }
    }
}
