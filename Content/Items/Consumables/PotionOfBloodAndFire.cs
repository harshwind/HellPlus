using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace HellPlus.Content.Items.Consumables
{
    public class PotionOfBloodAndFire : ModItem
    {
        public override void SetStaticDefaults()
        {
            Item.ResearchUnlockCount = 20;

            
            ItemID.Sets.DrinkParticleColors[Type] = new Color[3] {
                new Color(240, 240, 240),
                new Color(200, 200, 200),
                new Color(140, 140, 140)
            };
        }

        public override void SetDefaults()
        {
            Item.width = 20;
            Item.height = 26;
            Item.useStyle = ItemUseStyleID.DrinkLiquid;
            Item.useAnimation = 15;
            Item.useTime = 15;
            Item.useTurn = true;
            Item.UseSound = SoundID.Item3;
            Item.maxStack = Item.CommonMaxStack;
            Item.consumable = true;
            Item.rare = ItemRarityID.Orange;
            Item.value = Item.buyPrice(gold: 1);
            Item.buffType = ModContent.BuffType<Buffs.Fury>(); 
            Item.buffTime = 5400; 
        }
    }
}