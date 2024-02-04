using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    private Vector3 room = new Vector3(-26, -5, -10);
    private Transform _myTransform;
    private float x, y;
    [SerializeField] private float desiredTime = 3f;
    private float elapsedTime = 0f;
    private bool isMoving;
    Vector3 targetPosition;
    Vector3 initialPosition;

    [SerializeField]
    private GameObject Link;


    public void Move()
    {
        x = LinkMovement.Link.GetComponent<Rigidbody2D>().velocity.normalized.x;
        y = LinkMovement.Link.GetComponent<Rigidbody2D>().velocity.normalized.y; ;
        if (targetPosition == initialPosition) targetPosition = initialPosition + Vector3.right * 32 * x + Vector3.up * 20 * y;
        elapsedTime = 0f;
        isMoving = true;
    }
    public void Enter()
    {
        _myTransform.position = room;
        targetPosition = _myTransform.position;
        initialPosition = _myTransform.position;
    }
    public void Exit()
    {
        _myTransform.position = EnterTrigger.cameraPosition;
        targetPosition = _myTransform.position;
        initialPosition = _myTransform.position;
    }

    public bool IsMoving()
    {
        return isMoving;
    }

    // Start is called before the first frame update
    void Start()
    {
        _myTransform = transform;
        targetPosition = _myTransform.position;
        initialPosition = _myTransform.position;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        if (isMoving)
        {
            elapsedTime += Time.deltaTime;
            _myTransform.position = Vector3.Lerp(initialPosition, targetPosition, elapsedTime / desiredTime);
            x = y = 0;
            Link.gameObject.GetComponent<LinkInput>().StopMoving(elapsedTime);
            if (elapsedTime > desiredTime)
            {
                elapsedTime = 0f;
                initialPosition = _myTransform.position;
                isMoving = false;
            }
        }
        else
        {
            elapsedTime = 0f;
        }
    }

    private void Update()
    {

    }
}
