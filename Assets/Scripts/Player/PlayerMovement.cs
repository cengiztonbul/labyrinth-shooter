using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float playerspeed = 10f;
    float xDirection;
    float zDirection;
    Transform cameraObj;
    Rigidbody rb;
    GameObject exitScreen;

    private void Start()
	{
        exitScreen = GameObject.FindGameObjectWithTag("WinScreen");
        exitScreen.SetActive(false);
        rb = GetComponent<Rigidbody>();
        cameraObj = GetComponentInChildren<Camera>().transform;
        cameraObj.parent = null;
	}

	private void Update()
	{
        xDirection = Input.GetAxis("Horizontal");
        zDirection = Input.GetAxis("Vertical");
        Vector3 moveDirection = new Vector3(xDirection, 0.0f, zDirection);
        // transform.position += moveDirection * playerspeed * Time.deltaTime;
        rb.MovePosition(transform.position += moveDirection * playerspeed * Time.deltaTime);

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("ExitPoint"))
        {
            exitScreen.SetActive(true);
            Destroy(this);
        }
    }
}
