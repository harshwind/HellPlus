using System.Numerics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace HellPlus.Content.Buffs
{
    public class Fury : ModBuff
    {
        public static readonly int range = 550;
        public static readonly int rangeSquared = range * range;
        public static readonly int enemyBurnTime = 300;
        public static readonly int decrementDefenseTicks = 60;

        public override void SetStaticDefaults()
        {
            Main.buffNoSave[Type] = true;
        }
        public override void Update(Player player, ref int buffIndex)
        {
            FuryBuffPlayer p = player.GetModPlayer<FuryBuffPlayer>();

            // Burn all onscreen enemies
            foreach (NPC npc in Main.ActiveNPCs)
            {
                if (npc.CanBeChasedBy())
                {
                    Vector2 vec = new Vector2(player.Center.X, player.Center.Y);
                    Vector2 vec2 = new Vector2(npc.Center.X, npc.Center.Y);
                    float distanceToTarget = Vector2.DistanceSquared(vec, vec2);

                    if (distanceToTarget < rangeSquared)  // If in range
                    {
                        npc.AddBuff(BuffID.OnFire3, enemyBurnTime);  // Add fire buff
                    }
                }
            }

            if (!p.hadFuryBuffLastTick)
            {
                // Reset buff as it is no longer active
                p.timer = -1;
                p.defenseReduction = 0;
            }

            if (p.timer % decrementDefenseTicks == 0)
            {
                // Decrement defence every X ticks 
                if (player.statDefense >= 0)
                {
                    p.defenseReduction--;
                }
            }

            player.statDefense += p.defenseReduction;

            p.timer++;
        }
    }

    public class FuryBuffPlayer : ModPlayer
    {
        public int timer;
        public int defenseReduction;
        public bool hadFuryBuffLastTick;

        public override void UpdateDead()
        {
            // Reset buff upon player death
            timer = 0;
            defenseReduction = 0;
            hadFuryBuffLastTick = false;
        }

        public override void PostUpdateBuffs()
        {
            // Track if player had Fury buff last tick
            if (Player.HasBuff(ModContent.BuffType<Buffs.Fury>()))
            {
                hadFuryBuffLastTick = true;
            }
            else
            {
                hadFuryBuffLastTick = false;
            }
        }
    }
}