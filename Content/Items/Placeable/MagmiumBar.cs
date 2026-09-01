using HellPlus.Content.Rarities;
using Terraria;
using Terraria.GameContent;
using Terraria.ID;
using Terraria.ModLoader;

namespace HellPlus.Content.Items.Placeable
{
	public class MagmiumBar : ModItem
	{
		public override void SetStaticDefaults() {
			Item.ResearchUnlockCount = 25;
			ItemID.Sets.SortingPriorityMaterials[Item.type] = 62; 

        }

		public override void SetDefaults() {
			Item.DefaultToPlaceableTile(ModContent.TileType<Tiles.MagmiumBar>());
			Item.width = 20;
			Item.height = 20;
            Item.rare = ModContent.RarityType<HellRarity>();
            ItemID.Sets.IsLavaImmuneRegardlessOfRarity[Item.type] = true;
        }

		public override void AddRecipes() {
			CreateRecipe()
				.AddIngredient<MagmiumOre>(3)
				.AddTile(TileID.Hellforge)
                .AddCustomShimmerResult(ModContent.ItemType<Content.Items.Placeable.CooledMagmiumBar>())
                .Register();
		}
	}
}
