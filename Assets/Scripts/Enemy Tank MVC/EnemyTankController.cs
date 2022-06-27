using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTankController
{
    private float StartingHealth = 50f;

    public EnemyTankModel TankModel { get; }
    public EnemyTankView TankView { get; }
    public EnemyTankController(EnemyTankModel tankModel, EnemyTankView tankPrefab)
    {
        TankModel = tankModel;
        TankView = GameObject.Instantiate<EnemyTankView>(tankPrefab);
    }

    public void RangeCheck()
    {
        TankModel.InChaseRange = Physics.CheckSphere(TankView.transform.position, TankModel.ChaseRange, TankView.playerLayerMask);
        TankModel.InAttackRange = Physics.CheckSphere(TankView.transform.position, TankModel.AttackRange, TankView.playerLayerMask);
    }

    public void ApplyDamage(float damage)
    {
        TankModel.Health -= damage;
        SetHealthUI();

        if (TankModel.Health <= 0f)
        {
            // death.
            TankService.Instance.tankController.TankModel.EnemiesKilled++;
            EventHandler.Instance.InvokeOnEnemyDeath();
            GameObject.Destroy(TankView.gameObject);
        }


        //    if(TankModel.Health - damage <= 0)

        //    {
        //        // death.
        //        TankService.Instance.tankController.TankModel.EnemiesKilled++;
        //        EventHandler.Instance.InvokeOnEnemyDeath();
        //        GameObject.Destroy(TankView.gameObject);
        //    } else
        //    {
        //        TankModel.Health -= damage;
        //    }
        //}

       

    }

    public void SetHealthUI()

    {

        float LerpSpeed = 3f * Time.deltaTime;
        TankView.HealthBar.fillAmount = Mathf.Lerp(TankView.HealthBar.fillAmount, TankModel.Health / StartingHealth, LerpSpeed);
        Color HealthColor = Color.Lerp(Color.red, Color.green, (TankModel.Health / StartingHealth));
        TankView.HealthBar.color = HealthColor;

    }
}
