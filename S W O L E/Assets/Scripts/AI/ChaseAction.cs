using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "PluggableAI/Actions/Chase")]
public class ChaseAction : AIAction
{
    public override void Act(StateController controller)
    {
        Chase(controller);
    }

    private void Chase(StateController controller)
    {
        var dist = Vector3.Distance(controller.Target.position, controller.navMeshAgent.transform.position);

        // Check if we still want get closer
        if (dist < controller.stats.chaseDistance)
        {
            controller.navMeshAgent.destination = controller.navMeshAgent.transform.position;
        }
        else
        {
            controller.navMeshAgent.destination = controller.Target.position;
            controller.navMeshAgent.isStopped = false;
        }
    }
}