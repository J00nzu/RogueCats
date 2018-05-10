using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerScript : MonoBehaviour {

	Rigidbody2D rb;

	public float speed = 5f;

	StaffScript staff;
	
	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody2D>();
		staff = GetComponent<StaffScript>();
	}
	
	// Update is called once per frame
	void Update () {
		float moveHorizontal = Input.GetAxis ("Horizontal");
        float moveVertical = Input.GetAxis ("Vertical");
        
        Vector2 movement = new Vector2 (moveHorizontal, moveVertical);

		rb.velocity = (movement * speed);
		//Vector3 targetPos = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0);
		//transform.LookAt(Camera.main.ScreenToWorldPoint(targetPos), Vector3.forward);

		Vector3 dir = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
		float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
		transform.rotation = Quaternion.AngleAxis(angle -90, Vector3.forward);
		
		if(Input.GetMouseButton(0)){
			staff.Shoot();
		}
	}
}
