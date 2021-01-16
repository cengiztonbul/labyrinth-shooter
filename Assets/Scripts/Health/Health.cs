using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Health : MonoBehaviour
{
	[SerializeField] UnityEvent OnDie;
	[SerializeField] GameObject healthBarObj;
	public HealthBar healthBar;
	[SerializeField] float maxHealth = 100f;
	public float health;

	GameObject gameOverScreen;
	private void Awake()
	{
		health = maxHealth;
		healthBar = Instantiate(healthBarObj, transform.position, Quaternion.identity).GetComponent<HealthBar>();
		healthBar.SetOwner(transform);
		healthBar.SetSize(health / maxHealth);
	}

	private void Start()
	{
		if (tag == "Player")
		{
			GameObject found = GameObject.FindGameObjectWithTag("GameOverScreen");
			if (found != null)
			{
				gameOverScreen = found;
				gameOverScreen?.SetActive(false);
			}
		}
	}

	public void Damage(float damage)
	{
		health -= damage;
		
		if (health <= 0)
		{
			health = 0;
			healthBar.gameObject.SetActive(false);
			if (tag == "Player")
			{
				gameOverScreen.SetActive(true);
				Destroy(healthBar.gameObject);
			}
			
			gameObject.SetActive(false);
			
		}

		healthBar.SetSize(health / maxHealth);
	}

	public void SetHealth(float health)
	{
		this.health = health;
		healthBar.SetSize(health / maxHealth);

		if (tag == "Player")
		{
			GameObject found = GameObject.FindGameObjectWithTag("GameOverScreen");
			if (found != null)
			{
				gameOverScreen = found;
				gameOverScreen.SetActive(false);
			}
		}
	}
}
