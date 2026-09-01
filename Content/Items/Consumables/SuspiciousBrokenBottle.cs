using HellPlus.Content.Buffs;
using Microsoft.Xna.Framework;
using System;
using System.Linq;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace HellPlus.Content.Items.Consumables
{
    public class SuspiciousBrokenBottle : ModItem
    {
        readonly int[] debuffs = { BuffID.Bleeding, BuffID.Poisoned, BuffID.Venom, BuffID.Darkness, BuffID.Blackout, BuffID.Silenced, BuffID.Cursed, BuffID.Confused, BuffID.Slow, BuffID.Weak };
        readonly int[] buffs = { BuffID.AmmoReservation, BuffID.Archery, BuffID.Battle, BuffID.Builder, BuffID.Calm, BuffID.Crate, BuffID.Dangersense, BuffID.Endurance, BuffID.WellFed, BuffID.WellFed2, BuffID.WellFed3, BuffID.Featherfall, BuffID.Fishing, BuffID.Flipper, BuffID.Gills, BuffID.Gravitation, BuffID.Heartreach, BuffID.Hunter, BuffID.Inferno, BuffID.Invisibility, BuffID.Ironskin, BuffID.Lifeforce, BuffID.Lucky, BuffID.MagicPower, BuffID.ManaRegeneration, BuffID.Mining, BuffID.NightOwl, BuffID.ObsidianSkin, BuffID.Rage, BuffID.Regeneration, BuffID.Shine, BuffID.Sonar, BuffID.Spelunker, BuffID.Summoning, BuffID.Swiftness, BuffID.Thorns, BuffID.Titan, BuffID.Warmth, BuffID.WaterWalking, BuffID.Wrath, BuffID.WeaponImbueConfetti, BuffID.WeaponImbueCursedFlames, BuffID.WeaponImbueFire, BuffID.WeaponImbueGold, BuffID.WeaponImbueIchor, BuffID.WeaponImbueNanites, BuffID.WeaponImbuePoison, BuffID.WeaponImbueVenom };
        readonly int[] susBrokenBottleEffects = { BuffID.Poisoned, BuffID.Darkness, BuffID.Blackout, BuffID.Silenced, BuffID.Cursed, BuffID.Confused, BuffID.Slow, BuffID.Weak, BuffID.Archery, BuffID.Calm, BuffID.Dangersense, BuffID.WellFed, BuffID.WellFed2, BuffID.Featherfall, BuffID.Flipper, BuffID.Gills, BuffID.Gravitation, BuffID.Heartreach, BuffID.Hunter, BuffID.Inferno, BuffID.Ironskin, BuffID.Lifeforce, BuffID.MagicPower, BuffID.NightOwl, BuffID.Regeneration,  BuffID.Spelunker, BuffID.Swiftness, BuffID.Thorns, BuffID.Titan };
    
        int[] times = { 13, 26, 39 };  // seconds
        
        public override void SetStaticDefaults()
        {
            Item.ResearchUnlockCount = 20;

            
            ItemID.Sets.DrinkParticleColors[Type] = new Color[3] {
                new Color(108, 0, 0),
                new Color(93, 0, 0),
                new Color(57, 0, 0)
            };
        }

        public override void SetDefaults()
        {
            
            Item.width = 20;
            Item.height = 18;
            Item.useStyle = ItemUseStyleID.DrinkLiquid;
            Item.useAnimation = 15;
            Item.useTime = 15;
            Item.useTurn = true;
            Item.UseSound = SoundID.Item3;
            Item.maxStack = Item.CommonMaxStack;
            Item.consumable = true;
            Item.rare = ItemRarityID.Orange;
            Item.buffType = ModContent.BuffType<Randomness>();
            Item.buffTime = 779;
            Item.autoReuse = false;
        }


        public override void OnConsumeItem(Player player)
        {
            int randomIndex = Main.rand.Next(0, susBrokenBottleEffects.Length);  // choose a random buff
            int buffType = susBrokenBottleEffects[randomIndex];

            int randomTime = Main.rand.Next(0, times.Length);  // length of buff
            int buffTime = times[randomTime] * 60;

            player.AddBuff(buffType, buffTime);



        }
    }

  
}