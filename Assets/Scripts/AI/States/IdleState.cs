using UnityEngine;

class IdleState : EnemyState
{
	[SerializeField] Transform player;

	[SerializeField] EnemyState patrol;
	[SerializeField] EnemyState chase;

	[SerializeField] float minIdleTime = 2;
	[SerializeField] float maxIdleTime = 5;	

	private float _time = 0;
	private float _idleTime;

	private void Start()
	{
		stateName = "Idle State";

		player = FindObjectOfType<PlayerShooting>().transform;
	}

	public override void OnStart()
	{
		_time = 0;
		_idleTime = Random.Range(minIdleTime, maxIdleTime);	
	}

	public override void Tick()
	{
		_time += Time.deltaTime;
		if (_time > _idleTime)
		{
			AI.ChangeState(patrol);
		}
		if (CanSeePlayer())
		{
			AI.ChangeState(chase);
		}
	}

	public bool CanSeePlayer()
	{
		Ray ray = new Ray(transform.position, (player.position - transform.position).normalized);
		if (Physics.Raycast(ray, out RaycastHit hit))
		{
			if (hit.collider.transform == player)
			{
				return true;
			}
		}
		return false;
	}
}
