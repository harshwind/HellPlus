// Content/Items/Weapons/Magmaul.cs
using HellPlus.Content.Items.Placeable;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;


namespace HellPlus.Content.Items.Weapons
{
    public class Magmaul : ModItem
    {
        public override void SetDefaults()
        {
            Item.width = 40;
            Item.height = 40;


            Item.useStyle = ItemUseStyleID.Swing;
            Item.useTime = 15;
            Item.useAnimation = 15;
            Item.autoReuse = true;


            Item.DamageType = DamageClass.Melee;
            Item.damage = 200;
            Item.knockBack = 8f;


            Item.value = Item.buyPrice(gold: 10);
            Item.rare = ItemRarityID.Red;
            Item.UseSound = SoundID.Item1;
        }


        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ItemID.TerraBlade);
            recipe.AddIngredient(ModContent.ItemType<MagmiumBar>(), 12);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.Register();
        }
    }
}