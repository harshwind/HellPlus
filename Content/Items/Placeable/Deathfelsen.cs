using Terraria;
using Terraria.GameContent;
using Terraria.ID;
using Terraria.ModLoader;

namespace HellPlus.Content.Items.Placeable
{
	public class Deathfelsen : ModItem
	{
		public override void SetStaticDefaults() {
			Item.ResearchUnlockCount = 100;
        }

		public override void SetDefaults() {
			Item.DefaultToPlaceableTile(ModContent.TileType<Tiles.Deathfelsen>());
			Item.width = 20;
			Item.height = 20;
            ItemID.Sets.IsLavaImmuneRegardlessOfRarity[Item.type] = true;
        }
	}
}
