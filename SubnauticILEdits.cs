using Terraria;

namespace SubnauticMod {
	public static class SubnauticILEdits {
		public static void InitializeOnHooks() {
			On.Terraria.Main.DrawInterface_Resources_Breath += BreathUIOverride;
		}

		private static void BreathUIOverride(On.Terraria.Main.orig_DrawInterface_Resources_Breath orig) {
			Player lPlayer = Main.LocalPlayer;
			bool hasLavaBreath = false;
			if (lPlayer != null) {
				if (lPlayer.lavaTime < lPlayer.lavaMax) {
					hasLavaBreath = lPlayer.lavaWet || lPlayer.breath == lPlayer.breathMax;
				}
				SubnauticModPlayer subPlayer = lPlayer.GetModPlayer<SubnauticModPlayer>();
				if (subPlayer != null) {
					if (subPlayer.OxygenTank && !hasLavaBreath) {
						return;
					}
				}
			}
			orig();
		}

		//public static void InitializeILHooks() {
		//	IL.Terraria.Main.DrawInterface_Resources_Breath += (il => {
		//		var cursor = new ILCursor(il);
		//		while (cursor.TryGotoNext(i => i.MatchLdfld("Terraria.Player", "ghost"))) {
		//			var cursorCheck = new ILCursor(cursor);
		//			if (!cursorCheck.TryGotoNext(i => i.MatchLdfld("Terraria.Player", "breathMax"))) {
		//				SubnauticMod.Instance?.Logger?.Error("Water Breath UI Override Failed!");
		//				continue;
		//			}
		//			ILLabel outLabel = null;
		//			cursor.GotoNext(i => i.MatchBrtrue(out outLabel));
		//			cursor.Index++;

		//			if (outLabel == null) {
		//				continue;
		//			}

		//			var label = il.DefineLabel();

		//			//check if Main.LocalPlayer exist
		//			cursor.Emit(Ldsfld, typeof(Main).GetField(nameof(Main.player)));
		//			cursor.Emit(Ldsfld, typeof(Main).GetField(nameof(Main.myPlayer)));
		//			cursor.Emit(Ldelem_Ref);
		//			cursor.Emit(Brfalse_S, label);

		//			//check if SubnaiticModPlayer exist
		//			cursor.Emit(Ldsfld, typeof(Main).GetField(nameof(Main.player)));
		//			cursor.Emit(Ldsfld, typeof(Main).GetField(nameof(Main.myPlayer)));
		//			cursor.Emit(Ldelem_Ref);
		//			cursor.Emit(Callvirt, typeof(Player).GetMethod("GetModPlayer", new Type[] { }).MakeGenericMethod(typeof(SubnauticModPlayer)));
		//			cursor.Emit(Brfalse_S, label);

		//			//check for oxygen tank
		//			cursor.Emit(Ldsfld, typeof(Main).GetField(nameof(Main.player)));
		//			cursor.Emit(Ldsfld, typeof(Main).GetField(nameof(Main.myPlayer)));
		//			cursor.Emit(Ldelem_Ref);
		//			cursor.Emit(Callvirt, typeof(Player).GetMethod("GetModPlayer", new Type[] { }).MakeGenericMethod(typeof(SubnauticModPlayer)));
		//			cursor.Emit(Ldfld, typeof(SubnauticModPlayer).GetField(nameof(SubnauticModPlayer.OxygenTank)));
		//			cursor.Emit(Brtrue, outLabel);

		//			//failcheck
		//			cursor.MarkLabel(label);
		//			SubnauticMod.Instance?.Logger?.Info("Water Breath UI Override Succeed!");
		//			break;
		//		}
		//	});
		//}
	}
}
