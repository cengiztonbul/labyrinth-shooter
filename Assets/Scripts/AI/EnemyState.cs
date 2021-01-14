using UnityEngine;
using UnityEngine.UI;

public class EnemyState : MonoBehaviour
{
	public string stateName = "";
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
