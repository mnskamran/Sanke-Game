using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonCam : MonoBehaviour
{
    public float speed;
    public Transform target;
    public Camera cam;

    // Update is called once per frame
    void LateUpdate()
    {
        Move();
    }

    private void Move()
    {
        Vector3 direction = (target.position - cam.transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(direction);
        lookRotation.x = transform.rotation.x;
        lookRotation.z = transform.rotation.z;

        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime);
        transform.position = Vector3.Slerp(transform.position, target.position, Time.deltaTime);
    }
}
