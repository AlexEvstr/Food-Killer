using UnityEngine;

public class EntityCalculator
{
    public static Vector3 GetDirection(Transform transform)
    {
        return new Vector3(Random.Range(transform.position.x - 1, transform.position.x + 1), 7).normalized;
    }
}
