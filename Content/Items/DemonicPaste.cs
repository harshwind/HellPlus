using HellPlus.Content.Rarities;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace HellPlus.Content.Items
{
	public class DemonicPaste : ModItem
	{
		public override void SetStaticDefaults() {
			Item.ResearchUnlockCount = 2; 
		}

		public override void SetDefaults() {
			Item.width = 30;
			Item.height = 22;
			Item.maxStack = 9999;
            //Item.value = Item.sellPrice(silver: 5);  // was 1g66s
            Item.rare = ModContent.RarityType<HellRarity>();
		}

        public override void AddRecipes()
        {
            CreateRecipe()
                .AddIngredient(ModContent.ItemType<DemonFin>())
                .AddIngredient(ModContent.ItemType<DevilHorn>())
                .AddTile(TileID.Tables)
                .Register();
        }
    }
}