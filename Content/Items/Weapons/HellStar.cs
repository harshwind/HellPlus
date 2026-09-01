using HellPlus.Content.Items.Placeable;
using HellPlus.Content.Projectiles;
using HellPlus.Content.Rarities;
using Terraria;
using Terraria.Audio;
using Terraria.Enums;
using Terraria.ID;
using Terraria.ModLoader;

namespace HellPlus.Content.Items.Weapons
{
    public class HellStar : ModItem
    {
        public override void SetDefaults()
        {
            Item.DefaultToThrownWeapon(ModContent.ProjectileType<HellStarProjectile>(), 20, 15);
            Item.SetWeaponValues(18, 0);
            Item.rare = ModContent.RarityType<HellRarity>();
            Item.value = Item.buyPrice(copper: 10);

            Item.UseSound = SoundID.Item1;
        }

        /*public override void AddRecipes()   maybe use
        {
            CreateRecipe()
                .AddIngredient(ItemID.Shuriken, 50)
                .AddIngredient(ItemID.HellstoneBar)
                .AddTile(TileID.Anvils)
                .Register();
        }*/
    }
}