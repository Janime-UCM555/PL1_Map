using System.Collections;
using System.Collections.Generic;
using TMPro.EditorUtilities;
using UnityEngine;

public class SwordPickUpComponent : MonoBehaviour
{
    public AttackComponent attack; 
    public UIManager _uiManager;
    public LinkInput _input;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        LinkMovement player = collision.gameObject.GetComponent<LinkMovement>();
        if(player != null)
        {
            _uiManager.PonerEspada(true);
            Destroy(this.gameObject);
            attack._canAttack = true;
            _input.canAttack = true;
        }
    }
}
