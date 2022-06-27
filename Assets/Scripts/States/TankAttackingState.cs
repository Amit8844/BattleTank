using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This class is responsible for handling the Tank Attacking logic when in Attacking State.
/// </summary>
public class TankAttackingState : TankBaseState
{
    public override void EnterState()
    {
        base.EnterState();
    }

    public override void ExitState()
    {
        base.ExitState();
    }

    protected override void Update()
    {
        if (!tankModel.InChaseRange && !tankModel.InAttackRange) tankView.ChangeState(tankView.patrollingState);
        else if (tankModel.InChaseRange && !tankModel.InAttackRange) tankView.ChangeState(tankView.chasingState);

        AttackPlayer();
    }

    // An asynchronous method which fires bullet at player Tank at constant intervals
    private async void AttackPlayer()
    {
        if (!tankView.playerTransform)
        {
            tankView.ChangeState(tankView.patrollingState);
            return;
        }

        tankView.navAgent.SetDestination(tankView.transform.position);

        transform.LookAt(tankView.playerTransform);

        if(!tankModel.justAttacked)
        {
            tankModel.justAttacked = true;
            FireBullet();
            await new WaitForSeconds(tankModel.timeBetweenAttacks);
            ResetAttack();
        }
    }

    // Interacts with Bullet Seervice to fire a bullet towards player tank.
    private void FireBullet()
    {
        BulletService.Instance.FireBullet(tankView.bulletSpawner, tankModel.BulletType);
    }

    private void ResetAttack()
    {
        tankModel.justAttacked = false;
    }
}
