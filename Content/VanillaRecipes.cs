using HellPlus.Content.Items;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace HellPlus.Content
{
	public class VanillaRecipes : ModSystem
	{
		public override void AddRecipes()
		{
			Recipe recipe = Recipe.Create(ItemID.DevilHorns);
			recipe.AddIngredient(ModContent.ItemType<DevilHorn>(), 2);
			recipe.AddTile(TileID.WorkBenches);
            recipe.Register();
		}
	}
}