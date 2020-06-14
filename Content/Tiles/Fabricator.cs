using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ModLoader;
using Terraria.ObjectData;

namespace SubnauticMod.Content.Tiles {
	public class Fabricator : ModTile {
		private bool open;

		public override void SetDefaults() {
			Main.tileFrameImportant[Type] = true;
			Main.tileSolid[Type] = false;
			Main.tileSolidTop[Type] = false;
			Main.tileLavaDeath[Type] = false;
			Main.tileNoAttach[Type] = true;
			TileObjectData.newTile.CopyFrom(TileObjectData.Style3x3Wall);
			TileObjectData.newTile.Width = 2;
			TileObjectData.newTile.Height = 3;
			TileObjectData.newTile.CoordinateHeights = new int[] { 16, 16, 16 };
			TileObjectData.newTile.CoordinateWidth = 16;
			TileObjectData.newTile.CoordinatePadding = 2;
			TileObjectData.newTile.LavaDeath = false;
			TileObjectData.newTile.Origin = new Point16(0, 1);
			TileObjectData.addTile(Type);
			animationFrameHeight = 54;
			open = false;
		}

		public override void AnimateTile(ref int frame, ref int frameCounter) {
			frameCounter++;
			if (frameCounter == 6) {
				if (open) {
					frame = Math.Min(frame + 1, 2);
				}
				else {
					frame = Math.Max(frame - 1, 0);
				}
				frameCounter = 0;
			}
		}

		public override void KillMultiTile(int i, int j, int frameX, int frameY) {
			Item.NewItem(i * 16, j * 16, 16, 32, ModContent.ItemType<Items.Placeables.Fabricator>());
		}

		public override void NearbyEffects(int i, int j, bool closer) {
			if (closer) {
				Player player = Main.LocalPlayer;
				float dist = Vector2.DistanceSquared(new Vector2(i * 16 - 8, j * 16 - 8), player.position);
				if (dist <= 2500) {
					open = true;
				}
				else {
					open = false;
				}
			}
			else {
				open = false;
			}
		}
	}
}
