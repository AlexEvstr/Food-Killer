using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombExplosionEffect : MonoBehaviour
{
    private static BombExplosionEffect _instanse;
    public static BombExplosionEffect Instanse
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
