using Terraria.GameContent.ItemDropRules;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria;
using HellPlus.Content.Items;

namespace MyMod
{
    public class GlobalNPCLoot : GlobalNPC
    {
        public override void ModifyNPCLoot(NPC npc, NPCLoot npcLoot)
        {
            if (npc.type == NPCID.Hellbat)
            {
                npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<StraySoul>(), 100));
            }
            if (npc.type == NPCID.LavaSlime)
            {
                npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<StraySoul>(), 100));
            }
            if (npc.type == NPCID.FireImp)
            {
                npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<StraySoul>(), 100));
            }
            if (npc.type == NPCID.Demon)
            {
                npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<StraySoul>(), 100));

                npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<DevilHorn>(), 21));
            }
            if (npc.type == NPCID.VoodooDemon)
            {
                npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<StraySoul>(), 100));

                npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<DevilHorn>(), 21));
            }
            if (npc.type == NPCID.RedDevil)
            {
                npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<StraySoul>(), 100));

                npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<DevilHorn>(), 17));
            }
            if (npc.type == NPCID.Lavabat)
            {
                npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<StraySoul>(), 100));
            }
        }
    }
}