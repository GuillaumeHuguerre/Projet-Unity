﻿using UnityEngine;
using System.Collections;

public class JeterScript : MonoBehaviour {

    private Rigidbody2D rig;

    // Use this for initialization
    void Start ()
    {
        rig = this.GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        if (this.GetComponent<Actions>().isJeter)
        {
            gameObject.layer = 8;
            rig.constraints = RigidbodyConstraints2D.FreezePositionX | RigidbodyConstraints2D.FreezeRotation;
        }

    }

    private void OnTriggerEnter2D(CircleCollider2D collision)
    {
        if (this.GetComponent<Actions>().isJeter && collision.gameObject.tag == "Player" && !collision.gameObject.GetComponent<Actions>().isBlock)
        {
            collision.gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(rig.velocity.x * Time.deltaTime, 5f);
            collision.gameObject.GetComponent<MouvementScript>().speed = 5f;
        }
    }



    // Update is called once per frame
    void Update ()
    {
	
	}
}
