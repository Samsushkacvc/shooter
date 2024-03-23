using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MedKit : MonoBehaviour
{

    public float healAmount = 50;

    private void OnTriggerEnter(Collider other)
    {
        var playerHealth = other.GetComponent<PlayerHealth>();
        if (playerHealth != null )
        {
            playerHealth.AddHealth( healAmount );
            Destroy(gameObject);
        }
    }
}
