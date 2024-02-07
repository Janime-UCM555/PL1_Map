using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class LinkHealth : MonoBehaviour
{
    public static event Action OnPlayerDamaged;
    public static event Action OnPlayerDeath;
    public float health,maxHealth;
    private LinkMovement _movement;
    private LinkInput _input;
    private AnimatorComponent _animator;
    [SerializeField]
    private float desiredtime = 3.0f;
    private float elapsedtime = 0.0f;
    // Start is called before the first frame update
    void Start()
    {
        health = maxHealth;
        _movement = GetComponent<LinkMovement>();
        _input = GetComponent<LinkInput>();
        _animator = GetComponent<AnimatorComponent>();
    }

    private void LinkMuere()
    {
        _movement.enabled = false;
        _input.enabled = false;
        //_animator.isDead = true;
       OnPlayerDeath?.Invoke();
        GameManager.Game.LoadScene();
    }

    public void TakesDamage()
    {
        elapsedtime = 0;
        if (!_animator.takesDamage) 
        {
            health--;
            _animator.takesDamage = true;
            _movement.TakesDamages();
            OnPlayerDamaged?.Invoke();
        }
        
    }


    // Update is called once per frame
    void Update()
    {
        if (elapsedtime <= desiredtime) elapsedtime += Time.deltaTime;
        else 
        { 
            elapsedtime = 0;
            _animator.takesDamage = false;
            _input.enabled = true;
        }
        if (health <= 0)
        {
            LinkMuere();
        }
    }
}

