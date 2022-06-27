using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// A Base class for any other Tank State Class. Defines necessary methods like EnterState() & ExitState() required for all tank states.
/// </summary>
[RequireComponent(typeof(EnemyTankView))]
public class TankBaseState : MonoBehaviour
{
    public EnemyTankView tankView;
    public EnemyTankModel tankModel;

    //Sets tank view reference.
    private void Awake()
    {
        tankView = GetComponent<EnemyTankView>();
    }

    // Sets Tank Model reference.
    protected virtual void Start()
    {
        tankModel = tankView.enemyTankController.TankModel;
    }

    // Called just after entering the state.
    public virtual void EnterState()
    {
        this.enabled = true;
    }

    // Called while Exiting a state.
    public virtual void ExitState()
    {
        this.enabled = false;
    }

    protected virtual void Update()
    {
        
    }
}
