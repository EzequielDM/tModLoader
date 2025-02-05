using Terraria;
using Terraria.ModLoader;

public class DamageClassTest : Mod
{
	public void MethodA()
	{
		Item item = new();
		item.DamageType = DamageClass.Melee;
		item.DamageType = DamageClass.Magic;
		item.DamageType = DamageClass.Summon;
		item.DamageType = DamageClass.Throwing;
		item.DamageType = DamageClass.Ranged;

#if COMPILE_ERROR
		item.magic = false/* tModPorter Suggestion: Remove. See https://github.com/tModLoader/tModLoader/wiki/Update-Migration-Guide#damage-classes */;

		// can't port conditional setter, emit a suggestion
		item.ranged/* tModPorter Suggestion: item.DamageType = ... */ = 1 > 2;
#endif

		bool itemIsmelee = item.CountsAsClass(DamageClass.Melee);
		bool itemIsmagic = item.CountsAsClass(DamageClass.Magic);
		bool itemIssummon = item.CountsAsClass(DamageClass.Summon);
		bool itemIsthrowing = item.CountsAsClass(DamageClass.Throwing);
		bool itemIsRanged = item.CountsAsClass(DamageClass.Ranged);

		Projectile proj = new();
		// No minion, that is different
		bool projIsmelee = proj.CountsAsClass(DamageClass.Melee);
		bool projIsmagic = proj.CountsAsClass(DamageClass.Magic);
		bool projIsthrowing = proj.CountsAsClass(DamageClass.Throwing);
		bool projIsRanged = proj.CountsAsClass(DamageClass.Ranged);
	}

	public void MethodB(AnotherItemClass item)
	{
		item.melee = true;

		int melee = 0;
		melee = 1;
	}
}