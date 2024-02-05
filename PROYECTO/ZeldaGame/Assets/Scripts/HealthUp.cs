using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Health : MonoBehaviour
{
    public LifeBarComponenet _lifeBar;
    public PlayerHealth _health;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        LinkMovement player = collision.GetComponent<LinkMovement>();
        if (player != null)
        {
            _lifeBar.HealthUP();
            Destroy(this.gameObject);
        }
    }
}
