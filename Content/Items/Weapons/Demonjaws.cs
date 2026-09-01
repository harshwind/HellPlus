using HellPlus.Content.Items.Placeable;
using HellPlus.Content.Rarities;
using Microsoft.Xna.Framework;
using System.Net.Http.Headers;
using Terraria;
using Terraria.Audio;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace HellPlus.Content.Items.Weapons
{
    public class Demonjaws : ModItem
    {
        public override void SetDefaults()
        {
            Item.width = 92;
            Item.height = 34;
            Item.scale = 1f;
            Item.rare = ModContent.RarityType<HellRarity>();
            ItemID.Sets.IsLavaImmuneRegardlessOfRarity[Item.type] = true;

            Item.useTime = 6;
            Item.useAnimation = 6;
            Item.useStyle = ItemUseStyleID.Shoot;
            Item.autoReuse = true;
            Item.UseSound = SoundID.Item11;


            Item.DamageType = DamageClass.Ranged;
            Item.damage = 27;
            Item.knockBack = 1f;
            Item.noMelee = true;

            Item.shoot = ProjectileID.PurificationPowder;
            Item.shootSpeed = 16f;
            Item.useAmmo = AmmoID.Bullet;


            Item.sellPrice(gold: 7, silver: 22);
        }

        public override void AddRecipes()
        {
            CreateRecipe()
                .AddIngredient(ModContent.ItemType<DemonFin>(), 5)
                .AddIngredient(ItemID.Megashark)
                .AddTile(TileID.MythrilAnvil)
                .Register();
        }

        public override Vector2? HoldoutOffset()
        {
            return new Vector2(2f, -2f);
        }
        public override bool CanConsumeAmmo(Item ammo, Player player)
        {
            return Main.rand.NextFloat() >= 0.6f;
        }

        public override void ModifyShootStats(Player player, ref Vector2 position, ref Vector2 velocity, ref int type, ref int damage, ref float knockback)
        {
            player.AddBuff(BuffID.Inferno, 299);
        }
    }
}