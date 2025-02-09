using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Windows.Speech;

// Static class to handle spell effects
// Handles spell effects
public static class SpellService
{
    //public static void ApplySpell(SpellModel spell, UnitController caster, UnitController target)
    //{
    //    switch (spell.Target)
    //    {
    //        //case TargetType.Self:
    //        //    caster.Data.CurrentHP += spell.Heal;
    //        //    caster.Data.CurrentHP = Mathf.Clamp(caster.Data.CurrentHP, 0, caster.Data.MaxHP);
    //        //    //CombatLogService.Log($"{caster.Data.Name} cast {spell.Name}, healing {spell.Heal} HP!");
    //        //    break;

    //        case TargetType.Boss:
    //            target.Data.CurrentHP -= spell.Damage;
    //            //CombatLogService.Log($"{caster.Data.Name} cast {spell.Name}, dealing {spell.Damage} damage to {target.Data.Name}!");
    //            break;
    //    }
    //}

    public static void ApplySpell(SpellModel spell, /*UnitController caster,*/ UnitController target/*int castTime, int cullDown, int condition, int effect, int level, int element, int type*/)
    {
        target.Data.HP += spell.Damage;
    }
}


