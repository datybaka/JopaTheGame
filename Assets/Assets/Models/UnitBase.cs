using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

[CreateAssetMenu(fileName = "Unit", menuName = "NPC/Unit")]
public class UnitModel : ScriptableObject
{
    public string Name;
    public int HP;
    public List<SpellModel> Spells = new List<SpellModel>();
}

// Базовый класс для NPC
public abstract class UnitBase : MonoBehaviour
{
    public UnitModel Data;
}
