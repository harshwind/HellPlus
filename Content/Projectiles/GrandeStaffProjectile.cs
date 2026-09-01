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
    public class GrandeStaffProjectile : ModProjectile
    {
        public const int maxSpawns = 0;
        public const int dustToSpawn = 4;
        public const float deletionTimeIfNoKill = 150f;
        public const float velMultiplier = 0.88f;

        public override void SetDefaults()
        {
            Projectile.width = 13;
            Projectile.height = 13;
            Projectile.friendly = true;
            Projectile.DamageType = DamageClass.Magic;
            Projectile.penetrate = 4;
            Projectile.timeLeft = 300;
            Projectile.tileCollide = true;
            Projectile.light = 1f;
        }

        public override void AI()
        {
            float maxHomingDistance = 700f;
            float speed = 11f;

            // Destroy all projectiles of less than a certain time remaining
            /*Projectile.ai[0] += 1f;
			if (Projectile.ai[0] >= deletionTimeIfNoKill)
			{
				foreach (Projectile projectile in Main.projectile)
				{
					if (projectile.type == ModContent.ProjectileType<MasterStaffProjectile>() && projectile.owner == Main.myPlayer)
					{
						//Main.NewText(projectile.timeLeft);
						if (projectile.timeLeft <= 225)
						{
							SoundStyle sparkle = new SoundStyle($"{nameof(HellPlus)}/Assets/Sounds/Items/Magic/Sparkle")
							{
								Volume = 1f - (Main.rand.NextFloat() * 0.5f),
								PitchVariance = 0.6f,
								MaxInstances = 10,
							};
							SoundEngine.PlaySound(sparkle, projectile.position);
							projectile.Kill();
						}
                    }
                }
				Projectile.Kill();
			}*/

            // Generate dust
            for (int i = 0; i < dustToSpawn; i++)
            {
                int randAlpha = Main.rand.Next(125);
                float randScale = 1f + (Main.rand.NextFloat() * 0.1f);
                Dust.NewDust(Projectile.Center, Projectile.width, Projectile.height, ModContent.DustType<GBlueDust>(), 0f, 0f, randAlpha, default(Color), randScale);
                       
            }

            NPC target = HomingAI(maxHomingDistance);
            if (target != null)
            {
                if ((Vector2.Distance(Projectile.Center, target.Center)) < maxHomingDistance)
                {
                    Projectile.velocity = (target.Center - Projectile.Center).SafeNormalize(Vector2.Zero) * speed;
                }
            }


        }

        public NPC HomingAI(float maxHomingDistance)
        {
            int count = 0;
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
                count++;
            }
            return null;
        }

        public override void OnKill(int timeLeft)
        {
            int numAltProjectiles = 3;
            Vector2 direction = new Vector2(1, 0);
            for (int i = 0; i < 25; i++)
            {
                Dust dust = Dust.NewDustDirect(Projectile.position, Projectile.width, Projectile.height, DustID.Smoke, Scale: 1.5f);
                dust.velocity *= 3;

            }

            for (int i = 0; i < numAltProjectiles; i++)
            {
                float rotation = MathHelper.ToRadians(360f / numAltProjectiles);
                Vector2 speed = direction.RotatedBy(rotation * i) * 3f;
                Projectile.NewProjectile(Projectile.GetSource_FromThis(), Projectile.Center.X, Projectile.Center.Y, speed.X *= 2, speed.Y *= 2, ModContent.ProjectileType<GrandeStaffProjectileAltA>(), Projectile.damage, Projectile.knockBack);
            }

            for (int i = 0; i < 15; i++)
            {
                Dust dust = Dust.NewDustDirect(Projectile.position, Projectile.width, Projectile.height, DustID.Firework_Blue, Scale: 2.2f);
                dust.velocity *= 6;
                dust.noGravity = true;
            }
            /*for (int k = 0; k < 2; k++) {
				Dust.NewDust(Projectile.position + Projectile.velocity, Projectile.width, Projectile.height, DustID.StarRoyale);
			}*/


            // SOUND
            switch (Main.rand.Next(2))
            {
                case 0:
                    SoundEngine.PlaySound(SoundID.Item4, Projectile.position);
                    break;
                case 1:
                    SoundEngine.PlaySound(SoundID.Item29, Projectile.position);
                    break;
            }
            SoundEngine.PlaySound(SoundID.Item14);
            if (Main.rand.NextBool(10000000))
            {
                SoundEngine.PlaySound(SoundID.BloodZombie);
            }
        }

        public override void OnHitNPC(NPC target, NPC.HitInfo hit, int damageDone)
        {
            int buffTime = 5;

            target.AddBuff(BuffID.Frostburn2, buffTime);
                    
            target.SimpleStrikeNPC(Main.rand.Next(1, 50), 0);
        }
    }
}