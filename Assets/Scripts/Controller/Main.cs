using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

/*
* Время факторинга: 9:17
*
* 
*
* Задачи:
*
* 1.Дописать функционал битвы(глоб)
* 1.1 Дописать атаку босса(+)
* 1.2 Подкрутить лог на атаку босса(+/-)
* 1.3 Дописать атаку П1 и подкрутить в лог инфу
*
* 2.  Добавить классы остальных девочек, подкрутить все системы под них(глоб)
*
* 3.  Реализовать все механики скиллов + местность
*
* 4. ?..
* 
* 
*/




public class Main : MonoBehaviour
{
    public int TargetBoss;

    public int choiseBoss;
    public int choiseP1;
    public int choiseGG;

    public Bestiary Bestiary;

    public LogConsole console;

    private string[] GameHistory;
    private int[] StatusUpdate;

    public int RoundCounter;
    public int LogCounter;
    public int LogCounterConsole;

    void Start()
    {
        GameHistory = new string[10];
        StatusUpdate = new int[4];

        RoundCounter = 0;
        LogCounter = 2;
        LogCounterConsole = -1;

        StatusUpdate[0] = 100;
        StatusUpdate[3] = StatusUpdate[2] = StatusUpdate[1] = 30;

    }

    private void LogHandler()
    {

        LogCounterConsole += 3;
        LogCounter++;
        RoundCounter++;

        GameHistory[0] = LogCounterConsole + ". Раунд номер " + RoundCounter + " начат \n";


        console.RoundEnd(StatusUpdate, GameHistory); 
    }

    public void RoundEnder()
    {
        DoSmth();
        LogHandler();
    }

    private string[] DoSmth()
    {
        if (TargetBoss == 0 )
        {
            TargetBoss = Random.Range(1, 3);
            choiseBoss = Random.Range(1, 3);
        }

        Bestiary.BossMove(TargetBoss, choiseBoss, ref LogCounter, out StatusUpdate[TargetBoss], out GameHistory[1]);

        Bestiary.GirlMove(0, choiseP1, ref LogCounter, out StatusUpdate[0], out GameHistory[2]);

        return GameHistory;
    }
}