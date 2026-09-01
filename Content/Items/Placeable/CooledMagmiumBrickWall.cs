using HellPlus.Content.Tiles;
using HellPlus.Content.Walls;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace HellPlus.Content.Items.Placeable
{
    public class CooledMagmiumBrickWall : ModItem
    {
        public override void SetStaticDefaults()
        {
            Item.ResearchUnlockCount = 400;
        }

        public override void SetDefaults()
        {
            Item.DefaultToPlaceableWall(ModContent.WallType<Walls.CooledMagmiumBrickWall>());
        }

        public override void AddRecipes()
        {
            CreateRecipe(4)
                .AddIngredient(ModContent.ItemType<CooledMagmiumBrick>())
                .AddTile(TileID.MythrilAnvil)
                .Register();
        }
    }
}