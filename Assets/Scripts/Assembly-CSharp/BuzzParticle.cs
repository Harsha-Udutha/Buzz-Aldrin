using System.Collections;
using UnityEngine;

public class BuzzParticle : MonoBehaviour
{
	public GameObject BeesPerfab;

	public GameObject beecontainer;

	private int childCount;

	public bool isGameDone;

	private void Start()
	{
		childCount = base.transform.childCount;
		StartCoroutine(SpawnBuzz());
	}

	private IEnumerator SpawnBuzz()
	{
		while (!isGameDone)
		{
			yield return new WaitForSeconds(5f);
			int index = Random.Range(0, childCount);
			Vector3 position = base.transform.GetChild(index).position;
			Object.Instantiate(BeesPerfab, position, Quaternion.identity).transform.parent = beecontainer.transform;
		}
	}
}
