using HellPlus.Content.Items.Placeable;
using HellPlus.Content.Projectiles;
using Terraria;
using Terraria.Audio;
using Terraria.Enums;
using Terraria.ID;
using Terraria.ModLoader;

namespace HellPlus.Content.Items.Weapons
{
    // ExampleStaff is a typical staff. Staffs and other shooting weapons are very similar, this example serves mainly to show what makes staffs unique from other items.
    // Staff sprites, by convention, are angled to point up and to the right. "Item.staff[Type] = true;" is essential for correctly drawing staffs.
    // Staffs use mana and shoot a specific projectile instead of using ammo. Item.DefaultToStaff takes care of that.
    public class GrandeStaff : ModItem
    {
        public override void SetStaticDefaults()
        {
            Item.staff[Type] = true; // This makes the useStyle animate as a staff instead of as a gun.
        }

        public override void SetDefaults()
        {
            // DefaultToStaff handles setting various Item values that magic staff weapons use.
            // Hover over DefaultToStaff in Visual Studio to read the documentation!
            Item.DefaultToStaff(ModContent.ProjectileType<GrandeStaffProjectile>(), 16, 25, 31);

            // Customize the UseSound. DefaultToStaff sets UseSound to SoundID.Item43, but we want SoundID.Item20
            Item.UseSound = SoundID.Item20;

            // Set damage and knockBack
            Item.SetWeaponValues(88, 4);

            // Set rarity and value
            Item.rare = ItemRarityID.Cyan;
            Item.value = Item.buyPrice(gold: 2, silver: 57, copper: 60);

            Item.UseSound = new SoundStyle($"{nameof(HellPlus)}/Assets/Sounds/Items/Magic/Flame")
            {
                Volume = 1.0f,
                PitchVariance = 0.2f,
                MaxInstances = 3,
            };
        }

        public override void AddRecipes()
        {
            CreateRecipe()
                .AddIngredient(ItemID.AmberStaff)
                .AddIngredient(ItemID.AmethystStaff)
                .AddIngredient(ItemID.DiamondStaff)
                .AddIngredient(ItemID.EmeraldStaff)
                .AddIngredient(ItemID.RubyStaff)
                .AddIngredient(ItemID.SapphireStaff)
                .AddIngredient(ItemID.TopazStaff)
                .AddIngredient(ModContent.ItemType<CooledMagmiumBar>(), 8)
                .AddTile(TileID.MythrilAnvil)
                .Register();
        }
    }
}