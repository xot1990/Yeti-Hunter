using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileData 
{
    
    public class Projectile
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public float Power { get; set; }

        public Sprite Type { get; set; }

        public float ShieldDamageMod { get; set; }

        public float ArmorDamageMod { get; set; }

        public float Speed { get; set; }

    }

    
    public class PlanetProjectile
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public float Power { get; set; }

        public float ShieldDamageMod { get; set; }

        public float ArmorDamageMod { get; set; }

        public float Speed { get; set; }

    }

    public static class ProjectileList
    {

        public static List<Projectile> Projectiles { get; set; }

        public static List<PlanetProjectile> PlanetProjectiles { get; set; }

        public static void Initialize()
        {

            Projectiles = new List<Projectile>
            {
                new Projectile
                {
                    Id = 0,
                    Name = "Rocket M1",
                    Power = 1f,
                    Type = Resources.Load<Sprite>("Sprites/Enemies/Projectiles/Projectiles Type 1"),
                    ShieldDamageMod = 3f,
                    ArmorDamageMod = 1f,
                    Speed = 2000f,
                },

                new Projectile
                {
                    Id = 1,
                    Name = "Laser M1",
                    Power = 1f,
                    Type = Resources.Load<Sprite>("Sprites/Enemies/Projectiles/Projectiles Type 2"),
                    ShieldDamageMod = 1f,
                    ArmorDamageMod = 1f,
                    Speed = 2500f,
                },

                new Projectile
                {
                    Id = 2,
                    Name = "Plasma M1",
                    Power = 1f,
                    Type = Resources.Load<Sprite>("Sprites/Enemies/Projectiles/Projectiles Type 3"),
                    ShieldDamageMod = 0.5f,
                    ArmorDamageMod = 4f,
                    Speed = 2000f,
                },

                new Projectile
                {
                    Id = 3,
                    Name = "Fire M1",
                    Power = 1f,
                    Type = Resources.Load<Sprite>("Sprites/Enemies/Projectiles/Projectiles Type 4"),
                    ShieldDamageMod = 1f,
                    ArmorDamageMod = 3f,
                    Speed = 2000f,
                },

                new Projectile
                {
                    Id = 4,
                    Name = "Elektra M1",
                    Power = 1f,
                    Type = Resources.Load<Sprite>("Sprites/Enemies/Projectiles/Projectiles Type 5"),
                    ShieldDamageMod = 4f,
                    ArmorDamageMod = 0.5f,
                    Speed = 2000f,
                },

                new Projectile
                {
                    Id = 5,
                    Name = "Elektra M2",
                    Power = 2f,
                    Type = Resources.Load<Sprite>("Sprites/Enemies/Projectiles/Projectiles Type 5"),
                    ShieldDamageMod = 8f,
                    ArmorDamageMod = 1f,
                    Speed = 2000f,
                },

                new Projectile
                {
                    Id = 6,
                    Name = "MinigLaser",
                    Power = 3f,
                    Type = Resources.Load<Sprite>("Sprites/Enemies/Projectiles/Projectiles Type 6"),
                    ShieldDamageMod = 2f,
                    ArmorDamageMod = 3f,
                    Speed = 2500f,
                },

                new Projectile
                {
                    Id = 7,
                    Name = "Cloud",
                    Power = 3f,
                    Type = Resources.Load<Sprite>("Sprites/Enemies/Projectiles/Projectiles Type 7"),
                    ShieldDamageMod = 2f,
                    ArmorDamageMod = 3f,
                    Speed = 5000f,
                },

                new Projectile
                {
                    Id = 8,
                    Name = "Laser M3",
                    Power = 3f,
                    Type = Resources.Load<Sprite>("Sprites/Enemies/Projectiles/Projectiles Type 8"),
                    ShieldDamageMod = 3f,
                    ArmorDamageMod = 3f,
                    Speed = 2500f,
                },

                new Projectile
                {
                    Id = 9,
                    Name = "Shrapnel",
                    Power = 3f,
                    Type = Resources.Load<Sprite>("Sprites/Enemies/Projectiles/Projectiles Type 8"),
                    ShieldDamageMod = 1f,
                    ArmorDamageMod = 5f,
                    Speed = 2500f,
                },

                new Projectile
                {
                    Id = 10,
                    Name = "Fire M2",
                    Power = 2f,
                    Type = Resources.Load<Sprite>("Sprites/Enemies/Projectiles/Projectiles Type 4"),
                    ShieldDamageMod = 2f,
                    ArmorDamageMod = 6f,
                    Speed = 2000f,
                },

                new Projectile
                {
                    Id = 11,
                    Name = "Fire M3",
                    Power = 3f,
                    Type = Resources.Load<Sprite>("Sprites/Enemies/Projectiles/Projectiles Type 4"),
                    ShieldDamageMod = 3f,
                    ArmorDamageMod = 9f,
                    Speed = 2000f,
                },

                new Projectile
                {
                    Id = 12,
                    Name = "Fire M4",
                    Power = 4f,
                    Type = Resources.Load<Sprite>("Sprites/Enemies/Projectiles/Projectiles Type 4"),
                    ShieldDamageMod = 4f,
                    ArmorDamageMod = 12f,
                    Speed = 2000f,
                },

                new Projectile
                {
                    Id = 13,
                    Name = "Fire M5",
                    Power = 5f,
                    Type = Resources.Load<Sprite>("Sprites/Enemies/Projectiles/Projectiles Type 4"),
                    ShieldDamageMod = 5f,
                    ArmorDamageMod = 15f,
                    Speed = 2000f,
                },

                new Projectile
                {
                    Id = 14,
                    Name = "Elektra M3",
                    Power = 3f,
                    Type = Resources.Load<Sprite>("Sprites/Enemies/Projectiles/Projectiles Type 5"),
                    ShieldDamageMod = 12f,
                    ArmorDamageMod = 1.5f,
                    Speed = 2000f,
                },

                new Projectile
                {
                    Id = 15,
                    Name = "Elektra M4",
                    Power = 4f,
                    Type = Resources.Load<Sprite>("Sprites/Enemies/Projectiles/Projectiles Type 5"),
                    ShieldDamageMod = 16f,
                    ArmorDamageMod = 2f,
                    Speed = 2000f,
                },

                new Projectile
                {
                    Id = 16,
                    Name = "Elektra M5",
                    Power = 5f,
                    Type = Resources.Load<Sprite>("Sprites/Enemies/Projectiles/Projectiles Type 5"),
                    ShieldDamageMod = 20f,
                    ArmorDamageMod = 2.5f,
                    Speed = 2000f,
                },

                new Projectile
                {
                    Id = 17,
                    Name = "Plasma M2",
                    Power = 2f,
                    Type = Resources.Load<Sprite>("Sprites/Enemies/Projectiles/Projectiles Type 3"),
                    ShieldDamageMod = 1f,
                    ArmorDamageMod = 8f,
                    Speed = 2000f,
                },

                new Projectile
                {
                    Id = 18,
                    Name = "Plasma M3",
                    Power = 3f,
                    Type = Resources.Load<Sprite>("Sprites/Enemies/Projectiles/Projectiles Type 3"),
                    ShieldDamageMod = 1.5f,
                    ArmorDamageMod = 12f,
                    Speed = 2000f,
                },

                new Projectile
                {
                    Id = 19,
                    Name = "Plasma M4",
                    Power = 4f,
                    Type = Resources.Load<Sprite>("Sprites/Enemies/Projectiles/Projectiles Type 3"),
                    ShieldDamageMod = 2f,
                    ArmorDamageMod = 16f,
                    Speed = 2000f,
                },

                new Projectile
                {
                    Id = 20,
                    Name = "Plasma M5",
                    Power = 5f,
                    Type = Resources.Load<Sprite>("Sprites/Enemies/Projectiles/Projectiles Type 3"),
                    ShieldDamageMod = 2.5f,
                    ArmorDamageMod = 20f,
                    Speed = 2000f,
                },

                new Projectile
                {
                    Id = 21,
                    Name = "Rocket M2",
                    Power = 2f,
                    Type = Resources.Load<Sprite>("Sprites/Enemies/Projectiles/Projectiles Type 1"),
                    ShieldDamageMod = 6f,
                    ArmorDamageMod = 2f,
                    Speed = 2000f,
                },

                new Projectile
                {
                    Id = 22,
                    Name = "Rocket M3",
                    Power = 3f,
                    Type = Resources.Load<Sprite>("Sprites/Enemies/Projectiles/Projectiles Type 1"),
                    ShieldDamageMod = 9f,
                    ArmorDamageMod = 3f,
                    Speed = 2000f,
                },

                new Projectile
                {
                    Id = 23,
                    Name = "Rocket M4",
                    Power = 4f,
                    Type = Resources.Load<Sprite>("Sprites/Enemies/Projectiles/Projectiles Type 1"),
                    ShieldDamageMod = 12f,
                    ArmorDamageMod = 4f,
                    Speed = 2000f,
                },

                new Projectile
                {
                    Id = 24,
                    Name = "Rocket M5",
                    Power = 5f,
                    Type = Resources.Load<Sprite>("Sprites/Enemies/Projectiles/Projectiles Type 1"),
                    ShieldDamageMod = 15f,
                    ArmorDamageMod = 5f,
                    Speed = 2000f,
                },

                new Projectile
                {
                    Id = 25,
                    Name = "Laser M2",
                    Power = 2f,
                    Type = Resources.Load<Sprite>("Sprites/Enemies/Projectiles/Projectiles Type 2"),
                    ShieldDamageMod = 2f,
                    ArmorDamageMod = 2f,
                    Speed = 2500f,
                },

                new Projectile
                {
                    Id = 26,
                    Name = "Laser M4",
                    Power = 4f,
                    Type = Resources.Load<Sprite>("Sprites/Enemies/Projectiles/Projectiles Type 2"),
                    ShieldDamageMod = 4f,
                    ArmorDamageMod = 4f,
                    Speed = 2500f,
                },

                new Projectile
                {
                    Id = 27,
                    Name = "Laser M5",
                    Power = 5f,
                    Type = Resources.Load<Sprite>("Sprites/Enemies/Projectiles/Projectiles Type 2"),
                    ShieldDamageMod = 5f,
                    ArmorDamageMod = 5f,
                    Speed = 2500f,
                },

            };

            PlanetProjectiles = new List<PlanetProjectile>
            {
                new PlanetProjectile
                {
                    Id = 0,
                    Name = "Ice Block",
                    Power = 1f,
                    ShieldDamageMod = 1f,
                    ArmorDamageMod = 3f,
                    Speed = 2000f,
                },
            };

        }
    }
}
