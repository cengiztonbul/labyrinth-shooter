using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
	[SerializeField] GameObject healthBarObj;
	HealthBar healthBar;

	[SerializeField] float maxHealth = 100f;
	private float _health;

	private void Start()
	{
		_health = maxHealth;
		healthBar = Instantiate(healthBarObj, transform.position + Vector3.up, Quaternion.identity).GetComponent<HealthBar>();
		healthBar.SetOwner(transform);
	}

	public void Damage(float damage)
	{
		_health -= damage;
		
		if (_health <= 0)
		{
			Destroy(healthBar.gameObject);
			gameObject.SetActive(false);
		}

		healthBar.SetSize(_health / maxHealth);
	}
}
