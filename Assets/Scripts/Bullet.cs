using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

	public float speed = 20f;
	public Rigidbody2D rb;
	public int damage = 40;
	public GameObject impactEffect;

	void Start () {
		rb.velocity = transform.right * speed;
		//Debug.Log("Shoot");
	}

	private void OnTriggerEnter2D(Collider2D other) {
		
		Debug.Log(other.tag);
		//Destroy(this.gameObject);
		if (GetComponent<Collider2D>().gameObject.tag == "Wall") {
			Debug.Log("enter");
			//Destroy(this.gameObject);
		}
		
		Enemy enemy = other.GetComponent<Enemy>();
		if (enemy != null) {
			enemy.TakeDamage(damage);
		}
		Instantiate(impactEffect, transform.position, transform.rotation);
		Destroy(this.gameObject);
		//Destroy(impactEffect);

	}
	
}