using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{

    public enum Treasures
    {
       Gold,
       Silver,
       Crystal,
    }

    public Treasures treasure;

    [SerializeField]
    private int health;

    [SerializeField]
    private int attack;

    [SerializeField]
    private float attackSpeed;

    [SerializeField]
    private float moveSpeed;

    private bool attackFlag = false;

    public bool AttackFlag
    {
        get { return attackFlag; }
        set { attackFlag = value; }
    }

    public int GetAttack
    {
        get { return attack; }
    }

    public int Health
    {
        get { return health; }
        set { health = value; }
    }
}