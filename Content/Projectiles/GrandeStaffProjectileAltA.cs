using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Audio;
using Terraria.ID;
using Terraria.ModLoader;
using HellPlus.Content.Dusts;
using Terraria.GameContent;
using System;
using Terraria.Graphics.Effects;
using Terraria.DataStructures;

namespace HellPlus.Content.Projectiles
{
    public class GrandeStaffProjectileAltA : ModProjectile
    {
        public const int maxSpawns = 0;
        public const int dustToSpawn = 4;
        public const float deletionTimeIfNoKill = 150f;
        public const float velMultiplier = 0.88f;
        //public NPC npcTarget;
        public int type = Main.rand.Next(2);

        public override void SetDefaults()
        {
            Projectile.width = 8;
            Projectile.height = 8;
            Projectile.friendly = true;
            Projectile.DamageType = DamageClass.Magic;
            Projectile.penetrate = 4;
            Projectile.timeLeft = 300;
            Projectile.tileCollide = true;
            Projectile.light = 1f;
        }

        public override void AI()
        {
            float maxHomingDistance = 500f;
            float speed = 10f;

            NPC target = HomingAI(maxHomingDistance);
            if (target != null)
            {
                if ((Vector2.Distance(Projectile.Center, target.Center)) < maxHomingDistance)
                {
                    Projectile.velocity = (target.Center - Projectile.Center).SafeNormalize(Vector2.Zero) * speed;
                }
            }

            Dust dust = Dust.NewDustDirect(Projectile.position, Projectile.width, Projectile.height, ModContent.DustType<CMDust>(), Scale: 0.7f);
        }

        public NPC HomingAI(float maxHomingDistance)
        {
            foreach (NPC npc in Main.ActiveNPCs)
            {
                if (npc.CanBeChasedBy())
                {
                    if (Collision.CanHit(Projectile, npc))
                    {
                        float distanceToTarget = Vector2.DistanceSquared(Projectile.Center, npc.Center);
                        if (distanceToTarget < maxHomingDistance * maxHomingDistance)
                        {
                            return npc;
                        }
                    }
                }
            }
            return null;
        }


        public override bool OnTileCollide(Vector2 oldVelocity)
        {
            //Projectile.Kill();
            //DuplicateProjectile(oldVelocity);
            return true;
        }


        public override void OnKill(int timeLeft)
        {
            for (int i = 0; i < 3; i++)
            {
                Dust dust = Dust.NewDustDirect(Projectile.position, Projectile.width, Projectile.height, DustID.StarRoyale, Scale: 1f);
                dust.velocity *= 20;
            }

            /*int fireworkColour;
            switch (Main.rand.Next(6))
            {
                case 0:
                    fireworkColour = DustID.Firework_Blue;
                    break;
                case 1:
                    fireworkColour = DustID.Firework_Green;
                    break;
                case 2:
                    fireworkColour = DustID.Firework_Pink;
                    break;
                case 3:
                    fireworkColour = DustID.Firework_Red;
                    break;
                case 4:
                    fireworkColour = DustID.Firework_Red;
                    break;
                case 5:
                    fireworkColour = DustID.Firework_Yellow;
                    break;
                default:
                    fireworkColour = DustID.Fireworks;
                    break;
            }*/

            for (int i = 0; i < 5; i++)
            {
                Dust dust = Dust.NewDustDirect(Projectile.position, Projectile.width, Projectile.height, DustID.Fireworks, Scale: 0.7f);
                //dust.velocity *= 20;
                dust.noGravity = true;
            }
        }

        public override void OnHitNPC(NPC target, NPC.HitInfo hit, int damageDone)
        {
            for (int j = 0; j < Main.rand.Next(1, 3); j++)
            {
                target.SimpleStrikeNPC(Main.rand.Next(50, 100), 0);
            }

        }
    }
}