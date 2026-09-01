using HellPlus.Content.Items.Placeable;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace HellPlus.Content.Items.Tools
{
    public class CooledMagmiumWarhamaxe : ModItem
    {
        public override void SetDefaults()
        {
            Item.damage = 85;
            Item.DamageType = DamageClass.Melee;
            Item.width = 45;
            Item.height = 38;
            Item.useTime = 14;
            Item.useAnimation = 27;
            Item.useStyle = ItemUseStyleID.Swing;
            Item.knockBack = 7;
            Item.rare = ItemRarityID.Cyan;
            Item.UseSound = SoundID.Item1;
            Item.autoReuse = true; // Automatically re-swing/re-use this item after its swinging animation is over.

            Item.value = Item.sellPrice(gold: 1, silver: 46, copper: 40);
            Item.axe = 29; // How much axe power the weapon has, note that the axe power displayed in-game is this value multiplied by 5
            Item.hammer = 70; // How much hammer power the weapon has
            Item.attackSpeedOnlyAffectsWeaponAnimation = true; // Melee speed affects how fast the tool swings for damage purposes, but not how fast it can dig
        }


        public override void AddRecipes()
        {
            CreateRecipe()
                .AddIngredient(ModContent.ItemType<CooledMagmiumBar>(), 12)
                .AddTile(TileID.MythrilAnvil)
                .Register();
        }
    }
}