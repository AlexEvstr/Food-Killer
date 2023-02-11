using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UIElements;


public abstract class Bomb : Entity
{
    [SerializeField] protected float _force;
    protected Rigidbody _rigidbody;
    protected Vector3 _direction;

    private void Start()
    {

        _rigidbody = GetComponent<Rigidbody>();
        _direction = EntityCalculator.GetDirection(transform);
        Fly();

    }
    //public void CreateBomb()
    //{
    //    var bomb = Instantiate(gameObject);
    //    bomb.transform.position = new Vector2(Random.Range(-3, 3), Random.Range(1, 2));
    //}


    public void Fly()
    {
        _rigidbody.AddForce(_direction * _force, ForceMode.Force);
    }


}