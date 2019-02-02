using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[CreateAssetMenu(menuName = "PluggableAI/Actions/Flee")]
public class FleeAction : AIAction
{
    public override void Act(StateController controller)
    {
        Flee(controller);
    }

    private void Flee(StateController controller)
    {
        // Get the direction away from the target
        //Vector3 direction = controller.transform.position - controller.Target.position;
        //direction.y = 0;
        //controller.transform.rotation = Quaternion.Slerp(controller.transform.rotation, Quaternion.LookRotation(direction), controller.enemyStats.searchingTurnSpeed * Time.deltaTime);
        //Vector3 moveVector = direction.normalized * controller.enemyStats.moveSpeed * Time.deltaTime;
        //controller.transform.position += moveVector;


        //Vector3 dest = Vector3.MoveTowards(controller.transform.position, controller.Target.position, -1 * controller.stats.moveSpeed * Time.deltaTime);
        //controller.navMeshAgent.destination = dest;
        //controller.navMeshAgent.isStopped = false;

        // Freeze for now
        controller.navMeshAgent.isStopped = true;
    }
}