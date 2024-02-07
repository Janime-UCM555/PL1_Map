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
        if (Physics2D.OverlapCircle(_myTransform.position + new Vector3(0, 0.35f, 0), 0.5f, colision) != null)
        {
            Vector3 position = new Vector3(Mathf.Round(_myTransform.position.x), Mathf.Round(_myTransform.position.y + 1), 1);
            Instantiate(salaSecreto, position, Quaternion.identity);
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
