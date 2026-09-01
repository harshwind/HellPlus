using HellPlus.Content.Projectiles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria.Audio;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria;
using HellPlus.Content.Rarities;
using Microsoft.Build.Tasks.Deployment.ManifestUtilities;

namespace HellPlus.Content.Items.Tools
{
    public class BookOfRevelation : ModItem
    {
        public override void SetStaticDefaults()
        {
            Item.staff[Type] = true;
        }

        public override void SetDefaults()
        {
            Item.DefaultToStaff(ModContent.ProjectileType<HellBall>(), 6, 25, 70);  // 25
            Item.UseSound = SoundID.Item43;
            Item.SetWeaponValues(120, 0);
            Item.rare = ModContent.RarityType<HellRarity>();
            //Item.value = Item.buyPrice(gold: 2, silver: 57, copper: 60);

            Item.UseSound = new SoundStyle("HellPlus/Assets/Sounds/Items/Magic/Flame")
            {
                Volume = 1.0f,
                PitchVariance = 0.2f,
                MaxInstances = 3,
            };
        }

       /*public override bool AltFunctionUse(Player player)
        {
            return true;
        }



        public override bool? UseItem(Player player)
        {
            if (player.whoAmI != Main.myPlayer)
            {
                return true;
            }

            if (player.altFunctionUse == 2)
            {
                foreach (Projectile projectile in Main.projectile)
                {
                    if (projectile.type == ModContent.ProjectileType<HellBall>() && projectile.owner == Main.myPlayer)
                    {
                        Main.NewText("Killing projectile at: " + projectile.position);
                        projectile.Kill();
                    }
                }
                return true;
            }
            return base.CanUseItem(player);
        }*/
    }
}
