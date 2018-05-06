using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StaffScript : MonoBehaviour {
	
	GameObject bullet;
	private bool canShoot = true;

	private float speed = 5f;
	private float damage = 1f;
	private bool bouncy = false;
	private float shotRate = 1f;

	// Use this for initialization
	void Start () {
		bullet = Resources.Load("Prefabs/Bullet") as GameObject;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void Shoot(){
		if (canShoot) {
			GameObject projectile = Instantiate(bullet, transform.position + transform.up, transform.rotation);
			projectile.GetComponent<ProjectileScript>().SetStats(speed, damage, bouncy);

			canShoot = false;
			StartCoroutine(CoolDown());
		}
	}

	IEnumerator CoolDown(){
		yield return new WaitForSeconds(1 / shotRate);
		canShoot = true;
	}

	public void SetStats(float speed, float damage, bool bouncy) {
		this.speed = speed;
		this.damage = damage;
		this.bouncy = bouncy;
	}
}
