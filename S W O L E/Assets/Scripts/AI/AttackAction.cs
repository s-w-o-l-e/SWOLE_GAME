using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu (menuName = "PluggableAI/Actions/Attack")]
public class AttackAction : AIAction 
{
    public override void Act (StateController controller)
    {
        Attack (controller);
    }

    private void Attack(StateController controller)
    {
        RaycastHit hit;

        Debug.DrawRay(controller.eyes.position, controller.eyes.forward.normalized * controller.stats.attackRange, Color.red);

        if (Physics.SphereCast(controller.eyes.position, controller.stats.lookSphereCastRadius, controller.eyes.forward, out hit, controller.stats.attackRange)
            && hit.collider.CompareTag("Player"))
        {
            if (controller.CheckIfCountDownElapsed(controller.stats.attackRate))
            {
                Debug.Log("Attacked Player");
            }
        }
    }
}