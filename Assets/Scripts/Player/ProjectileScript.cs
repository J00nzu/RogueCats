using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileScript : MonoBehaviour {

	private float speed = 5f;
	private float damage = 1f;
	private bool bouncy = false;
	private int bounceTimes = 0;
	Rigidbody2D rb2;


	// Use this for initialization
	void Start () {
		StartCoroutine(DeSpawn());
		rb2 = GetComponent<Rigidbody2D>();
		rb2.velocity = transform.up * speed;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		//rb2.velocity = rb2.velocity.normalized * speed;
	}

	void OnCollisionEnter2D(Collision2D col){
		if (!bouncy) {
			if (gameObject != null) {
				Destroy(gameObject);
			}
		}else if(bounceTimes > 0){
			bounceTimes--;
			if(bounceTimes < 1){
				bouncy = false;
			}
		}
	}

	IEnumerator DeSpawn(){
		yield return new WaitForSeconds(5);
		if (gameObject != null) {
			Destroy(gameObject);
		}
	}

	public void SetStats(float speed, float damage, bool bouncy, int bounceTimes){
		this.speed = speed;
		this.damage = damage;
		this.bouncy = bouncy;
		this.bounceTimes = bounceTimes;
	}

}
