using UnityEngine;
using System.Collections;

public class GhostMove : MonoBehaviour 
{
	public Transform[] waypoints;
	int current = 0;

	public float speed = 0.3f;

	void FixedUpdate()
	{
		// Move to waypoint if not there
		if (transform.position != waypoints [current].position) 
		{
			Vector2 p = Vector2.MoveTowards(transform.position, waypoints[current].position, speed);
			rigidbody2D.MovePosition(p);
		}
		// Select next waypoint
		else
		{
			current = (current + 1) % waypoints.Length;
		}

		// Animation
		Vector2 dir = waypoints [current].position - transform.position;
		GetComponent<Animator> ().SetFloat ("DirX", dir.x);
		GetComponent<Animator> ().SetFloat ("DirY", dir.y);
	}

	void OnTriggerEnter2D(Collider2D co)
	{
		if (co.name == "pacman") 
		{
			Destroy(co.gameObject);
		}
	}
}
