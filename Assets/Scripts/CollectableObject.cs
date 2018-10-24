using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectableObject : MonoBehaviour {

	private void OnTriggerEnter2D(Collider2D other) {
		Player player = other.GetComponent<Player>();
		//Debug.Log(other.tag);
		if (player != null) {
			player.GetPoint(15);
			//Destroy(gameObject);
			gameObject.SetActive(false);
		}
	}
}
