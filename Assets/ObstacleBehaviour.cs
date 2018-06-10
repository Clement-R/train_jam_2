using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleBehaviour : MonoBehaviour
{
	public float speed = 250f;
	private Rigidbody2D _rb2d;
	private Vector2 _target;
	
	void Awake ()
	{
		_rb2d = GetComponent<Rigidbody2D>();
	}

	public void Launch(Vector2 target)
	{
		_target = target;
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
		else if (other.gameObject.CompareTag("Obstacle"))
		{
			Destroy(other.gameObject);
			Destroy(gameObject);
		}
	}
}
