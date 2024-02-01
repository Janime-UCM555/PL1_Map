using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LinkInput : MonoBehaviour
{
    private LinkMovement _linkMovement;
    [SerializeField] private AttackComponent _attackComponent;
    private AnimatorComponent _myAnimator;
    public bool nomov;

    // Start is called before the first frame update
    void Start()
    {
        _linkMovement = GetComponent<LinkMovement>();
        _myAnimator = GetComponent<AnimatorComponent>();
    }

    // Update is called once per frame
    void Update()
    {
        _linkMovement.RegisterX(Input.GetAxisRaw("Horizontal"));
        _linkMovement.RegisterY(Input.GetAxisRaw("Vertical"));
        if (Input.GetKeyDown(KeyCode.Space))
        {
            _myAnimator.isAttacking = true;

        }
        else
        {
            _myAnimator.isAttacking = false;

        }

    }
}
