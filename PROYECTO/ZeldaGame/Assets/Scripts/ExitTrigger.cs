using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitTrigger : MonoBehaviour
{
    private void OnTriggerStay2D(Collider2D other)
    {
        LinkMovement link = other.gameObject.GetComponent<LinkMovement>();
        if (link != null) //cambiar por rigidbody.velocity
        {
            GameManager.Game.ActivateRoom(false, false, false);
            GameManager.Game.ExitRoom();
        }
    }
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
