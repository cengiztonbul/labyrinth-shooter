using SaveSystem.Data;
using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
	[SerializeField] GameObject bullet;
	[SerializeField] Transform bulletStartPos;
	[SerializeField] LayerMask aimLayer;
	[SerializeField] Camera playerCamera;
	[SerializeField] float shootingPeriod = 0.07f;
	
	public int BulletCount { get; private set; }

	private float time = 0;
	
	private void Start()
	{
		BulletCount = 200;
	}

	private void Update()
	{
		time += Time.deltaTime;

		Aim();
		if (Input.GetMouseButton(0) && time > shootingPeriod && BulletCount > 0)
		{
			Shoot();
			time = 0;
			BulletCount -= 1;
		}
	}

	void Aim()
	{
		Ray ray = playerCamera.ScreenPointToRay(Input.mousePosition);

		if (Physics.Raycast(ray, out RaycastHit hit, 10, aimLayer))
		{
			float yAngle = Mathf.Atan2(-hit.point.z + transform.position.z, hit.point.x - transform.position.x) * Mathf.Rad2Deg;
			transform.rotation = Quaternion.Euler(0, yAngle, 0);
		}
	}

	void Shoot()
	{
		Instantiate(bullet, bulletStartPos.position, bulletStartPos.rotation);
	}

	public void SetPlayer(Vector3 position, int bulletCount)
	{
		BulletCount = bulletCount;
		transform.position = position;
	}
}