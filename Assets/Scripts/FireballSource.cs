using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireballSource : MonoBehaviour
{
    public Transform targetPoint;
    public Camera cameralink;
    public float targetInSkyDistance;
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void Update()
    {
        var ray = cameralink.ViewportPointToRay(new Vector3 (0.5f, 0.5f, 0));

        RaycastHit hit;
        if (Physics.Raycast(ray, out hit) )
        {
            targetPoint.position = hit.point;
        }
        else
        {
            targetPoint.position = ray.GetPoint(targetInSkyDistance);
        }

        transform.LookAt(targetPoint.position);
    }
}
