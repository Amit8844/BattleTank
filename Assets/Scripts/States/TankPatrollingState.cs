using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This class is responsible for handling the Tank Patrolling logic when in Patrolling State.
/// </summary>
public class TankPatrollingState : TankBaseState
{
    public override void EnterState()
    {
        base.EnterState();
    }

    protected override void Start()
    {
        base.Start();
        ChangeWalkPoint();
    }

    public override void ExitState()
    {
        base.ExitState();
    }

    // Checks for State change conditions & executes patrlling behaviour if in Patrolling State.
    protected override void Update()
    {
        if (tankModel.InChaseRange && !tankModel.InAttackRange) tankView.ChangeState(tankView.chasingState);
        else if (tankModel.InChaseRange && tankModel.InAttackRange) tankView.ChangeState(tankView.attackingState);

        Patroling();
    }

    // Implements Patrolling by setting a walkpoint destination and moving towards it.
    private void Patroling()
    {
        if (!tankModel.WalkPointSet) SearchWalkPoint();

        if (tankModel.WalkPointSet)
        { 
            tankView.navAgent.SetDestination(tankModel.WalkPoint);
        }

        Vector3 distanceToWalkPoint = tankView.transform.position - tankModel.WalkPoint;

        if (distanceToWalkPoint.magnitude < 1f)
        {
            tankModel.WalkPointSet = false;
        }
    }

    // This method Sets a random walkpoint on the walkable ground.
    private void SearchWalkPoint()
    {
        float randomZ = Random.Range(-tankModel.WalkPointRange, tankModel.WalkPointRange);
        float randomX = Random.Range(-tankModel.WalkPointRange, tankModel.WalkPointRange);

        tankModel.WalkPoint = new Vector3(Mathf.Clamp(tankView.transform.position.x + randomX, -37f, 37f), tankView.transform.position.y, Mathf.Clamp(tankView.transform.position.z + randomZ, -37, 37));

        if (Physics.Raycast(tankModel.WalkPoint, -tankView.transform.up, 2f, tankView.groundLayerMask))
        {
            tankModel.WalkPointSet = true;
        }
    }

    // This asynchronous method sets a new walkpoint every 10 seconds.
    private async void ChangeWalkPoint()
    {
        while(true)
        {
            await new WaitForSeconds(10f);
            tankModel.WalkPointSet = false;
        }
        

    }

}
