using HellPlus.Content.Items.Accessories;
using System.Numerics;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace HellPlus.Content.Buffs
{
    public class PureHellfire : ModBuff
    {
        public static readonly int range = 550;
        public static readonly int burnTime = PendantOfHellfire.burnTime;
        public static int timer = 0;

        public override void SetStaticDefaults()
        {
			Main.debuff[Type] = false;
            Main.pvpBuff[Type] = true;
            Main.buffNoTimeDisplay[Type] = true;
        }
        public override void Update(Player player, ref int buffIndex)
        {
            foreach (NPC npc in Main.ActiveNPCs)
            {
                if (npc.CanBeChasedBy())
                {
                    Vector2 vec = new Vector2(player.Center.X, player.Center.Y);
                    Vector2 vec2 = new Vector2(npc.Center.X, npc.Center.Y);
                    float distanceToTarget = Vector2.DistanceSquared(vec, vec2);

                    if (distanceToTarget < range * range)  // if in range
                    {
                        npc.AddBuff(BuffID.OnFire3, burnTime);  // fire buff

                        if (npc.HasBuff(BuffID.OnFire3))
                        {
                            if (Main.rand.NextBool(10))  // dmg
                            {
                                npc.SimpleStrikeNPC(Main.rand.Next(57, 77), 0);
                            }
                        }
                        else  // Fire immune enemies only
                        {
                            if (Main.rand.NextBool(12))
                            {
                                npc.SimpleStrikeNPC(Main.rand.Next(7, 27), 0);
                            }
                        }
                    }
                }
            }
            timer++;
        }
    }
}