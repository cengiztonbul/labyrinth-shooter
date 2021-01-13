using UnityEngine;

class Idle : EnemyState
{
	[SerializeField] EnemyState patrol;
	
	[SerializeField] float minIdleTime = 2;
	[SerializeField] float maxIdleTime = 5;	

	private float _time = 0;
	private float _idleTime;

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
	}
}
