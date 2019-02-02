using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "PluggableAI/Decisions/Flee")]
public class FleeDecision : Decision
{

    public override bool Decide(StateController controller)
    {
        bool targetVisible = Flee(controller);
        return targetVisible;
    }

    private bool Flee(StateController controller)
    {
        // TODO: Check if we moved flee radius from target last position

        //Vector3 direction = controller.transform.position - controller.Target.position;
        //direction.y = 0;
        //return (direction.magnitude < controller.stats.fleeRadius);

        // Freeze for now
        return true;
    }
}