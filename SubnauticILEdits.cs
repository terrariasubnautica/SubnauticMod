using System;
using MonoMod.Cil;
using Terraria;
using static Mono.Cecil.Cil.OpCodes;

namespace SubnauticMod {
	public static class SubnauticILEdits {

		public static void Initialize() {
			/* Currently doesn't work well :(
			 * The injection goal is to change i to high number
			 *
			 * Here the snippet of DrawInterface_Resources_Breath and where we want to inject:
			 *
			 * int num2 = 20;
			 * for (int i = 1; i < Main.player[Main.myPlayer].breathMax / num2 + 1; i++)
			 *
			 * And here is the IL snippet:
			 *
			 * ldc.i4.s 20
			 * stloc.<X>
			 * ldc.i4.1
			 * stloc.s <i>
			 * br <Z>
			 *
			 * X, i, and Z number is different each compile
			 * and i is pointing to local memory to variable i
			 *
			 * Currently my (Neptuna) injection is doing this:
			 *
			 * ldc.i4.s 20
			 * stloc.<X> <- cursor find (assumed X=3) (inject in +3)
			 * ldc.i4.1
			 * stloc.s <i>
			 *   <- inject start ->
			 *   [Check if use Oxygen tank]
			 *   [if false go to "label"]
			 *   ldc.i4 10000
			 *   stloc 4
			 *   "label":
			 *   <- inject end ->
			 * br <Z>
			 *
			 * Which is bad because:
			 * - Assuming X is always 3 (stloc.3)
			 * - Find the cursor in local variable store OpCode (Match(Stloc_3))
			 * - Assuming local memory i is always 4 (stloc 4)
			 *
			 * My (Neptuna) idea for the right solution is:
			 *
			 * ldc.i4.s 20 <- cursor find
			 * stloc.<X>
			 * ldc.i4.1 <- check if cursor.next.next opCode is ldc.i4.1
			 *   <- inject start ->
			 *   pop?
			 *   insert big number?
			 *   <- inject end ->
			 * stloc.s <i>
			 * br <Z>
			 *
			 * But I (Neptuna) don't know how to do that :(
			 */
			IL.Terraria.Main.DrawInterface_Resources_Breath += (il => {
				var c = new ILCursor(il);

				if (!c.TryGotoNext(i => i.Match(Stloc_3))) {
					SubnauticMod.Instance.Logger.Error("Water Breath UI Override Failed!");
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
