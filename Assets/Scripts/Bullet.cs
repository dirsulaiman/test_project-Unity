using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

	public float speed = 18f;
	public Rigidbody2D rb;
	public int damage = 18;
	public GameObject impactEffect;
	//public AudioClip impact;
	//private AudioSource source;

	void Start () {
		rb.velocity = transform.right * speed;
		
	}

	private void OnTriggerEnter2D(Collider2D other) {
		//source = GetComponent<AudioSource>();
		//source.PlayOneShot(impact, 1f);
		if (GetComponent<Collider2D>().gameObject.tag == "Wall") {
			Debug.Log("enter");
		}
		
		Enemy enemy = other.GetComponent<Enemy>();
		if (enemy != null) {
			enemy.TakeDamage(damage);
		}
		Instantiate(impactEffect, transform.position, transform.rotation);
		Destroy(this.gameObject);

	}
	
}