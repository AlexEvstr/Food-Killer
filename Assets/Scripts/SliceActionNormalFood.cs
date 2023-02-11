using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class SliceActionNormalFood : ASliceAction
{
    public override void BehaviourAfterSlice(Vector3 pos)
    {
        // create 2 normal halfs
        var normalHalfLeft = HalfsFactory.Instanse.CreateNormalLeftHalf();
        normalHalfLeft.transform.position = new Vector2(pos.x - 0.5f, pos.y);
        var normalHalfRight = HalfsFactory.Instanse.CreateNormalRightHalf();
        normalHalfRight.transform.position = new Vector2(pos.x + 0.5f, pos.y);
        //create 2 small food
        var foodNormal = FoodFactory.Instanse.CreateSmall();
        foodNormal.transform.position = new Vector2(pos.x + 1, pos.y + 1.0f);
        var foodNormal2 = FoodFactory.Instanse.CreateSmall();
        foodNormal2.transform.position = new Vector2(pos.x - 1, pos.y + 1.0f);
    }
}