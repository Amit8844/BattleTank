using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// A class for creating Enemy Tank Scriptable Objects with all the required properties.
/// </summary>
[CreateAssetMenu(fileName = "EnemyTankScriptableObject", menuName = "ScriptableObjects/NewEnemyTankSO")]
public class EnemyTankScriptableObject : ScriptableObject
{
    public TankType tankType;
    public BulletType bulletType;
    public string TankName;
    public float speed;
    public int health;
    public float rotationSpeed;
    public float TurretRotationSpeed;
    public float chaseRange;
    public float attackRange;
    public bool InChaseRange; 
    public bool InAttackRange;
    public Vector3 WalkPoint;
    public bool WalkPointSet;
    public float WalkPointRange;
    public float TimeBetweenAttacks;
    public bool justAttacked;
    internal object tank;
}