using Terraria;
using Terraria.GameContent;
using Terraria.ID;
using Terraria.ModLoader;


namespace HellPlus.Content.Items.Placeable
{
	public class CooledMagmiumBar : ModItem
	{
		public override void SetStaticDefaults() {
			Item.ResearchUnlockCount = 25;
			ItemID.Sets.SortingPriorityMaterials[Item.type] = 62;
            ItemID.Sets.ShimmerTransformToItem[Type] = ModContent.ItemType<MagmiumBar>();
        }

		public override void SetDefaults() {
			Item.DefaultToPlaceableTile(ModContent.TileType<Tiles.CooledMagmiumBar>());
			Item.width = 20;
			Item.height = 20;
			Item.value = Item.sellPrice(silver: 61);
            Item.rare = ItemRarityID.Cyan;
        }

		public override void AddRecipes() {
            Recipe recipe1 = CreateRecipe();
			recipe1.AddIngredient<MagmiumBar>(1);
			recipe1.AddCondition(Condition.NearWater);
            recipe1.Register();

            Recipe recipe2 = CreateRecipe();
            recipe2.AddIngredient<CooledMagmiumOre>(3);
            recipe2.AddTile(TileID.MythrilAnvil);
            recipe2.Register();


        }
	}
}
