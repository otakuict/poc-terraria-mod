using Terraria;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Terraria.ID;
using test01.Contents.Projectiles;


namespace test01.Contents.NPCs.Monsters
{
	public class slimeA : ModNPC
	{
		private int shootTimer = 0;

		public override void SetStaticDefaults()
		{
			Main.npcFrameCount[NPC.type] = 6;
		}

		public override void SetDefaults()
		{
			NPC.width = 40;
			NPC.height = 40;
			NPC.damage = 20;
			NPC.defense = 10;
			NPC.lifeMax = 200;
			NPC.HitSound = SoundID.NPCHit1;
			NPC.DeathSound = SoundID.NPCDeath1;
			NPC.value = 60f;
			NPC.knockBackResist = 0.5f;
			NPC.aiStyle = 3; // เดินแบบซอมบี้
			AIType = NPCID.Zombie;
			AnimationType = NPCID.Zombie;

			// จำนวนเงินที่ดรอป (เป็นค่า float หน่วยเป็น copper)
			NPC.value = Item.buyPrice(silver: 5); // ดรอป 5 silver
		}

		public override void AI()
		{
			Player target = Main.player[NPC.target];
			NPC.TargetClosest(true);

			shootTimer++;
			if (shootTimer >= 120 && Main.netMode != NetmodeID.MultiplayerClient)
			{
				Vector2 velocity = (target.Center - NPC.Center).SafeNormalize(Vector2.Zero) * 6f;

				// ใช้ projectile ที่เราสร้างไว้
				Projectile.NewProjectile(NPC.GetSource_FromAI(), NPC.Center, velocity, ModContent.ProjectileType<starShooter>(), 15, 1f);
				shootTimer = 0;
			}
		}

		public override void FindFrame(int frameHeight)
		{
			NPC.frameCounter += 0.15;
			if (NPC.frameCounter >= Main.npcFrameCount[NPC.type])
				NPC.frameCounter = 0;

			NPC.frame.Y = (int)(NPC.frameCounter) * frameHeight;
		}
	}
}
