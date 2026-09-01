using HellPlus.Content.Rarities;
using HellPlus.Content.Tiles;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace HellPlus.Content.Items.Placeable
{
    public class MagmiumBrick: ModItem
    {
        public override void SetStaticDefaults()
        {
            Item.ResearchUnlockCount = 100;
            ItemID.Sets.SortingPriorityMaterials[Item.type] = 59;
        }

        public override void SetDefaults()
        {
            Item.DefaultToPlaceableTile(ModContent.TileType<Tiles.MagmiumBrick>());
            Item.width = 12;
            Item.height = 12;
			Item.rare = ModContent.RarityType<HellRarity>();
        }

        public override void AddRecipes()
        {
            CreateRecipe(5)
                .AddIngredient(ModContent.ItemType<MagmiumOre>())
                .AddIngredient(ItemID.StoneBlock, 5)
                .AddTile(ModContent.TileType<PentagramPlaced>())  // CHANGE TO CUSTOM CRAFT!
                .Register();
        }
    }
}