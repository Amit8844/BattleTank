using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTankService : MonoBehaviour
{
    public EnemyTankView tankView;
    public EnemyTankScriptableObject enemyTankSO;
    public BulletScriptableObjectList bulletList;
    public int numOfEnemies;

    private void Start()
    {
        StartGame();
    }

    private void StartGame()
    {
        for (int i = 0; i < numOfEnemies; i++)
        {
            CreateEnemyTank();
        }


    }

    Vector3 RandomPosition()
    {
        float x, y, z;
        Vector3 pos;
        x = Random.Range(-35, 35);
        y = 1;
        z = Random.Range(-20, 30);
        pos = new Vector3(x, y, z);
        return pos;
    }

    private EnemyTankController CreateEnemyTank()
    {
        EnemyTankModel model = new EnemyTankModel(enemyTankSO);
        EnemyTankController tank = new EnemyTankController(model, tankView);
        tank.TankView.SetTankControllerReference(tank);
        return tank;
    }


}
