using HellPlus.Content.Tiles;
using HellPlus.Content.Walls;
using Terraria;
using Terraria.ModLoader;

namespace HellPlus.Content.Items.Placeable
{
    public class MagmiumBrickWall : ModItem
    {
        public override void SetStaticDefaults()
        {
            Item.ResearchUnlockCount = 400;
        }

        public override void SetDefaults()
        {
            Item.DefaultToPlaceableWall(ModContent.WallType<Walls.MagmiumBrickWall>());
        }

        public override void AddRecipes()
        {
            CreateRecipe(4)
                .AddIngredient(ModContent.ItemType<MagmiumBrick>())
                .AddTile(ModContent.TileType<PentagramPlaced>())  
                .Register();
        }
    }
}