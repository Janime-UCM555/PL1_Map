using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatorMoblin : MonoBehaviour
{
    private Animator mAnimator;
    public bool takesDamage = false;
    private MoblinMovement mMoblinMovement;
    private SpriteRenderer _mSprite;

    // Start is called before the first frame update
    void Start()
    {
        mAnimator = GetComponent<Animator>();
        mMoblinMovement = GetComponent<MoblinMovement>();
        _mSprite = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (mMoblinMovement._movementdirection != Vector3.zero)
        {
            if (mMoblinMovement._movementdirection.x != 0)
            {
                mAnimator.SetInteger("AnimState", 0);
                if (mMoblinMovement._movementdirection.x < 0)
                {
                    _mSprite.flipX = true;
                }
                else
                {
                    _mSprite.flipX = false;
                }
            }
            else if (mMoblinMovement._movementdirection.y != 0)
            {
                mAnimator.SetInteger("AnimState", 1);
                if (mMoblinMovement._movementdirection.x < 0)
                {
                    _mSprite.flipX = true;
                }
                else
                {
                    _mSprite.flipX = false;
                }
            }

            mAnimator.SetFloat("MoveX", mMoblinMovement._movementdirection.x);
            mAnimator.SetFloat("MoveY", mMoblinMovement._movementdirection.y);
        }
        else
        {
            mAnimator.SetInteger("AnimState", 0);
        }
    }
}
