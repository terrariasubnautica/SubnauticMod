using System;
using MonoMod.Cil;
using Terraria;
using static Mono.Cecil.Cil.OpCodes;

namespace SubnauticMod {
	public static class SubnauticILEdits {

		public static void Initialize() {
			IL.Terraria.Main.DrawInterface_Resources_Breath += (il => {
				var c = new ILCursor(il);

				if (!c.TryGotoNext(i => i.Match(Stloc_3))) {
					return;
				}
				c.Index += 3;

				var label = il.DefineLabel();

				//check if Main.LocalPlayer exist
				c.Emit(Ldsfld, typeof(Main).GetField(nameof(Main.player)));
				c.Emit(Ldsfld, typeof(Main).GetField(nameof(Main.myPlayer)));
				c.Emit(Ldelem_Ref);
				c.Emit(Brfalse_S, label);

				//check if SubnaiticModPlayer exist
				c.Emit(Ldsfld, typeof(Main).GetField(nameof(Main.player)));
				c.Emit(Ldsfld, typeof(Main).GetField(nameof(Main.myPlayer)));
				c.Emit(Ldelem_Ref);
				c.Emit(Callvirt, typeof(Player).GetMethod("GetModPlayer", new Type[] { }).MakeGenericMethod(typeof(SubnauticModPlayer)));
				c.Emit(Brfalse_S, label);

				//check for oxygen tank
				c.Emit(Ldsfld, typeof(Main).GetField(nameof(Main.player)));
				c.Emit(Ldsfld, typeof(Main).GetField(nameof(Main.myPlayer)));
				c.Emit(Ldelem_Ref);
				c.Emit(Callvirt, typeof(Player).GetMethod("GetModPlayer", new Type[] { }).MakeGenericMethod(typeof(SubnauticModPlayer)));
				c.Emit(Ldfld, typeof(SubnauticModPlayer).GetField(nameof(SubnauticModPlayer.OxygenTank)));
				c.Emit(Brfalse_S, label);

				//this skip breath ui
				c.Emit(Ldc_I4, 10000);
				c.Emit(Stloc, 4);

				//failcheck
				c.MarkLabel(label);

			});
		}
	}
}
