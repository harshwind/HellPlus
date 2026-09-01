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
using System.Linq;

namespace HellPlus.Content.Projectiles
{
	public class HellBall : ModProjectile
	{
		public override void SetDefaults() {
			Projectile.width = 48;
			Projectile.height = 48;
			Projectile.friendly = true;
			Projectile.DamageType = DamageClass.Magic;
			Projectile.penetrate = 99;
			Projectile.timeLeft = 180;
			Projectile.tileCollide = true;
			Projectile.light = 1f;			
		}
		
        /*public override void SetStaticDefaults()
        {
            Main.projFrames[Projectile.type] = 9; 
        }*/



        public override void AI()
        {
            // Generate dust
            int dustToSpawn = 5;
            for (int i = 0; i < dustToSpawn; i++)
            {
                Dust dust = Dust.NewDustDirect(Projectile.position, Projectile.width, Projectile.height, DustID.InfernoFork, Scale: 1f);
                dust.noGravity = true;
            }

            // Break nearby tiles
            int blocksBroken = 0;
            int breakRadiusInBlocks = 3;
            int maxBlocksToBreak = 100;

            int minX = (int)(Projectile.Center.X / 16f) - breakRadiusInBlocks;
            int maxX = (int)(Projectile.Center.X / 16f) + breakRadiusInBlocks;
            int minY = (int)(Projectile.Center.Y / 16f) - breakRadiusInBlocks;
            int maxY = (int)(Projectile.Center.Y / 16f) + breakRadiusInBlocks;

            for (int x = minX; x <= maxX; x++)
            {
                for (int y = minY; y <= maxY; y++)
                {
                    if (blocksBroken >= maxBlocksToBreak)
                    {
                        Projectile.Kill();
                        x = maxX; y = maxY;
                    }

                    if (WorldGen.InWorld(x, y) && Main.tile[x, y] != null)
                    {
                        // random dust 
                        if (Main.rand.NextBool(400))
                        {
                            Vector2 xy = new Vector2((int)x*16f, (int)y*16f);
                            Dust bDust = Dust.NewDustDirect(Projectile.position, Projectile.width+2, Projectile.height+2, DustID.InfernoFork, Scale: 1.9f);
                            bDust.noGravity = true;
                        }

                        // DESTROY
                        //Main.NewText(string.Format("Killing tile x{0} y{1}", x,y));
                        WorldGen.KillTile(x, y, false, false, false);
                        if (Main.netMode == NetmodeID.MultiplayerClient)
                        {
                            NetMessage.SendTileSquare(-1, x, y, 1);
                            //NetMessage.SendData(MessageID.TileManipulation, -1, -1, null, 0, x, y, 0f, 0, 0, 0);
                        }
                        blocksBroken++;
                    }
                }
            }

            // Animated sprite
            /*int speed = 20;
            Projectile.frameCounter++;
            if (Projectile.frameCounter >= speed)
            {
                Projectile.frameCounter = 0;
                Projectile.frame++;
                if (Projectile.frame >= Main.projFrames[Projectile.type])
                {
                    Projectile.frame = 0;
                }
            }*/

            // SOUNDS

            if (Main.rand.NextBool(225))
            {
                SoundStyle heartbeat = new SoundStyle("HellPlus/Assets/Sounds/Items/Hell/HeartbeatSpecial")
                {
                    Volume = 0.4f,
                    PitchVariance = 0.6f,
                    MaxInstances = 0,
                };
                SoundEngine.PlaySound(heartbeat, Projectile.Center);
            }
            if (Projectile.ai[0] >= 27)
            {
                Projectile.ai[0] = 0;
                SoundStyle heartbeat = new SoundStyle("HellPlus/Assets/Sounds/Items/Hell/Splash_3")
                {
                    Volume = 0.9f,
                    PitchVariance = 0.6f,
                    MaxInstances = 0,
                };
                SoundEngine.PlaySound(heartbeat, Projectile.Center);
            }
            Projectile.ai[0]++;
        }
        

		public override void OnKill(int timeLeft) {
            for (int i = 0; i < 10; i++)  // SMOKE DUST
            {
                Dust dust = Dust.NewDustDirect(Projectile.position, Projectile.width, Projectile.height, DustID.Smoke, Scale: 1.2f);
                dust.velocity *= 3;
                
            }

			for (int i = 0; i < 25; i++)  // FIREWORK DUST
            {
                Dust dust = Dust.NewDustDirect(Projectile.position, Projectile.width, Projectile.height, DustID.Firework_Red, Scale: 2f);
                dust.velocity *= 6;
                dust.noGravity = true;
            }

			// SOUND
			//switch(Main.rand.Next(2))
			//{
			//	case 0:
                    SoundEngine.PlaySound(SoundID.Item14, Projectile.position);
			//		break;
			//	case 1:
            //        SoundEngine.PlaySound(SoundID.SplashWeak, Projectile.position);
			//		break;
            //}
        }

		public override void OnHitNPC(NPC target, NPC.HitInfo hit, int damageDone)
		{
			target.AddBuff(BuffID.OnFire3, 10);
            
            target.SimpleStrikeNPC(Main.rand.Next(80, 90), 0);
        }

    }
}