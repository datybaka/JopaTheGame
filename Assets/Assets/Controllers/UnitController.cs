using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Manages unit logic (boss/player)
public class UnitController : UnitBase
{
    //[SerializeField] private UnitView _view;
    [SerializeField] private UnitModel _config; // ScriptableObject data

    private void Start()
    {
        Initialize(_config);
    }

    public void Initialize(UnitModel config)
    {
        Data = config;
    }

    public void CastSpell(SpellModel spell, UnitController target)
    {
        SpellService.ApplySpell(spell, target);
    }
}
