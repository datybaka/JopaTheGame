using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetupManager : MonoBehaviour
{
    [SerializeField] private UnitController _bossPrefab;
    [SerializeField] private UnitController _p1Prefab;
    [SerializeField] private UnitController _ggPrefab;
    [SerializeField] private UnitController _p2Prefab;

    // Reference to the TurnController component
    [SerializeField] private TurnController turnController;

    private void Start()
    {
        // Ensure the TurnController reference is set
        if (turnController == null)
        {
            Debug.LogError("TurnController reference is not set in SetupManager!");
            return;
        }

        // Add the units to the TurnController
        turnController.AddUnit(_bossPrefab);
        turnController.AddUnit(_p1Prefab);
        turnController.AddUnit(_ggPrefab);
        turnController.AddUnit(_p2Prefab);

        // Call the method to start the battle
        StartGame();
    }

    private void StartGame()
    {
        turnController.StartBattle();
    }
}
