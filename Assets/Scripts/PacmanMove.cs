﻿using UnityEngine;
using System.Collections;

public class PacmanMove : MonoBehaviour 
{
    public float speed = 0.4f;
    Vector2 dest = Vector2.zero;

	// Use this for initialization
	void Start () 
    {
        dest = transform.position;
	}
		
    void FixedUpdate()
    {
        // move closer to destination
        Vector2 p = Vector2.MoveTowards(transform.position, dest, speed);
        rigidbody2D.MovePosition(p);

		// Check for Input if not moving
		if ((Vector2)transform.position == dest) 
		{
			if (Input.GetKey(KeyCode.UpArrow) && valid(Vector2.up))
				dest = (Vector2)transform.position + Vector2.up;
			if (Input.GetKey(KeyCode.RightArrow) && valid(Vector2.right))
				dest = (Vector2)transform.position + Vector2.right;
			if (Input.GetKey(KeyCode.DownArrow) && valid(-Vector2.up))
				dest = (Vector2)transform.position - Vector2.up;
			if (Input.GetKey(KeyCode.LeftArrow) && valid(-Vector2.right))
				dest = (Vector2)transform.position - Vector2.right;
		}

        // animation parameters
        Vector2 dir = dest - (Vector2)transform.position;
        GetComponent<Animator>().SetFloat("DirX", dir.x);
        GetComponent<Animator>().SetFloat("DirY", dir.y);
    }

    bool valid(Vector2 dir)
    {
        // cast line from 'next to Pac-man' to 'Pac-man'
        Vector2 pos = transform.position;
        RaycastHit2D hit = Physics2D.Linecast(pos + dir, pos);
        return (hit.collider == collider2D);
    }
}
