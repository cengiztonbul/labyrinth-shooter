using UnityEngine;

class Bullet : MonoBehaviour
{
	public static float speed = 5;

	private void Update()
	{
		transform.position += transform.right * speed * Time.deltaTime;
	}

	private void OnTriggerEnter(Collider other)
	{
		if (other.CompareTag("Enemy"))
		{
			Destroy(other.gameObject);
		}

		Destroy(gameObject);
	}
}
