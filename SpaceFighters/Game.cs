using SFML.Graphics;
using SFML.System;
using SFML.Window;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace SpaceFighters
{
    class Game
    {
        private Timer _timer;
        public Game(uint windowWidth, uint WindowHeight, string title = "My Awsome Game")
        {
            _window = new RenderWindow(new VideoMode(windowWidth, WindowHeight), title);
            _window.Closed += ExitGame;
            _window.SetFramerateLimit(60);
            _gameObjects = new List<GameObject>();

            _timer = new System.Timers.Timer(2 * 1000);
            _timer.Elapsed += OnTimedEvent;

            _timer.AutoReset = true;
            _timer.Enabled = true;
        }

        private void OnTimedEvent(object sender, ElapsedEventArgs e)
        {
            SpwanEnemy();
        }

        public void AddGameObjects(GameObject newObject)
        {
            if(! _gameObjects.Contains(newObject))
            {
                _gameObjects.Add(newObject);
            }
        }


        RenderWindow _window;

        public void Run()
        {
            Start();
            Update();
        }

        private void Start()
        {

        }

        private void Update()
        {
            while (Window.IsOpen)
            {
                Time.Update();
                Window.DispatchEvents();
                UpdateGameLogic();
                Render();
            }
        }

        private void UpdateGameLogic()
        {
            //Console.WriteLine(1f/Time.DeltaTime);
            for (int i = 0; i < _gameObjects.Count; i++)
            {
                if(_gameObjects[i] != null)
                {
                    _gameObjects[i].Update();
                }
            }
        }

        private void Render()
        {
            Window.Clear();
            for (int i = 0; i < _gameObjects.Count; i++)
            {
                if (_gameObjects[i] != null)
                {
                    Window.Draw(_gameObjects[i].Shape);
                }
            }
            //draw out all objs
            Window.Display();
        }

        private void ExitGame(object? sender, EventArgs e)
        {
            Window.Close();
        }

        public RenderWindow Window
        {
            private set { _window = value; }
            get { return _window; }
        }
        private List<GameObject> _gameObjects;

        public GameObject[] GetAllGameObjects()
        {
            return _gameObjects.ToArray();
        }

        public void RemoveFromGame(GameObject objectToRemove)
        {
            if(_gameObjects.Contains(objectToRemove))
            {
                _gameObjects.Remove(objectToRemove);
            }
        }

        void SpwanEnemy()
        {
            System.Random rand = new Random();
            float SpawnPosX = rand.Next(0, (int)Window.Size.X);
            float SpawnPosY = 0;
            new Enemy(new RectangleShape(new Vector2f(100, 100)), AssetManager.GetTexture("EnemyShip.png"), SpawnPosX, SpawnPosY, 150, 5, 1.5f);
        }

        private static float EnemiesUntilBossSpawns = 5;
        public void DecreseEnemyCountToSpawnBoss()
        {
            EnemiesUntilBossSpawns--;
            Console.WriteLine(EnemiesUntilBossSpawns);
            if (EnemiesUntilBossSpawns <= 0)
            {
                SpawnBoss();

            }
        }
        void SpawnBoss()
        {
            System.Random rand = new Random();
            float SpawnPosX = rand.Next(-50, 50);
            float SpawnPosY = 0;
            new Boss(new RectangleShape(new Vector2f(300, 300)), AssetManager.GetTexture("BossShip.png"), 200 + SpawnPosX, SpawnPosY, 75, 75, 3);
            EnemiesUntilBossSpawns = 10;
        }
    }
}

