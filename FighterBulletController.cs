using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FighterBulletController : MonoBehaviour {

	public float bulletSpeed = 18f;

	// Use this for initialization
	void Start () {
		this.GetComponent<Rigidbody2D>().velocity = new Vector3 (0, bulletSpeed, 0);
	}

	// Update is called once per frame
	void Update () {
		if (transform.position.y > 10.5) {
			Destroy (gameObject);
			//print ("Bala Perdida");
		}

	}
}
