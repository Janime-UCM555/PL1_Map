using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraTrigger : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        LinkMovement link = other.gameObject.GetComponent<LinkMovement>();
        if (link != null)
        {
            GameManager.Game.MoveCamera();
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
