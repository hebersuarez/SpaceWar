using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FighterController : MonoBehaviour {
	public float speed = 10f;
	public float padding = 1.3f;
	public GameObject bullet;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		//IzquierdaDerecha
		float hInput = Input.GetAxis ("Horizontal");
			transform.position += new Vector3 (hInput * speed * Time.deltaTime, 0, 0);
		//ArribaAbajo
		float vInput = Input.GetAxis ("Vertical");
			transform.position += new Vector3 (0, vInput * speed * Time.deltaTime, 0);

		float NewX = Mathf.Clamp (transform.position.x, -10 + padding, 10 - padding);
		float NewY = Mathf.Clamp (transform.position.y, -10 + padding, 10 - padding);
			transform.position = new Vector3 (NewX, NewY, transform.position.z);

		//DetectarDisparo
		if (Input.GetKeyDown (KeyCode.Space)) {
			//Repetidor
			InvokeRepeating ("Fire", 0f, 0.25f);

		} else if (Input.GetKeyUp(KeyCode.Space)){
			//PararRepetidor
			CancelInvoke("Fire");
		}
	}
	void Fire() {
		var fighter = GameObject.Find ("Fighter");
		if (fighter != null) {
			Vector3 newLeftPosition = fighter.transform.position + Vector3.up * .5f + Vector3.left * .7f;
			Vector3 newRightPosition = fighter.transform.position + Vector3.up * .5f + Vector3.right * .7f;

			Instantiate (bullet, newLeftPosition, Quaternion.identity);
			Instantiate (bullet, newRightPosition, Quaternion.identity);
		}
	}
}
