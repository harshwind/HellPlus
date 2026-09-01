using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using HellPlus.Content.Projectiles;

namespace HellPlus.Content.Items.Weapons
{ 
	public class ObsidianShortsword : ModItem
	{
		public override void SetDefaults()
		{
			Item.width = 32;
			Item.height = 32;

			Item.useStyle = ItemUseStyleID.Rapier;
			Item.useTime = 12;
			Item.useAnimation = 12;
			Item.autoReuse = false;

			Item.DamageType = DamageClass.MeleeNoSpeed;
			Item.damage = 17;
			Item.knockBack = 4f;
			
			//Item.value = Item.buyPrice(?)
			Item.rare = ItemRarityID.White;
			Item.UseSound = SoundID.Item1;

			Item.noUseGraphic = true;
			Item.noMelee = true; 
			

			Item.shoot = ModContent.ProjectileType<ObsidianShortswordProjectile>(); 
			Item.shootSpeed = 2.1f; // This value bleeds into the behavior of the projectile as velocity, keep that in mind when tweaking values
		}

		public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ItemID.Obsidian, 20);
			recipe.AddTile(TileID.Anvils);
			recipe.Register();
		}
	}
}
