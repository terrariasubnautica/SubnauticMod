using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.Enums;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ObjectData;

namespace SubnauticMod.Content.Tiles {
	public class KyaniteChunk : ModTile {
		public override void SetDefaults() {
			Main.tileFrameImportant[Type] = true;
			Main.tileSolid[Type] = false;
			Main.tileSolidTop[Type] = false;
			Main.tileLavaDeath[Type] = false;
			Main.tileNoAttach[Type] = true;
			Main.tileSpelunker[Type] = true; // The tile will be affected by spelunker highlighting
			Main.tileValue[Type] = 510; // Metal Detector value, see https://terraria.gamepedia.com/Metal_Detector
			AddMapEntry(new Color(109, 252, 243));

			mineResist = 18f;
			dustType = 20;
			soundType = SoundID.Tink;
			soundStyle = 1;

			TileObjectData.newTile.CopyFrom(TileObjectData.Style3x3);
			TileObjectData.newTile.AnchorBottom = new AnchorData(AnchorType.SolidTile, TileObjectData.newTile.Width, 0);
			TileObjectData.newTile.AnchorTop = AnchorData.Empty;
			TileObjectData.newTile.AnchorLeft = AnchorData.Empty;
			TileObjectData.newTile.AnchorRight = AnchorData.Empty;
			TileObjectData.newTile.DrawYOffset = 2;
			TileObjectData.newTile.LavaDeath = false;
			TileObjectData.addTile(Type);
		}


		public override void KillMultiTile(int i, int j, int frameX, int frameY) {
			Item.NewItem(i * 16, j * 16, 16, 32, ModContent.ItemType<Items.Materials.Kyanite>(), Main.rand.Next(0, 13));
		}
	}
}
