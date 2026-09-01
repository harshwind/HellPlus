using HellPlus.Content.Rarities;
using Steamworks;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace HellPlus.Content.Items.Placeable
{
	public class MagmiumOre : ModItem
	{
		public override void SetStaticDefaults() {
			Item.ResearchUnlockCount = 100;
			ItemID.Sets.SortingPriorityMaterials[Item.type] = 58;
			
			ItemID.Sets.IsLavaImmuneRegardlessOfRarity[Item.type] = true;
			
		}

		public override void SetDefaults() {
			Item.DefaultToPlaceableTile(ModContent.TileType<Tiles.MagmiumOre>());
			Item.width = 12;
			Item.height = 12;
			//Item.value = Item.sellPrice(silver: 20);
			Item.rare = ModContent.RarityType<HellRarity>();			
        }

       

    }
}