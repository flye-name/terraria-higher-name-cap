using MonoMod.Cil;
using Terraria.GameContent.UI.States;
using Terraria.ModLoader;

namespace RaisedNameCap.Core;

public class WorldCreation : ModSystem
{
	public override void Load()
	{
		IL_UIWorldCreation.Click_SetName += IncreaseCap;
		IL_UIWorldCreation.Click_NamingAndCreating += IncreaseCap2;
	}

	void IncreaseCap(ILContext il)
	{
		ILCursor c = new(il);
		
		c.GotoNext(MoveType.Before, i => i.MatchCallvirt<UIVirtualKeyboard>(nameof(UIVirtualKeyboard.SetMaxInputLength)));
		c.GotoPrev(MoveType.After, i => i.MatchLdcI4(27));
		
		c.EmitPop();
		c.EmitLdcI4(RaisedNameCap.NEW_CAP);
	}
	void IncreaseCap2(ILContext il)
	{
		ILCursor c = new(il);
		
		c.GotoNext(MoveType.Before, i => i.MatchCallvirt<UIVirtualKeyboard>(nameof(UIVirtualKeyboard.SetMaxInputLength)));
		c.GotoPrev(MoveType.After, i => i.MatchLdcI4(27));
		
		c.EmitPop();
		c.EmitLdcI4(RaisedNameCap.NEW_CAP);
	}
}