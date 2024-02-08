using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class BombComponent : MonoBehaviour
{
    private Transform _myTransform;
    private CircleCollider2D _circleCollider;
    public float bombcounter;
    [SerializeField]
    private LayerMask colision;
    [SerializeField]
    private GameObject salaSecreto;

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
        Collider2D collider = Physics2D.OverlapCircle(_myTransform.position, 1f, colision);
        if (collider != null)
        {
            Instantiate(salaSecreto, collider.gameObject.transform.position, Quaternion.identity);
        }
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
