using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Firebal : MonoBehaviour
{
    public float speed;
    public float lifetime;
    public float damage = 10;
    void Start()
    {
        
    }

    void FixedUpdate()
    {
        MoveFixedUpdate();
        Invoke("DestroyFireball", lifetime);
    }

    private void OnCollisionEnter(Collision collision) 
    {
        DamageEnemy(collision);
        DestoyFireball();
    }

    private void DamageEnemy(Collision collision)
    {
        var enemyHealth = collision.gameObject.GetComponent<EnemyHealth>();
        if (enemyHealth != null)
        {
            enemyHealth.DealDamage(damage);
        }
    }

    private void DestoyFireball()
    {
        Destroy(gameObject);
    }

    private void MoveFixedUpdate()
    {
        transform.position += transform.forward * speed * Time.deltaTime;
    }
}
