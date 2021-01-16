using UnityEngine;

public class ChasePlayerState : EnemyState
{
	[SerializeField] float chaseSpeed;
	[SerializeField] EnemyState idle;

	Transform player;
	Vector3 lastSeenPosition;
	bool canSeePlayer;
	float damagePeriod = 0.3f;
	float time = 0;
	
	float damagePower = 10;

	private void Start()
	{
		stateName = "Chase State";
		player = FindObjectOfType<PlayerMovement>().transform;
		idle = GetComponent<IdleState>();
	}

	public override void Tick()
	{
		time += Time.deltaTime;
		if (!player.gameObject.activeSelf)
		{
			AI.ChangeState(idle);
		}
		canSeePlayer = CanSeePlayer();
		if (!canSeePlayer && DistanceToLastSeenPosition() < 0.3f)
		{
			AI.ChangeState(idle);
		}
		if (DistanceToLastSeenPosition() > 0.3f)
		{
			MoveToLastSeenPosition();
		}
		if ((canSeePlayer) && (time > damagePeriod) && (DistanceToLastSeenPosition() <= 0.3f))
		{
			player.GetComponent<Health>().Damage(damagePower);
			time = 0;
		}
	}

	public float DistanceToLastSeenPosition()
	{
		return (transform.position - lastSeenPosition).sqrMagnitude;
	}

	public void MoveToLastSeenPosition()
	{
		Vector3 direction = (lastSeenPosition - transform.position);
		direction.y = 0;
		transform.position += direction.normalized * chaseSpeed * Time.deltaTime;
	}

	bool CanSeePlayer()
	{
		Ray ray = new Ray(transform.position, (player.position - transform.position).normalized);
		if (Physics.Raycast(ray, out RaycastHit hit))
		{
			if(hit.collider.transform == player)
			{
				lastSeenPosition = hit.transform.position;
				return true;
			}
		}
		return false;
	}
}
