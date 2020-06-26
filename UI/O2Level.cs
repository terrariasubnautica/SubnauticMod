using System;
using Microsoft.Xna.Framework;
using SubnauticMod.Content.Items.Accessories;
using Terraria;
using Terraria.UI;

namespace SubnauticMod.UI {
	public class O2Level : UIState {
		public bool visible = false;
		public UIProgressBarTextured back;
		public UIProgressBarTextured fill;
		public float leftPos = (Main.screenWidth - 100) / 2;
		public float topPos = 0f;
		public Color bgColor = Color.White;

		public override void OnInitialize() {
			back = new UIProgressBarTextured(20, 100, "SubnauticMod/UI/OxygenBarBackground");
			back.Left.Set(leftPos, 0f);
			back.Top.Set(topPos, 0f);
			back.backgroundColor = Color.White;
			fill = new UIProgressBarTextured(8, 96, "SubnauticMod/UI/OxygenBar", 2, 6);
			fill.Left.Set(leftPos + 2f, 0f);
			fill.Top.Set(topPos + 6f, 0f);
			fill.backgroundColor = Color.White;
			base.Append(back);
			base.Append(fill);
		}

		public override void Update(GameTime gameTime) {
			Player player = Main.LocalPlayer;
			OxygenTank tank = player.GetOxygenTank().tank;
			if (player == null || tank == null) {
				return;
			}

			//YO THIS MATH CONFUSE ME A LOT!!!
			Vector2 playerPos = player.position - Main.ViewPosition;
			playerPos.X += player.width / 2f;
			playerPos.X *= Main.GameViewMatrix.Zoom.X;
			playerPos.Y *= Main.GameViewMatrix.Zoom.Y;
			playerPos /= Main.UIScale;
			float playerScaleX = (playerPos.X - 50f);
			float playerScaleY = (playerPos.Y - (player.height - 10f));

			back.Left.Set(playerScaleX, 0f);
			fill.Left.Set(playerScaleX + 2f, 0f);
			back.Top.Set(playerScaleY, 0f);
			fill.Top.Set(playerScaleY + 6f, 0f);

			int charge = player.breath + tank.currentO2Hold;
			int maxCharge = player.breathMax + tank.oxygenCapacityIncrease;
			float progress = (float) charge / (float) maxCharge;

			fill.SetProgress(progress);

			float urgent = Math.Min((1f - progress) * 5f, 1f);
			bgColor = Color.White * urgent;

			back.backgroundColor = bgColor;
			fill.backgroundColor = bgColor;

			Recalculate();
			base.Update(gameTime);
		}
	}
}
