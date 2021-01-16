using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
	[SerializeField] GameObject healthBarObj;
	HealthBar healthBar;

	[SerializeField] float maxHealth = 100f;
	public float health;

	private void Awake()
	{
		health = maxHealth;
		healthBar = Instantiate(healthBarObj, transform.position, Quaternion.identity).GetComponent<HealthBar>();
		healthBar.SetOwner(transform);
		healthBar.SetSize(health / maxHealth);
	}

	public void Damage(float damage)
	{
		health -= damage;
		
		if (health <= 0)
		{
			Destroy(healthBar.gameObject);
			gameObject.SetActive(false);
		}

		healthBar.SetSize(health / maxHealth);
	}

	public void SetHealth(float health)
	{
		this.health = health;
		healthBar.SetSize(health / maxHealth);
	}
}
