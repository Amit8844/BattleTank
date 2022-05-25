using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTankModel 
{
    public BulletType BulletType { get; set; }
    public float Speed { get; }
    public float Health { get; set; }
    public float RotationSpeed { get; }
    public string TankName { get; }
    public float ChaseRange { get; }
    public float AttackRange { get; }
    public bool InChaseRange { get; set; }
    public bool InAttackRange { get; set; }
    
    // Patrolling
    public Vector3 WalkPoint { get; set; }
    public float WalkPointRange { get; set; }
    public bool WalkPointSet { get; set; }

    // Attacking
    public float timeBetweenAttacks { get; set; }
    public bool justAttacked { get; set; }


    public EnemyTankModel(EnemyTankScriptableObject enemyTankSO)
    {
        BulletType = enemyTankSO.bulletType;
        Speed = enemyTankSO.speed;
        Health = enemyTankSO.health;
        RotationSpeed = enemyTankSO.rotationSpeed;
        TankName = enemyTankSO.TankName;
        ChaseRange = enemyTankSO.chaseRange;
        AttackRange = enemyTankSO.attackRange;
        InChaseRange = enemyTankSO.InChaseRange;
        InAttackRange = enemyTankSO.InAttackRange;
        WalkPoint = enemyTankSO.WalkPoint;
        WalkPointRange = enemyTankSO.WalkPointRange;
        WalkPointSet = enemyTankSO.WalkPointSet;
        timeBetweenAttacks = enemyTankSO.TimeBetweenAttacks;
        justAttacked = enemyTankSO.justAttacked;
    }

}
