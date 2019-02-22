using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
//using Complete;

public class StateController : MonoBehaviour
{

    public State currentState;
    public EnemyStats stats;
    public Transform eyes;
    public State remainState;
    public List<Transform> wayPointList;
    public Rigidbody ShinyBoomBoom;                   // Prefab of the bullet.
    public AudioSource ShootingAudio;

    [HideInInspector] public NavMeshAgent navMeshAgent;
    [HideInInspector] public int nextWayPoint;
    [HideInInspector] public Transform Target;
    [HideInInspector] public float stateTimeElapsed;

    public float fireLaunchForce = 5f;
    private float nextFireTime;
    private bool aiActive;
    [HideInInspector] public int bullet_layer_mask;

    private void Start()
    {
        aiActive = true;
        navMeshAgent.enabled = true;
        bullet_layer_mask = LayerMask.GetMask("Player");
    }

    void Awake()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        if (!aiActive)
            return;
        currentState.UpdateState(this);
    }

    void OnDrawGizmos()
    {
        if (currentState != null && eyes != null)
        {
            Gizmos.color = currentState.sceneGizmoColor;
            Gizmos.DrawWireSphere(eyes.position, stats.lookSphereCastRadius);
        }
    }

    // Transate to the next state
    public void TransitionToState(State nextState)
    {
        if (nextState != remainState)
        {
            currentState = nextState;
            OnExitState();
        }
    }

    // How often we can call current state Act
    public bool CheckIfCountDownElapsed(float duration)
    {
        stateTimeElapsed += Time.deltaTime;
        return (stateTimeElapsed >= duration);
    }

    private void OnExitState()
    {
        stateTimeElapsed = 0;
    }

    public void Fire()
    {
        if (Time.time > nextFireTime)
        {
            nextFireTime = Time.time + stats.attackRate;

            // Create an instance of the shell and store a reference to it's rigidbody.
            Rigidbody shellInstance =
                Instantiate(ShinyBoomBoom, eyes.position, navMeshAgent.transform.rotation) as Rigidbody;

            // Set the shell's velocity to the launch force in the fire position's forward direction.
            shellInstance.velocity = fireLaunchForce * navMeshAgent.transform.forward;

            // Change the clip to the firing clip and play it.
            ShootingAudio.Play();
        }
    }
}