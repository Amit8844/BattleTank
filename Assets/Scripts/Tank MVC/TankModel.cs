using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This Class stores and is referred to acces the data of a Tank entity in the game.
/// </summary>
public class TankModel
{
    public TankModel(TankScriptableObject tankScriptableObject)
    {
        Speed = tankScriptableObject.speed;
        Health = tankScriptableObject.health;
        RotationSpeed = tankScriptableObject.rotationSpeed;
        TankName = tankScriptableObject.TankName;
        TurretRotationSpeed = tankScriptableObject.TurretRotationSpeed;
        BulletType = tankScriptableObject.bulletType;
        BulletsFired = tankScriptableObject.bulletsFired;
        EnemiesKilled = tankScriptableObject.enemiesKilled;
    }

    public float Speed { get; }
    public float Health { get; set; }
    public float RotationSpeed { get; }
    public string TankName { get; }
    public float TurretRotationSpeed { get; }
    public BulletType BulletType { get; }
    public int BulletsFired { get; set; }
    public int EnemiesKilled { get; set; }
}
