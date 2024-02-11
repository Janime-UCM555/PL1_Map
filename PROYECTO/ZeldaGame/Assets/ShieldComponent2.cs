using UnityEngine;

public class ShieldComponent2 : MonoBehaviour
{

    [SerializeField] private LinkMovement _linkMovement;
    private BoxCollider2D _collider;
    [SerializeField] private Transform _targetTransform;
    private Transform _myTransform;
    private Vector3 _NewPosition;
    private float OffsetX;
    private float OffsetY;
    public float HorX = 0.5f;
    public float HorY = -0.1f;
    public float VerX = 0.15f;
    public float VerY = 0.6f;
    private Vector3 _OffsetVector;
    private Quaternion _Rotation;
    public Vector3 _lastMovement;
    private Vector3 _OriginalPosition;

    // Start is called before the first frame update
    void Start()
    {
        _OriginalPosition = transform.position;
        _Rotation = transform.rotation;
        _collider = GetComponent<BoxCollider2D>();
        OffsetX = VerX;
        OffsetY = -VerY;
        _OffsetVector = new Vector3(OffsetX, OffsetY, 0f);
        _myTransform = transform;
        transform.position = _targetTransform.position + _OffsetVector;
    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Colisión");
        if (collision.gameObject.GetComponent<ProjectileComponent>() != null)
        {
            Debug.Log("Proyectil");
            collision.gameObject.GetComponent<ProjectileComponent>().enabled = false;
            collision.gameObject.GetComponent<Rigidbody2D>().velocity = _linkMovement._lastMovement * 10;
            Destroy(collision.gameObject, 0.2f);
        }
         
    }
    private void Update()
    {
        transform.rotation = _Rotation;
        transform.position = _OriginalPosition;
        if (_linkMovement._lastMovement.x == -1)
        {
            transform.Rotate(Vector3.up, 180);
            OffsetX = -1.28f;
            OffsetY = 0.36f;
        }
        else if (_linkMovement._lastMovement.x == 1)
        {
            OffsetX = HorX;
            OffsetY = HorY;
        }
        else if (_linkMovement._lastMovement.y == 1)
        {
            transform.Rotate(Vector3.forward, 90);
            OffsetX = -VerX;
            OffsetY = VerY;
        }
        else if (_linkMovement._lastMovement.y == -1 || _linkMovement._lastMovement.magnitude == 0)
        {
            transform.Rotate(Vector3.forward, 270);
            OffsetX = VerX;
            OffsetY = -VerY;
        }
        _OffsetVector = new Vector3(OffsetX, OffsetY, 0f);
        transform.position = _targetTransform.position + _OffsetVector;
    }
}

    // Update is called once per frame
    
   
    

