using HellPlus.Content.Items.Placeable;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Audio;
using Terraria.ID;
using Terraria.ModLoader;

namespace HellPlus.Content.Items.Weapons
{
    public class CM47 : ModItem
    {
        public override void SetDefaults()
        {
            Item.width = 66; 
            Item.height = 22; 
            Item.scale = 0.75f;
            Item.rare = ItemRarityID.Cyan; 
            Item.SetNameOverride("CM-47");
            
            Item.useTime = 3; 
            Item.useAnimation = 9; 
            Item.useStyle = ItemUseStyleID.Shoot; 
            Item.autoReuse = true; 
            Item.reuseDelay = 14;
            Item.consumeAmmoOnLastShotOnly = true;

            
            Item.UseSound = new SoundStyle($"{nameof(HellPlus)}/Assets/Sounds/Items/Guns/GunBurst")
            {
                Volume = 1.0f,
                PitchVariance = 0.2f,
                MaxInstances = 3,
            };

            
            Item.DamageType = DamageClass.Ranged; 
            Item.damage = 74; 
            //Item.knockBack = 5f; 
            Item.noMelee = true;

            Item.shoot = ProjectileID.PurificationPowder; 
            Item.shootSpeed = 16f; 
            Item.useAmmo = AmmoID.Bullet; 

            Item.sellPrice(gold: 4, silver: 22);
        }

        public override void AddRecipes()
        {
            CreateRecipe()
                .AddIngredient(ModContent.ItemType<CooledMagmiumBar>(), 10)
                .AddIngredient(ItemID.ClockworkAssaultRifle)
                .AddTile(TileID.MythrilAnvil)
                .Register();
        }

        public override Vector2? HoldoutOffset()
        {
            return new Vector2(2f, -2.1f);
        }
    }
}