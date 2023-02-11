using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blade : MonoBehaviour
{
    [SerializeField] private UnityEngine.GameObject _blade;
    private int _vectorZ = 15;
    public AudioSource ShootSound;

    void Update()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            if (touch.phase == TouchPhase.Began || (touch.phase == TouchPhase.Moved))
            {
                _blade.SetActive(true);
                ShootSound.Play();
            }
            else if (touch.phase == TouchPhase.Ended)
            {
                _blade.SetActive(false);
            }
            _blade.transform.position = MyScreenToworld(Input.mousePosition);

        }
    }
    public Vector3 MyScreenToworld(Vector3 mousepos)
    {
        Vector3 worldpos = Camera.main.ScreenToWorldPoint(new Vector3(mousepos.x, mousepos.y, _vectorZ));
        return worldpos;
    }
}