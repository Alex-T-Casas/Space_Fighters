using SFML.Graphics;
using SFML.System;
using SFML.Window;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace SpaceFighters
{
    class Program
    {

        static void Main(string[] args)
        {
            new Player(new RectangleShape(new Vector2f(100, 100)), AssetManager.GetTexture("PlayerShip.png"), 200, 200, 400, 100, 5);
            game.Run();
        }
        static Game game = new Game(720, 1024);
        public static Game GetGameInstance()
        {
            return game;
        }


    }
}
