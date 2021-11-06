using SFML.Graphics;
using SFML.System;
using SFML.Window;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceFighters
{
    public class Player : SpaceShip
    {



        public Player(Shape shape, Texture texture, float PosX, float PosY, float MoveSpeed, float Health, float ShootRate) : base(shape, texture, PosX, PosY, MoveSpeed, Health, ShootRate)
        {
            ownerID = OwnerID.Player;
        }


        public override void Update()
        {
            base.Update();
            if (Input.IsKeyDown(Keyboard.Key.W))
            {
                Position = new Vector2f(Position.X, Position.Y - MoveSpeed * Time.DeltaTime);
            }
            if (Input.IsKeyDown(Keyboard.Key.S))
            {
                Position = new Vector2f(Position.X, Position.Y + MoveSpeed * Time.DeltaTime);
            }
            if (Input.IsKeyDown(Keyboard.Key.A))
            {
                Position = new Vector2f(Position.X - MoveSpeed * Time.DeltaTime, Position.Y);
            }
            if (Input.IsKeyDown(Keyboard.Key.D))
            {
                Position = new Vector2f(Position.X + MoveSpeed * Time.DeltaTime, Position.Y);
            }
            if (Input.IsKeyDown(Keyboard.Key.Space))
            {
                Fire();
            }
            if (Input.IsKeyDown(Keyboard.Key.E))
            {
                Shape.Rotation += Time.DeltaTime * 50;
            }
            if (Input.IsKeyDown(Keyboard.Key.Q))
            {
                Shape.Rotation -= Time.DeltaTime * 50;
            }

        }
    }
}
