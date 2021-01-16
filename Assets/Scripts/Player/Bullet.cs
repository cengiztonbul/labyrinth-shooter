using UnityEngine;

class Bullet : MonoBehaviour
{
	public static float speed = 5;
	public static float damage = 10;
	private void Update()
	{
		transform.position += transform.right * speed * Time.deltaTime;
	}

	private void OnTriggerEnter(Collider other)
	{
		if (other.CompareTag("Enemy"))
		{
			other.GetComponent<Health>().Damage(10);
		}

		Destroy(gameObject);
	}
}
