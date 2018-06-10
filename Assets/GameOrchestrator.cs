using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOrchestrator : MonoBehaviour
{
	public int nbOfMinions;
	public GameObject minionPrefab;
	public float rndRadius;
	public float minionRadiusSize;

	public GameObject obstaclePrefab;

	private float _offset = 60f;
	
	void Start () {
		
		// Spawn minions
		for (int i = 0; i < nbOfMinions; i++)
		{
			for (int j = 0; j < 100; j++)
			{
				// Get a random point in a radius around 0,0
				Vector2 rndPos = Random.insideUnitCircle;
				rndPos = new Vector2(
					Random.Range(-rndPos.x * rndRadius * 2f, rndPos.x * rndRadius * 2f),
					Random.Range(-rndPos.y * rndRadius * 2f, rndPos.y * rndRadius * 2f));

				// Check if can spawn a minion here
				Collider2D[] cols = Physics2D.OverlapCircleAll(Vector2.zero, minionRadiusSize);
				if (cols.Length == 0)
				{
					// Spawn it	
					Instantiate(minionPrefab, rndPos, Quaternion.identity);
					break;
				}	
			}
		}

		StartCoroutine(SpawnObstacle());
	}

	private IEnumerator SpawnObstacle()
	{
		while (true)
		{
			yield return new WaitForSeconds(0.5f);
		
			// Choose a position outside of camera
			float height = Camera.main.orthographicSize * 2f;
			float width = (height / 9f) * 16f;
		
			// Choose if the point is going to move on Y or X
			float rnd = Random.Range(-1f, 1f);

			float x = 0f;
			float y = 0f;

			if (rnd >= 0)
			{
				// Move on X
				x = Random.Range(-width / 2f, width / 2f);
				y = ((height / 2f) + _offset) * (rnd < 0.5f ? 1f : -1f);
			}
			else
			{
				// Move on Y
				x = ((width / 2f) + _offset) * (rnd < -0.5f ? 1f : -1f);
				y = Random.Range(-height / 2f, height / 2f);
			}
			
			GameObject obstacle = Instantiate(obstaclePrefab, new Vector2(x, y), Quaternion.identity);
			
			Vector2 target = Vector2.zero;
			target.x = -x;
			target.y = -y;
			obstacle.GetComponent<ObstacleBehaviour>().Launch(target);
		}
	}
}
