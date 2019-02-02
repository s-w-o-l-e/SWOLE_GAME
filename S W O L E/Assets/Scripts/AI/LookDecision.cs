using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "PluggableAI/Decisions/Look")]
public class LookDecision : Decision
{

    public override bool Decide(StateController controller)
    {
        bool targetVisible = Look(controller);
        return targetVisible;
    }

    // Check if an object is infront of the object
    private bool Look(StateController controller)
    {
        RaycastHit hit;

        Debug.DrawRay(controller.eyes.position, controller.eyes.forward.normalized * controller.stats.lookRange, Color.green);

        if (Physics.SphereCast(controller.eyes.position, controller.stats.lookSphereCastRadius, controller.eyes.forward, out hit, controller.stats.lookRange) 
            && hit.collider.CompareTag("Player"))
        {
            controller.Target = hit.transform;
            return true;
        }
        else
        {
            return false;
        }
    }
}