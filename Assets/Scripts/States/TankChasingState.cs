using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This class is responsible for handling the Tank Chasing logic when in Chasing State.
/// </summary>
public class TankChasingState : TankBaseState
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
        else if (tankModel.InChaseRange && tankModel.InAttackRange) tankView.ChangeState(tankView.attackingState);

        ChasePlayer();
    }

    // Sets the destination of teh navmesh agent to be the player position.
    private void ChasePlayer()
    {
        if (!tankView.playerTransform)
        {
            tankView.ChangeState(tankView.patrollingState);
            return;
        }

        tankView.navAgent.SetDestination(tankView.playerTransform.position);
    }

}
