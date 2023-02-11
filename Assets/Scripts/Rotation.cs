using UnityEngine;
using System.Collections;

public class Rotation : MonoBehaviour
{
    [SerializeField] int rotationZ;
    void Update()
    {
        Quaternion target = Quaternion.Euler(0,0, rotationZ);
        transform.rotation = Quaternion.Slerp(transform.rotation, target, Time.deltaTime);
    }
}
