using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace HellPlus.Content.Items.Placeable
{
	public class CooledMagmiumOre : ModItem
	{
		public override void SetStaticDefaults() {
			Item.ResearchUnlockCount = 100;
			ItemID.Sets.SortingPriorityMaterials[Item.type] = 58;

            ItemID.Sets.ShimmerTransformToItem[Type] = ModContent.ItemType<MagmiumOre>();
        }

		public override void SetDefaults() {
            Item.DefaultToPlaceableTile(ModContent.TileType<Tiles.CooledMagmiumOre>());
            Item.width = 12;
			Item.height = 12;
			Item.value = Item.sellPrice(silver: 20);
            Item.rare = ItemRarityID.Cyan;
        }
        public override void AddRecipes()
        {
            CreateRecipe()
                .AddIngredient<MagmiumOre>(1)
                .AddCondition(Condition.NearWater)
                .Register();
        }

    }
}