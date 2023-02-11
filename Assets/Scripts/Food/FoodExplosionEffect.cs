using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodExplosionEffect : MonoBehaviour
{
    private static FoodExplosionEffect _instanse;
    public static FoodExplosionEffect Instanse
    {
        get
        {
            return _instanse;
        }
    }
    public GameObject explosion;

    private void Start()
    {
        if (_instanse != null)
        {
            return;
        }
        _instanse = this;
    }


    public GameObject CreateExplosion()
    {
        return Instantiate(explosion); 
    }
}
