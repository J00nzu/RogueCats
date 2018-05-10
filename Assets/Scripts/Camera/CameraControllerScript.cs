using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControllerScript : MonoBehaviour {

	Transform player;

	// Use this for initialization
	void Start() {
		player = GameObject.Find("Player").transform;
	}

	// Update is called once per frame
	void Update() {
		transform.position = new Vector3(player.position.x, player.position.y, -10);
	}
}