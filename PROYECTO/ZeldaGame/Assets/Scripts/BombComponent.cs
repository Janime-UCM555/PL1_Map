using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class BombComponent : MonoBehaviour
{
    private Transform _myTransform;
    private CircleCollider2D _circleCollider;
    public float bombcounter;
   
   
    // Start is called before the first frame update
    void Start()
    {
        _circleCollider = GetComponent<CircleCollider2D>();
        _myTransform = transform;
    }

    public void Explosion()
    {
        _circleCollider.enabled = true;
    }
    public void ExplosionEnds()
    {
        _circleCollider.enabled = false;
        Destroy(gameObject);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        LinkHealth linkHealth = collision.GetComponent<LinkHealth>();
        if (linkHealth != null)
        {
            linkHealth.TakesDamage();
        }
    }
}
