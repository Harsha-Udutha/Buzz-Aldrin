using UnityEngine;

public class MidAirCheck : MonoBehaviour
{
	private void OnTriggerEnter(Collider other)
	{
		other.transform.Rotate(other.transform.rotation.x, other.transform.rotation.y, 180f);
	}
}
