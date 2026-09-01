using HellPlus.Content.Buffs;
using Microsoft.Xna.Framework;
using System;
using System.Linq;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace HellPlus.Content.Items.Consumables
{
    public class BloodBrew : ModItem
    {
        readonly int[] bloodBrewEffects =  { BuffID.Archery, BuffID.Battle, BuffID.Builder, BuffID.Calm, BuffID.Crate, BuffID.Dangersense, BuffID.Endurance, BuffID.WellFed, BuffID.WellFed2,
                                            BuffID.WellFed3, BuffID.Featherfall, BuffID.Fishing, BuffID.Flipper, BuffID.Gills, BuffID.Gravitation, BuffID.Heartreach, BuffID.Hunter, BuffID.Inferno, BuffID.Invisibility,
                                            BuffID.Ironskin, BuffID.Lifeforce, BuffID.Lucky, BuffID.MagicPower, BuffID.ManaRegeneration, BuffID.Mining, BuffID.NightOwl, BuffID.ObsidianSkin, BuffID.Rage, BuffID.Regeneration,
                                            BuffID.Shine, BuffID.Sonar, BuffID.Spelunker, BuffID.Summoning, BuffID.Swiftness, BuffID.Thorns, BuffID.Titan, BuffID.Warmth, BuffID.WaterWalking, BuffID.Wrath,
                                            BuffID.Bleeding, BuffID.Darkness, BuffID.Blackout, BuffID.Silenced, BuffID.Cursed, BuffID.Confused, BuffID.Slow, BuffID.Weak };

        int[] times = { 26, 39, 52 };  // seconds
        
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
            Item.buffTime = 1559;
            Item.autoReuse = false;
        }


        public override void OnConsumeItem(Player player)
        {
            int randomIndex = Main.rand.Next(0, bloodBrewEffects.Length);  // choose a random buff
            int buffType = bloodBrewEffects[randomIndex];

            int randomTime = Main.rand.Next(0, times.Length);  // length of buff
            int buffTime = times[randomTime] * 60;

            player.AddBuff(buffType, buffTime);



        }
    }

  
}