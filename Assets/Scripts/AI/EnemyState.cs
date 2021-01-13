using UnityEngine;

public class EnemyState : MonoBehaviour
{
	protected EnemyAI AI;

	private void Awake()
	{
		AI = GetComponent<EnemyAI>();
	}

	public virtual void Tick() { }
	
	public virtual void OnStart() { }

	public virtual void OnExit() { }

	public void SetContext(EnemyAI AI)
	{
		this.AI = AI;
	}
}
