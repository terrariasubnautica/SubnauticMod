using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.DataStructures;
using Terraria.ModLoader;
using Terraria.ObjectData;
using Terraria.Enums;

namespace SubnauticMod.Content.Tiles {
	public class Kyanite : ModTile {

		public override void SetDefaults() {
			Main.tileFrameImportant[Type] = true;
			Main.tileSolid[Type] = false;
			Main.tileSolidTop[Type] = false;
			Main.tileLavaDeath[Type] = false;
			Main.tileNoAttach[Type] = true;
			Main.tileSpelunker[Type] = true; // The tile will be affected by spelunker highlighting
			Main.tileValue[Type] = 510; // Metal Detector value, see https://terraria.gamepedia.com/Metal_Detector
			AddMapEntry(new Color(109, 252, 243));

			drop = ModContent.ItemType<Items.Materials.Kyanite>();
			soundType = SoundID.Tink;
			soundStyle = 1;

			TileObjectData.newTile.CopyFrom(TileObjectData.Style1x1);
			TileObjectData.newTile.AnchorBottom = new AnchorData(AnchorType.SolidTile, 1, 0);
			TileObjectData.newTile.AnchorTop = AnchorData.Empty;
			TileObjectData.newTile.AnchorLeft = AnchorData.Empty;
			TileObjectData.newTile.AnchorRight = AnchorData.Empty;
			TileObjectData.newTile.DrawYOffset = 2;
			TileObjectData.newTile.LavaDeath = false;
			TileObjectData.addTile(Type);
		}


		//public override void KillMultiTile(int i, int j, int frameX, int frameY) {
		//	Item.NewItem(i * 16, j * 16, 16, 32, ModContent.ItemType<Items.Placeables.Fabricator>());
		//}
	}
}
