using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileScript : MonoBehaviour {

	private float speed = 5f;
	private float damage = 1f;
	private bool bouncy = false;


	// Use this for initialization
	void Start () {
		StartCoroutine(DeSpawn());
	}
	
	// Update is called once per frame
	void Update () {
		transform.position += transform.up * speed * Time.deltaTime;
	}

	void OnCollisionEnter2D(Collision2D col){
		if (!bouncy) {
			if (gameObject != null) {
				Destroy(gameObject);
			}
		}
	}

	IEnumerator DeSpawn(){
		yield return new WaitForSeconds(5);
		if (gameObject != null) {
			Destroy(gameObject);
		}
	}

	public void SetStats(float speed, float damage, bool bouncy){
		this.speed = speed;
		this.damage = damage;
		this.bouncy = bouncy;
	}

}
