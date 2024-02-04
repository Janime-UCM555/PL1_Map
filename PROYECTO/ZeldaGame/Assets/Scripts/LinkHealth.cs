using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LinkHealth : MonoBehaviour
{
    private float _health;
    private LinkMovement _movement;
    private LinkInput _input;
    private AnimatorComponent _animator;
    // Start is called before the first frame update
    void Start()
    {
        _movement = GetComponent<LinkMovement>();
        _input = GetComponent<LinkInput>();
        _animator = GetComponent<AnimatorComponent>();
    }

    private void LinkMuere()
    {
        _movement.enabled = false;
        _input.enabled = false;
        _animator.isDead = true;
    }

    public void TakesDamage()
    {
        _health--;
        _animator.takesDamage = true;
        _animator.takesDamage = false;
    }


    // Update is called once per frame
    void Update()
    {
        if (_health == 0)
        {
            LinkMuere();
        }
    }
}

