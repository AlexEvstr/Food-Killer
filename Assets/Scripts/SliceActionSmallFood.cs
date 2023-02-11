using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SliceActionSmallFood : ASliceAction
{
    public override void BehaviourAfterSlice(Vector3 pos)
    {
        // create 2 small halfs
        var smallHalfLeft = HalfsFactory.Instanse.CreateSmallLeftHalf();
        smallHalfLeft.transform.position = new Vector2(pos.x - 1.4f, pos.y);
        var smallHalfRight = HalfsFactory.Instanse.CreateSmallRightHalf();
        smallHalfRight.transform.position = new Vector2(pos.x + 1.4f, pos.y);
    }
}