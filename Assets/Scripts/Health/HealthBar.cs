using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBar : MonoBehaviour
{
	[SerializeField] Transform redHealthBar;
	private Transform owner;
	public Vector3 offset;

	private void Update()
	{
		transform.position = owner.position + offset;
	}

	public void SetSize(float barSize)
	{
		Vector3 size = redHealthBar.localScale;
		size.x = barSize;
		redHealthBar.localScale = size;
	}

	public void SetOwner(Transform owner)
	{
		this.owner = owner;
	}
}
