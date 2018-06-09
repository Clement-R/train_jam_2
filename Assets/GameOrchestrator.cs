using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOrchestrator : MonoBehaviour
{
	public int nbOfMinions;
	public GameObject minionPrefab;
	public float rndRadius;
	public float minionRadiusSize;
	
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
	}
}
