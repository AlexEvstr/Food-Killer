using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SliceActionBigFood : ASliceAction
{
    public override void BehaviourAfterSlice(Vector3 pos)
    {
        // create 2 big halfs
        var normalHalfLeft = HalfsFactory.Instanse.CreateBigLeftHalf();
        normalHalfLeft.transform.position = new Vector2(pos.x - 0.5f, pos.y);
        var normalHalfRight = HalfsFactory.Instanse.CreateBigRightHalf();
        normalHalfRight.transform.position = new Vector2(pos.x + 0.5f, pos.y);
        // create 2 normal food
        var foodBig = FoodFactory.Instanse.CreateNormal();
        foodBig.transform.position = new Vector2(pos.x + 1, pos.y + 1.0f);
        var foodBig2 = FoodFactory.Instanse.CreateNormal();
        foodBig2.transform.position = new Vector2(pos.x - 1, pos.y + 1.0f);

    }
}

