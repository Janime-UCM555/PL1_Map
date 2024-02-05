using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatorComponent : MonoBehaviour
{

    private Animator mAnimator;
    private SpriteRenderer mRenderer;
    public bool isAttacking = false;
    public bool isDead = false;
    public bool takesDamage = false;
    public bool placeBomb = false;
    private Rigidbody2D mRigidbody;
    private LinkMovement mLinkMovement;
    private SpriteRenderer _mSprite;
    private LinkInput mLinkInput;
    [SerializeField] private SpriteRenderer _SwordSpriteRenderer;
    Color colorsprite;
    [SerializeField]
    private float desiredtime = 3.0f;
    private float elapsedtime = 0.0f;
    public void LinkEzquizo()
    {
        elapsedtime = 0f;
        GetComponent<SpriteRenderer>().color = Color.Lerp(colorsprite, Color.cyan * Color.blue, Mathf.PingPong(Time.time, 0.5f));
    }
    // Start is called before the first frame update
    void Start()
    {
        mAnimator = GetComponent<Animator>();
        mRigidbody = GetComponent<Rigidbody2D>();
        mLinkMovement = GetComponent<LinkMovement>();
        _mSprite = GetComponent<SpriteRenderer>();
        mLinkInput = GetComponent<LinkInput>();
        colorsprite = GetComponent<SpriteRenderer>().color;
    }

    // Update is called once per frame
    void Update()
    {
        if (takesDamage && elapsedtime <= desiredtime) {LinkEzquizo();}
        if (mLinkMovement._directionVector != Vector3.zero)
        {
            mAnimator.SetInteger("AnimState", 2);
            if (mLinkMovement._directionVector.x < 0)
            {
                _mSprite.flipX = true;
            }
            else
            {
                _mSprite.flipX = false;
            }
            mAnimator.SetFloat("MoveX", mLinkMovement._directionVector.x);
            mAnimator.SetFloat("MoveY", mLinkMovement._directionVector.y);
        }
        else
        {
            mAnimator.SetInteger("AnimState", 0);
        }
        if (isAttacking)
        {
            mAnimator.SetInteger("AnimState", 1);
        }
        if (takesDamage)
        {
            mAnimator.SetInteger("Animstate", 4);
        }
        if (placeBomb)
        {
            mAnimator.SetInteger("AnimState", 3);
        }
        if(elapsedtime < desiredtime) elapsedtime += Time.deltaTime;
        else elapsedtime = 0;
    }
}
