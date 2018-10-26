using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour {

	public Transform firePoint;
	public GameObject bulletPrefab;
	public AudioClip shootEffect;
	private AudioSource source;

	void Awake () {
		source = GetComponent<AudioSource>();
	}

	void Update () {
		if (Input.GetButtonDown("Fire1")){
			Shoot();
		}
	}
	public void Shoot () {
		Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
		source.PlayOneShot(shootEffect, 1f);
	}
}
