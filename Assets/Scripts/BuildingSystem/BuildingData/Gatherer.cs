using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Gatherer : Building
{
    //apply the appropriate changes for a levelup of this building
    public override void levelUp()
    {
        this.level++;
        (float, string) temp = getChangeInfo();
        ReferenceResourceByType.getManagerOfType(temp.Item2).changeMod(temp.Item1);
    }

    //apply the appropriate changes for the removal of this building
    public override void removeSelf()
    {
        (float, string) temp = getChangeInfo();
        ReferenceResourceByType.getManagerOfType(temp.Item2).changeMod(-temp.Item1*level);
    }

    //gets the resource income modifier appropriate to the building, in resources per second per level
    protected abstract (float, string) getChangeInfo();
}
