using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonCamera : MonoBehaviour {

    public Transform target;
    public Vector3 offset;
    public bool useOffsetValues;
    public float rotateSpeed;
    private const float Y_ANGLE_MIN = -50.0f;
    private const float Y_ANGLE_MAX = 50.0f;    
    public float horizontal;
    public float vertical;



    void Start()
    {
        if (!useOffsetValues)
        {
            offset = target.position - transform.position;
        }

    }

    void Update()
    {
        horizontal = Input.GetAxis("Mouse X") * rotateSpeed;
        target.Rotate(0, horizontal, 0);

        vertical = Input.GetAxis("Mouse Y") * rotateSpeed;
        target.Rotate(-vertical, 0, 0);

        Quaternion rotation = Quaternion.Euler(target.eulerAngles.x, target.eulerAngles.y, target.eulerAngles.z);
    }

    private void LateUpdate()
    {
        Vector3 _wantedPosition = target.TransformPoint(0, 4.0f, -15.0f);
        transform.position = Vector3.Lerp(transform.position, _wantedPosition, Time.deltaTime * 15.0f);

        Quaternion _wantedRotation = Quaternion.LookRotation(target.position - transform.position, target.up);

        transform.rotation = Quaternion.Slerp(transform.rotation, _wantedRotation, Time.deltaTime * 1.0f);

        transform.LookAt(target, target.up);
    }


}
