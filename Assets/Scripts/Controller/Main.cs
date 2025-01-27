using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

/*
* ����� ����������: 9:17
*
* 
*
* ������:
*
* 1.�������� ���������� �����(����)
* 1.1 �������� ����� �����(+)
* 1.2 ���������� ��� �� ����� �����(+/-)
* 1.3 �������� ����� �1 � ���������� � ��� ����
*
* 2.  �������� ������ ��������� �������, ���������� ��� ������� ��� ���(����)
*
* 3.  ����������� ��� �������� ������� + ���������
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

        GameHistory[0] = LogCounterConsole + ". ����� ����� " + RoundCounter + " ����� \n";


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