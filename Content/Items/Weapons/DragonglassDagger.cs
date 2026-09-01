using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using HellPlus.Content.Projectiles;
using HellPlus.Content.Items.Weapons;

namespace HellPlus.Content.Items.Weapons
{ 
	public class DragonglassDagger : ModItem
	{
		public override void SetDefaults()
		{
			Item.width = 34;
			Item.height = 34;

			Item.useStyle = ItemUseStyleID.Rapier;
			Item.useTime = 10;
			Item.useAnimation = 10;
			Item.autoReuse = false;

			Item.DamageType = DamageClass.MeleeNoSpeed;
			Item.damage = 147;
			Item.knockBack = 4f;
			Item.crit = 20;
			Item.autoReuse = true;

            //Item.value = Item.sellPrice(gold: 2, silver: 33);
            Item.value = Item.sellPrice(gold: 1, silver: 22);
            Item.rare = ItemRarityID.Cyan;
			Item.UseSound = SoundID.Item1;

			Item.noUseGraphic = true;
			Item.noMelee = true; 
			

			Item.shoot = ModContent.ProjectileType<DragonglassDaggerProjectile>(); 
			Item.shootSpeed = 2.1f; // This value bleeds into the behavior of the projectile as velocity, keep that in mind when tweaking values
		}

		public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ModContent.ItemType<Content.Items.Weapons.ObsidianShortsword>());
			recipe.AddIngredient(ModContent.ItemType<Content.Items.Placeable.CooledMagmiumBar>(), 10);
			recipe.AddTile(TileID.MythrilAnvil);
            recipe.Register();
		}
	}
}
