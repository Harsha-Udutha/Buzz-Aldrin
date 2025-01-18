using UnityEngine;

public class Buzz : MonoBehaviour
{
	private PlayerMovement player;

	private int damageHouse = 1;

	public float biteRate = 0.5f;

	public float nextBite;

	private void Start()
	{
		player = GameObject.FindWithTag("Player").GetComponent<PlayerMovement>();
		if (player == null)
		{
			MonoBehaviour.print("Player is null");
		}
	}

	private void Update()
	{
		if (Random.Range(0, 2) == 0 && Time.time > nextBite)
		{
			nextBite = Time.time + biteRate;
			if (Random.Range(0, 4) == 0)
			{
				player.DamageHouse(damageHouse);
			}
		}
	}
}
