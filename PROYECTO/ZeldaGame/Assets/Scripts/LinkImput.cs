using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LinkInput : MonoBehaviour
{
    private LinkMovement _linkMovement;
    [SerializeField] private AttackComponent _attackComponent;
    private AnimatorComponent _myAnimator;
    public bool swordAttack = false;
    public bool placesBomb = false;
    private bool isInputEnabled = true;
    private bool isMoving;

    [SerializeField]
    private GameObject MainCamera;

    public void DisableInput()
    {
        isInputEnabled = false;
    }
    public void EnableInput()
    {
        isInputEnabled = true;
    }

    public void StopMoving(float elapsedTime)
    {
        if (elapsedTime > 0.5f && isInputEnabled != true)
        {
            _linkMovement.RegisterX(0);
            _linkMovement.RegisterY(0);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        _linkMovement = GetComponent<LinkMovement>();
        _myAnimator = GetComponent<AnimatorComponent>();
    }

    // Update is called once per frame
    void Update()
    {
        isMoving = MainCamera.gameObject.GetComponent<CameraMovement>().IsMoving();
        Debug.Log(isMoving);
        if (!isMoving)
        {
            EnableInput();
        }
        else
        {
            DisableInput();
        }
        if (isInputEnabled)
        {
            _linkMovement.RegisterX(Input.GetAxisRaw("Horizontal"));
            _linkMovement.RegisterY(Input.GetAxisRaw("Vertical"));

            if (Input.GetKeyDown(KeyCode.Space))
            {
                _myAnimator.isAttacking = true;
                if (Input.GetKeyDown(KeyCode.Space))
                {
                    swordAttack = true;

                }
            }
            else if (Input.GetKeyDown(KeyCode.B))
            {
                _myAnimator.placeBomb = true;

            }
            else
            {
                _myAnimator.isAttacking = false;
                swordAttack = false;
                _myAnimator.placeBomb = false;
            }

        }
    }
}
