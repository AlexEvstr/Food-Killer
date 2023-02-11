using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SplashTransparant : MonoBehaviour
{
    public SpriteRenderer _sprite = null;
    private float _speed = 0.5f;

    void Update()
    {
        var color = _sprite.color;
        color.a -= _speed * Time.deltaTime;
        color.a = Mathf.Clamp(color.a, 0, 1);
        _sprite.color = color;
    }
}
