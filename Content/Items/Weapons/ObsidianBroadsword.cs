using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using HellPlus.Content.Projectiles;

namespace HellPlus.Content.Items.Weapons
{ 
	public class ObsidianBroadsword : ModItem
	{
		public override void SetDefaults()
		{
			Item.width = 40; 
			Item.height = 40; 

			Item.useStyle = ItemUseStyleID.Swing; 
			Item.useTime = 20; 
			Item.useAnimation = 20; 
			Item.autoReuse = false; 

			Item.DamageType = DamageClass.Melee; 
			Item.damage = 20; 
			Item.knockBack = 6f; 

			//Item.value = Item.buyPrice(gold: 1); 
			Item.rare = ItemRarityID.White;
			Item.UseSound = SoundID.Item1; 
		}

		public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ItemID.Obsidian, 26);
			recipe.AddTile(TileID.Anvils);
			recipe.Register();
			
		}
	}
}
