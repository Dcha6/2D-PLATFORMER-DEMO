﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyBullet : MonoBehaviour
{
    public float speed = 20f;
    public int damage; 
    public Rigidbody2D rb;
    public GameObject impactEffect;
    public float timer;
    public float effectTimer;
    // Start is called before the first frame update
    void Start()
    {
        rb.velocity = transform.right * speed;
    }
    void Update()
    {
        timer += 1.0F * Time.deltaTime;
        if (timer >= 1)
        {
            GameObject.Destroy(this.gameObject);
        }
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        
        Move2D player = other.GetComponent<Move2D>();
        if (player != null)
        {
            player.TakeDamage(damage);
        }
        GameObject effect = Instantiate(impactEffect, transform.position, transform.rotation);
        Destroy(effect, effectTimer);
        Destroy(this.gameObject);
        

    }
    void OnCollisionEnter2D(Collision2D other)
    {
        Destroy(this.gameObject);
    }

}
