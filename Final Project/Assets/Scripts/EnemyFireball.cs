using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFireball : MonoBehaviour
{
    public Vector3 direction { get; set; }
    public float range { get; set; }
    public int damage { get; set; }

    Vector3 spawnPosition;

    void Start()
    {
        Debug.Log("Fireball created");
        spawnPosition = transform.position;
        damage = 2;
        range = 20;
        GetComponent<Rigidbody>().AddForce(direction * 50f);
    }

    void Update()
    {
        if (Vector3.Distance(spawnPosition, transform.position) >= range)
        {
            Extinguish();
        }
    }

    void OnCollisionEnter(Collision other) 
    {
        Debug.Log("Collided with " + other.transform.tag);
        if (other.transform.tag != "Item" && other.transform.tag !=  "Enemy")
        {
            if (other.transform.tag == "Player")
            {
                other.transform.GetComponent<Player>().TakeDamage(damage);
            }
            Debug.Log("Extinguishing due to collision with " + other.transform.tag);
            Extinguish();
        }
    }

    void Extinguish()
    {
        Destroy(gameObject);
    }
}
