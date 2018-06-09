using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleBehaviour : MonoBehaviour
{
	public Vector2 target;
	public float speed = 250f;
	private Rigidbody2D _rb2d;
	
	void Start ()
	{
		target = transform.position;
		_rb2d = GetComponent<Rigidbody2D>();
		_rb2d.velocity = (target - new Vector2(transform.position.x, transform.position.y)).normalized * speed;
	}

	private void OnCollisionEnter2D(Collision2D other)
	{
		if (other.gameObject.CompareTag("Minion"))
		{
			// TODO : Particle effect on both
			Destroy(other.gameObject);
			Destroy(gameObject);	
		}
	}
}
