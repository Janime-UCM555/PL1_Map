using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatorOcktorok : MonoBehaviour
{
    private Animator mAnimator;
    public bool takesDamage = false;
    private OcktorokMovement mOcktorokMovement;
    private SpriteRenderer _mSprite;

    // Start is called before the first frame update
    void Start()
    {
        mAnimator = GetComponent<Animator>();
        mOcktorokMovement = GetComponent<OcktorokMovement>();
        _mSprite = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (mOcktorokMovement._movementdirection != Vector3.zero)
        {
            if (mOcktorokMovement._movementdirection.x != 0)
            {
                mAnimator.SetInteger("AnimState", 0);
                if (mOcktorokMovement._movementdirection.x < 0)
                {
                    _mSprite.flipX = true;
                }
                else
                {
                    _mSprite.flipX = false;
                }
            }
            else if (mOcktorokMovement._movementdirection.y != 0)
            {
                mAnimator.SetInteger("AnimState", 1);
                if (mOcktorokMovement._movementdirection.x < 0)
                {
                    _mSprite.flipX = true;
                }
                else
                {
                    _mSprite.flipX = false;
                }
            }

            mAnimator.SetFloat("MoveX", mOcktorokMovement._movementdirection.x);
            mAnimator.SetFloat("MoveY", mOcktorokMovement._movementdirection.y);
        }
        else
        {
            mAnimator.SetInteger("AnimState", 0);
        }
    }
}