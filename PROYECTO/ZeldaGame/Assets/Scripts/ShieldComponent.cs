using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldComponent : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<ProjectileComponent>() != null)
        {
            Vector2 Rebote = Vector2.Reflect(transform.right, collision.contacts[0].normal);
            collision.gameObject.GetComponent<Rigidbody2D>().velocity = Rebote* collision.gameObject.GetComponent<Rigidbody2D>().velocity.magnitude;
        }
    }
}
