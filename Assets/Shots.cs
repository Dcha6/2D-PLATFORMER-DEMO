using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shots : MonoBehaviour
{
    public float speed;
    public int damage;
    private Transform beacon;
    private Vector2 target;
    // Start is called before the first frame update
    void Start()
    {
        beacon = GameObject.FindGameObjectWithTag("Beacon").transform;
        target = new Vector2(beacon.position.x, beacon.position.y);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, target, speed*Time.deltaTime);
        if(transform.position.x == target.x && transform.position.y == target.y)
        {
            DestroyProjectile();
        }
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Beacon"))
        {
            DestroyProjectile();
        }
        Move2D player = other.GetComponent<Move2D>();
        if (player != null)
        {
            player.TakeDamage(damage);
        }
    }
    void DestroyProjectile()
    {
        Destroy(gameObject);
    }
}
