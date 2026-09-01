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
	public class MasterStaffProjectile : ModProjectile
	{
		public const int maxSpawns = 0;
		public const int dustToSpawn = 4;
        public const float deletionTimeIfNoKill = 150f;
		public const float velMultiplier = 0.88f;
        //public NPC npcTarget;
        public int type = Main.rand.Next(6);
		// 0: Blue
		// 1: Green
		// 2: Pink
		// 3: Red
		// 4: White
		// 5: Yellow

		public override void SetDefaults() {
			Projectile.width = 13;
			Projectile.height = 13;
			Projectile.friendly = true;
			Projectile.DamageType = DamageClass.Magic;
			Projectile.penetrate = 4;
			Projectile.timeLeft = 300;
			Projectile.tileCollide = true;
			Projectile.light = 1f;			
		}

		public override void AI() {
			float maxHomingDistance = 900f;
			float speed = 15f;

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
				switch (type)
				{
					case 0:
						Dust.NewDust(Projectile.Center, Projectile.width, Projectile.height, ModContent.DustType<GBlueDust>(), 0f, 0f, randAlpha, default(Color), randScale);
						break;
					case 1:                                                                                                         // Projectile.velocity.Y
                        Dust.NewDust(Projectile.Center, Projectile.width, Projectile.height, ModContent.DustType<GGreenDust>(), 0f, 0f, randAlpha, default(Color), randScale);
                        break;
					case 2:
						Dust.NewDust(Projectile.Center, Projectile.width, Projectile.height, ModContent.DustType<GPinkDust>(), 0f, 0f, randAlpha, default(Color), randScale);
                        break;
					case 3:
						Dust.NewDust(Projectile.Center, Projectile.width, Projectile.height, ModContent.DustType<GRedDust>(), 0f, 0f, randAlpha, default(Color), randScale);
                        break;
					case 4:
						Dust.NewDust(Projectile.Center, Projectile.width, Projectile.height, ModContent.DustType<GWhiteDust>(), 0f, 0f, randAlpha, default(Color), randScale);
                        break;
                    case 5:
                        Dust.NewDust(Projectile.Center, Projectile.width, Projectile.height, ModContent.DustType<GYellowDust>(), 0f, 0f, randAlpha, default(Color), randScale);
                        break;
                }
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
						if (distanceToTarget < maxHomingDistance*maxHomingDistance)
						{
							return npc;
						}
					}
				}
				count++;
			}
			return null;
		}

		public override void OnKill(int timeLeft) {
			int numAltProjectiles = 20;
            Vector2 direction = new Vector2(1, 0);
            for (int i = 0; i < 25; i++)  // SMOKE DUST
            {
                Dust dust = Dust.NewDustDirect(Projectile.position, Projectile.width, Projectile.height, DustID.Smoke, Scale: 1.5f);
                dust.velocity *= 3;
                
            }

			for (int i = 0; i < numAltProjectiles; i++)  // ALT A PROJECTILES
			{
				float rotation = MathHelper.ToRadians(360f / numAltProjectiles);
				Vector2 speed = direction.RotatedBy(rotation * i) * 3f;
				Projectile.NewProjectile(Projectile.GetSource_FromThis(), Projectile.Center.X, Projectile.Center.Y, speed.X *= 2, speed.Y *= 2, ModContent.ProjectileType<MasterStaffProjectileAltA>(), Projectile.damage, Projectile.knockBack);
			}

            int fireworkColour;  // FIREWORK DUST
			switch(type)
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
                    fireworkColour = DustID.FireworksRGB;
                    break;
                case 5:
                    fireworkColour = DustID.Firework_Yellow;
					break;
				default:
					fireworkColour = DustID.Fireworks;
					break;
			}

			for (int i = 0; i < 25; i++)
            {
                Dust dust = Dust.NewDustDirect(Projectile.position, Projectile.width, Projectile.height, fireworkColour, Scale: 2.2f);
                dust.velocity *= 6;
                dust.noGravity = true;
            }
            
			// SOUND
			switch(Main.rand.Next(2))
			{
				case 0:
                    SoundEngine.PlaySound(SoundID.Item4, Projectile.position);
					break;
				case 1:
                    SoundEngine.PlaySound(SoundID.Item29, Projectile.position);
					break;
            }
			SoundEngine.PlaySound(SoundID.Item14);
			if(Main.rand.NextBool(10000000)) 
			{
				SoundEngine.PlaySound(SoundID.Zombie89);
			}
        }

		public override void OnHitNPC(NPC target, NPC.HitInfo hit, int damageDone)
		{
			int buffTime = 600;
            // 0: Blue
            // 1: Green
            // 2: Pink
            // 3: Red
            // 4: White
            // 5: Yellow
            switch (type)  // EFFECTS
			{
				case 0:
					target.AddBuff(BuffID.Frostburn2, buffTime);
					break;
                case 1:
                    target.AddBuff(BuffID.Poisoned, buffTime);
                    break;
                case 2:
                    target.AddBuff(BuffID.Confused, buffTime);
                    break;
                case 3:
                    target.AddBuff(BuffID.OnFire3, buffTime);
                    break;
                case 4:
                    target.AddBuff(BuffID.Slow, buffTime);
                    break;
                case 5:
                    target.AddBuff(BuffID.Ichor, buffTime);
                    break;
            }
            target.SimpleStrikeNPC(Main.rand.Next(1, 100), 0);
        }

		/*public void DuplicateProjectile(Vector2 oldVelocity)  // doesnt work
		{
            if (Projectile.owner == Main.myPlayer)
            {
                Projectile.Kill();

                int maxTimesToSpawn = maxSpawns;
                if (Main.rand.NextBool(3))  // Chance to duplicate
				{
					maxTimesToSpawn++;
				}
                for (int i = 1; i <= maxTimesToSpawn; i++)
                {
                    Vector2 newRandVelocity = new Vector2(oldVelocity.X * (Main.rand.NextFloat() * velMultiplier), oldVelocity.Y * (Main.rand.NextFloat() * velMultiplier));
                    float speedX = -newRandVelocity.X / maxSpawns * i;
                    float speedY = -newRandVelocity.Y / maxSpawns * i;

                    Projectile.NewProjectile(Projectile.GetSource_FromThis(), Projectile.Center.X, Projectile.Center.Y, speedX, speedY, ModContent.ProjectileType<MasterStaffProjectile>(), Projectile.damage, Projectile.knockBack);


					SoundStyle star = SoundID.Item4 with
                    {
                        Volume = 1f - (Main.rand.NextFloat() * 0.5f),
                        PitchVariance = 0.2f,
                        MaxInstances = 1,
                    };
                    SoundEngine.PlaySound(star, Projectile.position);

                }
            }
        }*/
    }
}