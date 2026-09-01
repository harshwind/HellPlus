using HellPlus.Content.Dusts;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Enums;
using Terraria.ID;
using Terraria.ModLoader;

namespace HellPlus.Content.Projectiles
{

    public class HellStarProjectile : ModProjectile
    {
        public override void SetDefaults()
        {
            Projectile.width = 22;
            Projectile.height = 22;
            Projectile.aiStyle = ProjAIStyleID.ThrownProjectile;
            //AIType = ProjectileID.Shuriken;
            Projectile.friendly = true;
            Projectile.DamageType = DamageClass.Ranged;
            Projectile.penetrate = 1;
        }

        public override void AI()
        {
            if (Main.rand.NextBool(2)) {
                Dust dust = Dust.NewDustDirect(Projectile.Center, Projectile.width, Projectile.height, DustID.Lava, 0f, 0f, 1, default(Color), 0.2f);
                dust.noGravity = true;
            }
            
        }

        public override void OnHitNPC(NPC target, NPC.HitInfo hit, int damageDone)
        {
            target.AddBuff(BuffID.OnFire, 222);
        }
    }
}