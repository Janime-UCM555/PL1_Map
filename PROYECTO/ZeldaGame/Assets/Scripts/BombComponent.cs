using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class BombComponent : MonoBehaviour
{
    [SerializeField] private Transform _targetTransform;
    private Transform _myTransform;
    private float OffsetX;
    private float OffsetY;
    public float HorX = 0.5f;
    public float HorY = -0.1f;
    public float VerX = 0.15f;
    public float VerY = 0.6f;
    private Vector3 _lastMovement;
    private Vector3 _OriginalPosition;
    private Vector3 _OffsetVector;
    [SerializeField] private LinkMovement _movement;
    private CircleCollider2D _circleCollider;
    public float bombcounter;
    private float limitimer = 1.5f;
    private float timer = 0f;
    [SerializeField] private GameObject _bombPrefab;
    private GameObject _bombClone;
    private Vector3 _bombPlacement;
    // Start is called before the first frame update
    void Start()
    {
        _circleCollider = GetComponent<CircleCollider2D>();
        _OriginalPosition = transform.position;
        OffsetX = VerX;
        OffsetY = -VerY;
        _OffsetVector = new Vector3(OffsetX, OffsetY, 0f);
        _myTransform = transform;
    }

    public void PlaceBomb()
    {
        if (_lastMovement.x == -1)
        {
            OffsetX = -HorX;
            OffsetY = HorY;
            _OffsetVector = new Vector3(OffsetX, OffsetY, 0f);
        }
        else if (_lastMovement.x == 1)
        {
            OffsetX = HorX;
            OffsetY = HorY;
            _OffsetVector = new Vector3(OffsetX, OffsetY, 0f);
        }
        else if (_lastMovement.y == 1)
        {
            OffsetX = -VerX;
            OffsetY = VerY;
            _OffsetVector = new Vector3(OffsetX, OffsetY, 0f);
        }
        else if (_lastMovement.y == -1 || _lastMovement.magnitude == 0)
        {
            OffsetX = VerX;
            OffsetY = -VerY;
            _OffsetVector = new Vector3(OffsetX, OffsetY, 0f);
        }

        _bombPlacement = _targetTransform.position + _OffsetVector;

        _bombClone = Instantiate(_bombPrefab, _bombPlacement, Quaternion.identity);
    }
    public void Explosion()
    {
        _circleCollider.enabled = true;
    }
    public void ExplosionEnds()
    {
        _circleCollider.enabled = false;
        Destroy(gameObject);
    }
    // Update is called once per frame
    void Update()
    {
        if (_movement._directionVector != Vector3.zero)
        {
            _lastMovement = _movement._directionVector;
        }
    }
}
