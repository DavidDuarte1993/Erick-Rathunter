using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyPatroll : MonoBehaviour
{
    public Transform targetposition;
    public Transform[] PatrolPoints;
    public int currentPatrolPoint;

    public NavMeshAgent agent;

    public enum AIState
    {
        isIdle, isPatrolling, isChasing, isAttacking
    };

    public AIState currentState;
    public float waitAtPoint = 2f;
    private float waitCounter;
    public float chaseRange = 4f;
    public float attackRange = 2.7f;
    public float timeBetweenAttacks = 3f;
    private float attackCounter;

    private float distancetoPlayer;

    private Animator anim;
    private string key_IsMoving = "IsMoving";
    private string key_Attack = "Attack";
    private string key_SAttack = "SAttack";
    bool move;
    private float attackAnimTime;
    private float resetAttackTime = 0.17f;
    private bool isAttackAnim;
    PlayerController player;

    void Start()
    {
        currentState = AIState.isIdle;
        waitCounter = waitAtPoint;

        anim = GetComponent<Animator>();
        attackAnimTime = resetAttackTime;
    }

    void Update()
    {
      /*  if (isAttackAnim)
        {
            attackAnimTime -= Time.deltaTime; ;
        }
        if (attackAnimTime <= 0)
        {
            isAttackAnim = false;
            attackAnimTime = resetAttackTime;
            int attack = GetComponent<EnemyController>().GetAttack;
            PlayerController.instance.GetComponent<HealthManager>().HurtPlayer(attack);
        }*/
       
        //anim.SetBool(key_IsMoving, move);
        distancetoPlayer = Vector3.Distance(transform.position, targetposition.position);
        Debug.Log(currentState);
        switch (currentState)
        {
            case AIState.isIdle:
               

                if (waitCounter > 0)
                {
                    waitCounter -= Time.deltaTime;
                }
                else
                {
                    currentState = AIState.isPatrolling;
                    agent.SetDestination(PatrolPoints[currentPatrolPoint].position);
                }

                if (distancetoPlayer <= chaseRange)
                {
                    currentState = AIState.isChasing;
                  anim.SetBool(key_IsMoving, true);
                }

                break;

            case AIState.isPatrolling:

                agent.SetDestination(PatrolPoints[currentPatrolPoint].position);

                if (agent.remainingDistance <= .2f)
                {
                    currentPatrolPoint++;
                    if (currentPatrolPoint >= PatrolPoints.Length)
                    {
                        currentPatrolPoint = 0;
                    }

                    currentState = AIState.isIdle;
                    waitCounter = waitAtPoint;
                }

                if (distancetoPlayer <= chaseRange)
                {
                    currentState = AIState.isChasing;
                }

              anim.SetBool(key_IsMoving, true);
                break;

            case AIState.isChasing:

                agent.SetDestination(targetposition.position);

                if (distancetoPlayer <= attackRange)
                {
                    currentState = AIState.isAttacking;
                    //anim.SetTrigger(key_Attack);
                   anim.SetBool(key_IsMoving, false);


                    agent.velocity = Vector3.zero;
                    agent.isStopped = true;

                    attackCounter = 0f;
                }

                if (distancetoPlayer > chaseRange)
                {
                    currentState = AIState.isPatrolling;
                    waitCounter = waitAtPoint;

                    agent.velocity = Vector3.zero;
                    agent.SetDestination(transform.position);
                }

                break;

            case AIState.isAttacking:
                if (PlayerController.instance == null)
                {
                    Debug.Log("player is null");
                    return;
                }
               
                distancetoPlayer = Vector3.Distance(transform.position, PlayerController.instance.transform.position);
                transform.LookAt(PlayerController.instance.transform, Vector3.up);
                transform.rotation = Quaternion.Euler(0f, transform.rotation.eulerAngles.y, 0f);

                attackCounter -= Time.deltaTime;
                if (attackCounter <= 0)
                {
                    Debug.Log(distancetoPlayer);
                    attackCounter = timeBetweenAttacks;
                    if (distancetoPlayer <= attackRange)
                    {
                        anim.SetTrigger(key_Attack);          
                    }
                    else
                    {
                        currentState = AIState.isChasing;
                        waitCounter = waitAtPoint;
                        anim.SetBool(key_IsMoving, true);
                        agent.isStopped = false;
                    }

                }

                break;
        }
    }
}