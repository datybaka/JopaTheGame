using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Шаблон способности
[CreateAssetMenu(fileName = "Spell", menuName = "NPC/Spell")]
public class SpellModel : ScriptableObject
{
    public string Name;
    public string Condition;
    public string Effect;
    public string Element;
    public string Type;

    public int CastTime;
    public int CoolDown;
    public int Damage;
    public int Level;
}
