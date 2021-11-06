using SFML.Graphics;
using SFML.System;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceFighters
{
    public class SpaceShip : GameObject
    {
        public enum OwnerID
        {
            Player,
            Enemy,
            Boss
        }

        OwnerID _ownerID;

        public OwnerID ownerID
        {
            set { _ownerID = value; }
            get { return _ownerID; }
        }

        public SpaceShip(Shape shape, Texture texture, float PosX, float PosY, float MoveSpeed, float Health, float ShootRate) : base(shape, texture, PosX, PosY)
        {
            _moveSpeed = MoveSpeed;
            this.MoveSpeed = MoveSpeed;
            this.ShootRate = ShootRate;
            _health = Health;
            this.Health = Health;
        }

        private float _moveSpeed;
        public float MoveSpeed
        {
            protected set { _moveSpeed = value; }
            get { return +_moveSpeed; }
        }

        private float _health;
        public float Health
        {
            protected set { _health = value; }
            get { return +_health; }
        }

        public override void Update()
        {
            base.Update();
            _coolDownCounter += Time.DeltaTime;
        }

        //Health code

        public void TakeDamage(float dammage)
        {
            Health = Health - dammage;
        }

        void SpawnProjectile()
        {
            Vector2f ForwardVector = GetForwardVector();
            Vector2f SpawnPos = Position + ForwardVector * Shape.GetLocalBounds().Height;
            Projectile spawnedProjectile = new Projectile(new RectangleShape(new Vector2f(50, 50)), AssetManager.GetTexture("Projectile.png"), SpawnPos.X, SpawnPos.Y, ForwardVector* (MoveSpeed * 2));
            spawnedProjectile.Owner = this; 
        }

        public void SpawnBossProjectile()
        {
            Vector2f ForwardVector = GetForwardVector();
            Vector2f SpawnPos = Position + ForwardVector * Shape.GetLocalBounds().Height;
            Projectile spawnedProjectileOne = new Projectile(new RectangleShape(new Vector2f(25, 25)), AssetManager.GetTexture("Projectile.png"), SpawnPos.X + 75, SpawnPos.Y  - 100, ForwardVector * (MoveSpeed * 2));
            Projectile spawnedProjectileTwo = new Projectile(new RectangleShape(new Vector2f(25, 25)), AssetManager.GetTexture("Projectile.png"), SpawnPos.X - 75, SpawnPos.Y - 100, ForwardVector * (MoveSpeed * 2));
            spawnedProjectileOne.Owner = this;
            spawnedProjectileTwo.Owner = this;


        }


        virtual public void Fire()
        {
            if(CanFire())
            {
                SpawnProjectile();
                _coolDownCounter = 0f;
            }
        }

        virtual public void BossFire()
        {
            if (CanFire())
            {
                SpawnBossProjectile();
                _coolDownCounter = 0f;
            }
        }


        float _shootRate = 10f;

        float _cooldown;
        float _coolDownCounter;
        public float ShootRate
        {
            set { _shootRate = value;
                _cooldown = 1f / _shootRate;
            }

            get { return _shootRate; }
        }

        bool CanFire()
        {
            return _coolDownCounter >= _cooldown;
        }
        public override void OnCollisionEnter(GameObject other)
        {
            if (other.Owner != this)
            {
                Projectile otherAsProjectile = other as Projectile;
                if (otherAsProjectile != null)
                {
                    if (this.ownerID == OwnerID.Enemy)
                    {
                        Program.GetGameInstance().DecreseEnemyCountToSpawnBoss();
                    }
                    if (Health <= 0)
                    {
                        Destroy();
                    }
                    else
                    {
                        TakeDamage(5);
                    }
                }
            }
        }
    }
}