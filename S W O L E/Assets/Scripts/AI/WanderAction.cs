using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[CreateAssetMenu(menuName = "PluggableAI/Actions/Wander")]
public class WanderAction : AIAction
{
    public override void Act(StateController controller)
    {
        Wander(controller);
    }

    private void Wander(StateController controller)
    {
        if (controller.CheckIfCountDownElapsed(controller.stats.wanderDuration))
        {
            controller.stateTimeElapsed += Time.deltaTime;

            var randDirection = Random.insideUnitSphere * controller.stats.wanderRadius;
            randDirection += controller.navMeshAgent.transform.position;
            NavMeshHit navHit;
            NavMesh.SamplePosition(randDirection, out navHit, controller.stats.wanderRadius, -1);
            controller.navMeshAgent.SetDestination(navHit.position);
            controller.stateTimeElapsed = 0;
        }
    }
}