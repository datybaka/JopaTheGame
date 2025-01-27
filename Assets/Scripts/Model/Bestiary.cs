using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Experimental.Rendering;
using static UnityEngine.GraphicsBuffer;

public class Bestiary : MonoBehaviour
{
    Boss Boss;
    P1 P1;
    GG GG;
    P2 P2;

    private void Start()
    {
        Boss = new Boss();
        P1 = new P1();
        GG = new GG();
        P2 = new P2();
    }


    public void BossMove(int target, int choise, ref int logCounter, out int curHp, out string log)
    {
        curHp = 0;
        log = "";
        if (target == 0 || target > 3)
        {
            Debug.Log("Ты ебанатище");
            curHp = 3228;
        }
        else
        {
            if (target == 1)
            {
                curHp = BossSwitcheroo(choise);
                log = Logger(++logCounter, target);
            }
            if (target == 2)
            {
                curHp = BossSwitcheroo(choise);
                log = Logger(++logCounter, target);
            }
            if (target == 3)
            {
                curHp = BossSwitcheroo(choise);
                log = Logger(++logCounter, target);
            }
        }
    }

    public void GirlMove(int target, int choise, ref int logCounter, out int curHp, out string log)
    {
        curHp = 0;
        log = "";
        if (target != 0)
        {
            Debug.Log("Ты ебанатище");
            curHp = 3228;
        }
        else
        {
            if (target == 0)
            {
                curHp = P1Switcheroo(choise);
                log = Logger(++logCounter, target);
            }
        }
    }

    private int BossSwitcheroo(int choise)
    {
        switch (choise)
        {
            case 1:
                Boss.CastSpell(P1, Boss.Ignite.Damage);
                return P1.Hp;
            default:
                return 0;
        }
    }

    private int P1Switcheroo(int choise)
    {
        switch (choise)
        {
            case 1:
                P1.CastSpell(Boss, P1.Magma.Damage);
                return Boss.Hp;
            default:
                return 0;
        }
    }

    private string Logger(int logCounter, int target)
    {
        if (target == 0)
        {
            return logCounter + ". П1 использовала заклинание \"Магма\"! Она нанесла 6 урона Боссу!\n";
        }
        else
        {
            return logCounter + ". Босс использовал заклинание \"Пламя\"! Он нанес 4 урона П1!\n";
        }
    }


}

/*
 * 
 * 
 * 1. CasTime, Colldown, Damage(отр.), Level - значение
 * 
 * 2. Condition:
 *  0) Нет.
 *  1) НЕ Гиенна.
 *  
 * 3. Effect:
 *  0) Нет.
 *  1) Ожог - увеличивает входящий урон на 100%. Снимается лечением.
 *  2) Лечение - вместо урона восстанавливает хп. Для нежити эффект - обратный!
 *  3) Стихийное разложение - эффекты поля действуют на 100% сильнее.
 *  4) Смена поля(Гиенна) - меняет поле боя на Гиенну.
 *  5) Смена поля(Хаос) - меняет поле боя на Хаос.
 *  
 * 4. Element:
 *  0) Кинетический
 *  1) Огонь
 *  2) Лёд
 *  3) Хаос
 *  4) Жизнь
 *   
 * 5. Type:
 *  0) Проджектайл
 *  1) Ритуал
 *  2) Дистанционное
 *  3) Луч
 *  
 *  
 */

class Boss : NPC
{
    public Boss() : base(100) 
    {
        Hp = 100;
    }

    public Spell Ignite = new Spell { CastTime = 0, Cooldown = 0, Damage = -4, Condition = 0, Effect = 1, Level = 1, Element = 1, Type = 1 };

}

class P1 : NPC
{
    public P1() : base(30)
    {
        Hp = 30;
    }

    public Spell Magma = new Spell { CastTime = 0, Cooldown = 1, Damage = -6, Condition = 0, Effect = 1, Level = 1, Element = 1, Type = 0 };
}

class GG : NPC
{
    public GG() : base(30)
    {
        Hp = 30;
    }

    public Spell Magma = new Spell { CastTime = 0, Cooldown = 0, Damage = -3, Condition = 0, Effect = 3, Level = 2, Element = 3 , Type = 0 };
}

class P2 : NPC
{
    public P2() : base(30)
    {
        Hp = 30;
    }

    public Spell GG = new Spell { CastTime = 0, Cooldown = 1, Damage = 0, Condition = 0, Effect = 4, Level = 3, Element = 1, Type = 1 };

}

class Spell
{
    private int _castTime = -1;
    private int _coolDown = -1;
    private int _damage = -1;
    private int _condition = -1;
    private int _effect = -1;
    private int _level = -1;
    private int _element = -1;
    private int _type = -1;

    public int CastTime
    { get { return _castTime; } set { _castTime = value; } }

    public int Cooldown
    { get { return _coolDown; } set { _coolDown = value; } }

    public int Damage
    { get { return _damage; } set { _damage = value; } }

    public int Condition
    { get { return _condition; } set { _condition = value; } }

    public int Effect
    { get { return _effect; } set { _effect = value; } }

    public int Level
    { get { return _level; } set { _level = value; } }

    public int Element
    { get { return _element; } set { _element = value; } }

    public int Type
    { get { return _type; } set { _type = value; } }
}

class NPC
{
    public int Hp;

    public NPC(int HP)
    {
        Hp = HP;
    }

    public void CastSpell(NPC target,/*int castTime, int cullDown, */int damage/*, int condition, int effect, int level, int element, int type*/)
    {
        target.Hp += damage;
    }
}


