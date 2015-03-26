using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(NetworkView))]
public class Player : MonoBehaviour {

	private Transform tf;
	private Rigidbody rb;
	private Camera camera;

	private NetworkView nv;
	// Use this for initialization
	void Start () {
		tf = transform;
		rb = GetComponent<Rigidbody> ();
		nv = GetComponent<NetworkView> ();
		camera = GetComponent<Camera> ();
		return;
	}
	
	// Update is called once per frame
	void Update () {
		if (nv.isMine) {
			if (Input.GetButton ("Vertical")) {
				tf.position += tf.forward * 0.5f;
			}
			if (Input.GetButton ("Horizontal")) {
				tf.RotateAround (tf.TransformDirection (new Vector3 (0.0f, 1.0f, 0.0f)), 0.1f * Input.GetAxisRaw ("Horizontal"));
			}
		}
	}
}
