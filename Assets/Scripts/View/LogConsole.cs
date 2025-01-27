using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class LogConsole : MonoBehaviour
{
    [SerializeField] private TMP_Text StatusUp;
    [SerializeField] private TMP_Text Loging;

    public void Start()
    {
        StatusUp.text = "BossHP: 100" + "\n";
        StatusUp.text += "P1HP: 30" + "\n";
        StatusUp.text += "GGHP: 30" + "\n";
        StatusUp.text += "P2HP: 30";

        Loging.text = "1. Начало битвы...\n";
    }

    public void RoundEnd(int[] status, string[] gamehistory)
    {
        StatusUp.text = null;

        StatusUp.text = "BossHP: " + status[0] + "\n" + "P1HP: " + status[1] + "\n" + "GGHP: " + status[2] + "\n" + "P2HP: " + status[3] + "\n";

        for (int i = 0; i < gamehistory.Length; i++)
        {
            Loging.text += gamehistory[i];
        }
    }
}
