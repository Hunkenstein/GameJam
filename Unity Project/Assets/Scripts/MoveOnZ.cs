﻿using UnityEngine;
using System.Collections;

public class MoveOnZ : MonoBehaviour {
	public float BulletSpeed;
	//public Vector3 PlayArea;
	private Vector3 myPosition;
	
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		this.transform.Translate (0, 0, BulletSpeed);
		myPosition = this.transform.position;
		myPosition.z = 0;
		this.transform.position = myPosition;
		if (Vector3.Distance(this.transform.position,Vector3.zero) >10) {
			Destroy (this.gameObject);
		}
	}

	void OnCollisionEnter(Collision Col){
		
		Destroy (this.gameObject);
		if(Col.transform.gameObject.layer == 9){
			Col.gameObject.GetComponent<EnemyScript>().MyEnemyObject.Explode();
		}
		else if(Col.transform.gameObject.layer == 11){
			Col.gameObject.GetComponentInChildren<Player>().ShipMesh.renderer.enabled = false;
			
		}
	
	}
}
