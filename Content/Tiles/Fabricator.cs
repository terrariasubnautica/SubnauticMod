using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Steamworks;
using Terraria;
using Terraria.DataStructures;
using Terraria.ModLoader;
using Terraria.ObjectData;

namespace SubnauticMod.Content.Tiles {
	public class Fabricator : ModTile {

		public bool open = false;
		public int curFrame = 0;
		public int closeDelay = 60;
		public int closeDelayMax = 60;

		public override void SetDefaults() {
			Main.tileFrameImportant[Type] = true;
			Main.tileSolid[Type] = false;
			Main.tileSolidTop[Type] = false;
			Main.tileLavaDeath[Type] = false;
			Main.tileNoAttach[Type] = true;
			AddMapEntry(new Color(200, 200, 200));

			TileObjectData.newTile.CopyFrom(TileObjectData.Style3x3Wall);
			TileObjectData.newTile.Width = 2;
			TileObjectData.newTile.Height = 3;
			TileObjectData.newTile.CoordinateHeights = new int[] { 16, 16, 16 };
			TileObjectData.newTile.CoordinateWidth = 16;
			TileObjectData.newTile.CoordinatePadding = 2;
			TileObjectData.newTile.LavaDeath = false;
			TileObjectData.newTile.Origin = new Point16(1, 2);
			TileObjectData.newTile.HookPostPlaceMyPlayer = new PlacementHook(ModContent.GetInstance<FabricatorEntity>().Hook_AfterPlacement, -1, 0, false);
			TileObjectData.addTile(Type);
			animationFrameHeight = 54;
		}

		public override void AnimateTile(ref int frame, ref int frameCounter) {
			frameCounter++;
			closeDelay = Math.Max(0, closeDelay - 1);
			if (frameCounter == 6) {
				if (open) {
					frame = Math.Min(frame + 1, 2);
				}
				else if (closeDelay<=0){
					frame = Math.Max(frame - 1, 0);
				}
				frameCounter = 0;
			}
			curFrame = frame;
		}

		public override bool PreDraw(int i, int j, SpriteBatch spriteBatch) {
			return base.PreDraw(i, j, spriteBatch);
		}

		public override void PostDraw(int i, int j, SpriteBatch spriteBatch) {
			if (curFrame == 0 || curFrame == 2)
				open = false;
		}

		private FabricatorEntity GetEntity(int i, int j) {
			int index = ModContent.GetInstance<FabricatorEntity>().Find(i, j);
			if (index == -1) {
				return null;
			}
			return (FabricatorEntity) TileEntity.ByID[index];
		}

		public override void KillMultiTile(int i, int j, int frameX, int frameY) {
			Item.NewItem(i * 16, j * 16, 16, 32, ModContent.ItemType<Items.Placeables.Fabricator>());
			ModContent.GetInstance<FabricatorEntity>().Kill(i, j);
		}

		//this is for debugging
		public override bool NewRightClick(int i, int j) {
			FabricatorEntity entity = GetEntity(i, j);
			if (entity == null) {
				return false;
			}

			Main.NewText($"Found Fabricator, {entity.open}");
			return true;
		}

	}
}
