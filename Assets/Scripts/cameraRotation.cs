using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraRotation : MonoBehaviour
{
    private Vector2 startMousePosition, endMousePosition;
    private Vector3 initialRotation;

    public float horizontalRotateSpeed  = 25.0f;
    public float verticalRotateSpeed    = 25.0f;

    // Start is called before the first frame update
    void Start()
    {
        startMousePosition = endMousePosition = Vector2.zero;
        initialRotation = Vector3.zero;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
            startMousePosition = Input.mousePosition;

        if (Input.GetMouseButton(0)) 
            clicking();
    }

    void clicking()
    {
        endMousePosition = Input.mousePosition;

        float horizontalAngle   = startMousePosition.x - endMousePosition.x;
        float verticalAngle     = startMousePosition.y - endMousePosition.y;

        // horizontalAngle * horizontalRotateSpeed * Time.deltaTime
        // verticalAngle * verticalRotateSpeed * Time.deltaTime

        //transform.Rotate(Vector3.up, horizontalAngle * Time.deltaTime * horizontalRotateSpeed, Space.World);
        //transform.Rotate(Vector3.left, verticalAngle * Time.deltaTime * verticalRotateSpeed, Space.World);

        transform.Rotate(
            new Vector3(
                verticalAngle * verticalRotateSpeed,
                horizontalAngle * horizontalRotateSpeed,
                0
            ) * Time.deltaTime
            , Space.World
        );

        float z = transform.eulerAngles.z;
        transform.Rotate(0, 0, -z);

        startMousePosition = endMousePosition;
    }
}
