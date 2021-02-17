using UnityEngine;

public class PlayerController : MonoBehaviour {

	private float moveSpeed = 100f;

	private float horizontal = 0f;
    private float vertical = 0f;

    private Rigidbody rb;

	void Start ()
	{
		rb = GetComponent<Rigidbody>();
	}

	void Update ()
	{
		horizontal = Input.GetAxis("Horizontal") * moveSpeed * Time.deltaTime;
        vertical = Input.GetAxis("Vertical") * moveSpeed * Time.deltaTime;
    }

	void FixedUpdate ()
	{
        Vector3 origin = Vector3.zero;

        Quaternion hq = Quaternion.AngleAxis(-horizontal, Vector3.up);
        Quaternion vq = Quaternion.AngleAxis(vertical, Vector3.right);

        Quaternion q = hq * vq;

        rb.MovePosition(q * (rb.transform.position - origin) + origin);
        transform.LookAt(Vector3.zero);
    }

}
