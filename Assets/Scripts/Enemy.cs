using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

	public int health = 100;
	public GameObject deathEffect;
	public Rigidbody2D rb;
	public float move = 0;
	public bool m_FacingRight = false;


	private void FixedUpdate() {
		
		if (move > 0 && move <=151) {
			move++;
			if (move==151) {
				move = 0;
			}
		} else if (move <=0 && move >=-151) {
			move--;
			if (move == -151) {
				move = 1;
			}
		}
		int movement = move > 0 ? 3: -3;
		if (movement<0 && !m_FacingRight) {
            Flip();
        } else if (movement>0 && m_FacingRight) {
            Flip();
        }
		
		rb.velocity = new Vector2 (movement, rb.velocity.y);
	}

	private void Flip () {
        m_FacingRight = !m_FacingRight;
        transform.Rotate(0f, 180f, 0f);
    }

	private void OnTriggerEnter2D(Collider2D other) {
		Player player = other.GetComponent<Player>();
		if (player != null) {
			player.TakeDamage(23);
			//Debug.Log("enemy hit player");
		}		
	}
	
	public void TakeDamage (int damage) {
		health -= damage;
		if (health <= 0) {
			Die();
		}
	}
	
	// Update is called once per frame
	void Die () {
		Instantiate(deathEffect, transform.position, Quaternion.identity);
		Destroy(gameObject);
	}
}
