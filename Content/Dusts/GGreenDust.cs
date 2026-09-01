using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace HellPlus.Content.Dusts
{
    public class GGreenDust : ModDust
    {
        public override void OnSpawn(Dust dust)
        {
            dust.velocity *= 0.8f;
            dust.noGravity = true;
            dust.noLight = true;
            dust.scale = 1.0f;
        }

        public override bool Update(Dust dust)
        { // Calls every frame the dust is active
            dust.position += dust.velocity;
            dust.rotation += dust.velocity.X * 0.5f;
            dust.scale *= 0.99f;
            
            float light = 0.95f * dust.scale;

            Lighting.AddLight(dust.position, 0.5f, 0.5f, 1f);

            if (dust.scale < 0.9f)
            {
                dust.active = false;
            }

            return false; // Return false to prevent vanilla behavior.
        }
    }
}