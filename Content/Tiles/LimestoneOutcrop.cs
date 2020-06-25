using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.Enums;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ObjectData;
using Terraria.Utilities;

namespace SubnauticMod.Content.Tiles {
	public class LimestoneOutcrop : ModTile {

		public override void SetDefaults() {
			Main.tileFrameImportant[Type] = true;
			Main.tileSolid[Type] = false;
			Main.tileSolidTop[Type] = false;
			Main.tileLavaDeath[Type] = false;
			Main.tileNoAttach[Type] = true;
			Main.tileSpelunker[Type] = true; // The tile will be affected by spelunker highlighting
			Main.tileValue[Type] = 100; // Metal Detector value, see https://terraria.gamepedia.com/Metal_Detector
			AddMapEntry(new Color(156, 142, 100));

			mineResist = 2f;
			dustType = DustID.Copper;
			soundType = SoundID.Tink;
			soundStyle = 1;

			TileObjectData.newTile.CopyFrom(TileObjectData.Style1x1);
			TileObjectData.newTile.AnchorBottom = new AnchorData(AnchorType.SolidTile, TileObjectData.newTile.Width, 0);
			TileObjectData.newTile.AnchorTop = AnchorData.Empty;
			TileObjectData.newTile.AnchorLeft = AnchorData.Empty;
			TileObjectData.newTile.AnchorRight = AnchorData.Empty;
			TileObjectData.newTile.DrawYOffset = 2;
			TileObjectData.newTile.LavaDeath = false;
			TileObjectData.addTile(Type);
		}

		public override bool Drop(int i, int j) {
			int select = new WeightedRandom<int>(
				(ModContent.ItemType<Items.Materials.Zirconium>(), 2d).ToTuple(),
				((int) ItemID.CopperOre, 1d).ToTuple()
			);
			Item.NewItem(i * 16, j * 16, 16, 16, select);
			return false;
		}
	}
}
