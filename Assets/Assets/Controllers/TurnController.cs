using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

//ТернМанагер
public class TurnController : MonoBehaviour
{
    [SerializeField] private LogConsole console;
    [SerializeField] private List<UnitController> _units = new List<UnitController>();
    
    //private int _currentTurnIndex;
    private int _roundCounter;

    private string[] GameHistory;
    private int[] StatusUpdate;

    // Method to add units to the TurnController
    public void AddUnit(UnitController unit)
    {
        _units.Add(unit);
    }

    public void StartBattle()
    {
        int counter = 0;

        GameHistory = new string[10];
        StatusUpdate = new int[4];


        //_currentTurnIndex = -1;
        _roundCounter = -1;

        foreach (var unit in _units)
        {
            Debug.Log(counter);
            StatusUpdate[counter] = unit.Data.HP;
            counter++;
        }

        TurnStart();
    }

    public void TurnStart()
    {
        _roundCounter++;

        GameHistory[0] = (_roundCounter + 1) + ". Раунд номер " + _roundCounter + " начат. \n";




        TurnEnd();

        //_currentTurnIndex = (_currentTurnIndex + 1) % _units.Count;
        //UnitController currentUnit = _units[_currentTurnIndex];
        //StartCoroutine(BossTurn(currentUnit));
    }

    private void TurnEnd()
    {
        console.RoundEnd(StatusUpdate, GameHistory);
        foreach (var x in StatusUpdate)
        {
            if (x <= 0)
            {
                //Конец боя, братишка
            }
        }
    }



    //private IEnumerator BossTurn(UnitController boss)
    //{
    //    yield return new WaitForSeconds(1);
    //    SpellModel randomSpell = boss.Data.Spells[Random.Range(0, boss.Data.Spells.Count)];
    //    UnitController target = GetRandomPlayerUnit();
    //    boss.CastSpell(randomSpell, target);
    //}

    //private UnitController GetRandomPlayerUnit()
    //{
    //    List<UnitController> players = _units.FindAll(u => u.CompareTag("Player"));
    //    return players[Random.Range(0, players.Count)];
    //}

}