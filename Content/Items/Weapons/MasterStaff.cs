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
    public class MasterStaff : ModItem
    {
        public override void SetStaticDefaults()
        {
            Item.staff[Type] = true; 
        }

        public override void SetDefaults()
        {
            Item.DefaultToStaff(ModContent.ProjectileType<MasterStaffProjectile>(), 20, 15, 30);
            Item.UseSound = SoundID.Item20;
            Item.SetWeaponValues(250, 6);
            Item.rare = ModContent.RarityType<HellRarity>();
            //Item.value = Item.buyPrice(gold: 2, silver: 57, copper: 60);

            Item.UseSound = new SoundStyle("HellPlus/Assets/Sounds/Items/Magic/Flame")
            {
                Volume = 1.0f,
                PitchVariance = 0.2f,
                MaxInstances = 3,
            };
        }

        public override void AddRecipes()
        {
            CreateRecipe()
                .AddIngredient(ModContent.ItemType<GrandeStaff>())
                .AddIngredient(ModContent.ItemType<MagmiumBar>(), 8)
                .AddTile(TileID.LunarCraftingStation)
                .Register();
        }
    }
}