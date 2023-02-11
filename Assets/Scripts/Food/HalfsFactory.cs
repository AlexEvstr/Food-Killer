using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HalfsFactory : MonoBehaviour
{
    private static HalfsFactory _instanse;
    public static HalfsFactory Instanse
    {
        get
        {
            return _instanse;
        }
    }

    public GameObject smallLeftHalf;
    public GameObject smallRightHalf;
    public GameObject normalLeftHalf;
    public GameObject normalRightHalf;
    public GameObject bigLeftHalf;
    public GameObject bigRightHalf;


    private void Start()
    {
        if (_instanse != null)
        {
            return;
        }
        _instanse = this;
    }

    public GameObject CreateSmallLeftHalf()
    {
        return Instantiate(smallLeftHalf);
    }
    public GameObject CreateSmallRightHalf()
    {
        return Instantiate(smallRightHalf);
    }
    public GameObject CreateNormalLeftHalf()
    {
        return Instantiate(normalLeftHalf);
    }
    public GameObject CreateNormalRightHalf()
    {
        return Instantiate(normalRightHalf);
    }

    public GameObject CreateBigLeftHalf()
    {
        return Instantiate(bigLeftHalf);
    }
    public GameObject CreateBigRightHalf()
    {
        return Instantiate(bigRightHalf);
    }
}
