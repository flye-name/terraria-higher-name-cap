using MonoMod.Cil;
using Terraria.GameContent.UI.Elements;
using Terraria.GameContent.UI.States;
using Terraria.ModLoader;

namespace RaisedNameCap.Core;

public class PlayerEdit : ModSystem
{
	public override void Load()
	{
		IL_UICharacterCreation.Click_Naming += IncreaseCap;
		IL_UICharacterCreation.Click_NamingAndCreating += IncreaseCap;
		IL_UICharacterListItem.RenameButtonClick += IncreaseCap;
	}

	void IncreaseCap(ILContext il)
	{
		ILCursor c = new(il);
		
		c.GotoNext(MoveType.Before, i => i.MatchCallvirt<UIVirtualKeyboard>(nameof(UIVirtualKeyboard.SetMaxInputLength)));
		c.GotoPrev(MoveType.After, i => i.MatchLdcI4(20));
		
		c.EmitPop();
		c.EmitLdcI4(RaisedNameCap.NEW_CAP);
	}
}