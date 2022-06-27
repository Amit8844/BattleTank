using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class EnemyTankView : MonoBehaviour, IDamagable
{
    public Transform bulletSpawner;
    public EnemyTankController enemyTankController;
    [HideInInspector]
    public TankBaseState currentState;
    [SerializeField]
    private TankBaseState startingState;
    public TankPatrollingState patrollingState;
    public TankChasingState chasingState;
    public TankAttackingState attackingState;

    public NavMeshAgent navAgent;
    [HideInInspector]
    public Transform playerTransform;
    public LayerMask playerLayerMask, groundLayerMask;

    public Image HealthBar;


    private void Start()
    {
        ChangeState(startingState);
        if (TankService.Instance.tankController.TankView)
        {
            playerTransform = TankService.Instance.tankController.TankView.transform;
        }
        navAgent = GetComponent<NavMeshAgent>();
    }

    private void Update()
    {
        enemyTankController.RangeCheck();

        enemyTankController.SetHealthUI();
    }

    public void SetTankControllerReference(EnemyTankController controller)
    {
        enemyTankController = controller;
    }

    public void TakeDamage(float damage)
    {
        Debug.Log("Enemy Tank Taking Damage: " + damage, gameObject);
        enemyTankController.ApplyDamage(damage);
    }

    public void ChangeState(TankBaseState newTankState)
    {
        if(currentState != null)
        {
            currentState.ExitState();
        }
        currentState = newTankState;
        currentState.EnterState();
    }

}
