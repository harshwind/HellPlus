using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace HellPlus.Content.Items.Placeable
{
    public class CooledMagmiumBrick : ModItem
    {
        public override void SetStaticDefaults()
        {
            Item.ResearchUnlockCount = 100;
            ItemID.Sets.SortingPriorityMaterials[Item.type] = 59;
        }

        public override void SetDefaults()
        {
            Item.DefaultToPlaceableTile(ModContent.TileType<Tiles.CooledMagmiumBrick>());
            Item.width = 12;
            Item.height = 12;
        }

        public override void AddRecipes()
        {
            CreateRecipe(5)
                .AddIngredient(ModContent.ItemType<CooledMagmiumOre>())
                .AddIngredient(ItemID.StoneBlock, 5)
                .AddTile(TileID.Furnaces)
                .Register();
        }
    }
}