using UnityEngine;
using System.Collections;

public class ControllerMovement : MonoBehaviour {

	public float minMovement, speed, jumpHeight;
	public string floorTag;

	private Rigidbody rb;
	private bool groundTouch;

	// Use this for initialization
	void Start () {
		Cursor.lockState = CursorLockMode.Locked;
		Cursor.visible = false;

		rb = GetComponent<Rigidbody> ();
	}
	
	// Update is called once per frame
	void Update () {
		//Get Controller Input
		transform.Translate (Input.GetAxis ("Horizontal") * speed * Time.deltaTime, 0, 0);
		//Unlock Cursor when Esc is pressed
		if (Input.GetKeyDown ("escape")) {
			Cursor.lockState = CursorLockMode.None;
			Cursor.visible = true;
		}
		//Jump
		if (Input.GetButtonDown ("Submit") & groundTouch == true) {
			rb.AddForce (0, jumpHeight, 0);
		}
	}

	void OnCollisionEnter(Collision col) {
		if (col.gameObject.tag == floorTag) {
			groundTouch = true;
		}
	}

	void OnCollisionExit(Collision col) {
		if (col.gameObject.tag == floorTag) {
			groundTouch = false;
		}
	}
}
