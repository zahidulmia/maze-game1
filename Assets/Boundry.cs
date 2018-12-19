using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boundry : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}

	void OnCollisionEnter(Collision col)
	{
		Debug.Log (col.gameObject.name + " " + col.gameObject.tag);
		if (col.gameObject.CompareTag ("Player")) {
			col.gameObject.GetComponentInParent<Player> ().Reposition ();
		}
	}
}
