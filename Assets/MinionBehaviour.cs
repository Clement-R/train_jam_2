using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinionBehaviour : MonoBehaviour
{
	public float speed = 150f;
	public float maxSpeed = 300f;
	
	private Rigidbody2D _rb2d;
	private Vector2 _target;
	
	void Start ()
	{
		_rb2d = GetComponent<Rigidbody2D>();
	}
	
	void Update ()
	{
		Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
		_target = new Vector2(mousePos.x, mousePos.y);
	}

	private void FixedUpdate()
	{
		// _rb2d.velocity = (_target - new Vector2(transform.position.x, transform.position.y)).normalized * speed;
		Vector2 desiredVelocity = (_target - new Vector2(transform.position.x, transform.position.y)).normalized * speed;
		Vector2 steering = desiredVelocity - _rb2d.velocity;
		steering = Vector2.ClampMagnitude(steering, maxSpeed);
            
		_rb2d.AddForce(steering);
		
	}
}
