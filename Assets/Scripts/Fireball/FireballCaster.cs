using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireballCaster : MonoBehaviour
{
    public Firebal fireballPrefab;
    public Transform fireballSourceTransform;
    void Start()
    {
        
    }
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Instantiate(fireballPrefab, fireballSourceTransform.position, fireballSourceTransform.rotation);
        }
    }
}
