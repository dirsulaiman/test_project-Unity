using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BoardManager : MonoBehaviour {

	public Text successText;
	public Text failedText;
	public Text health;
	public Text points;
	public bool showStatus = false;

	void Start () {
		successText.gameObject.SetActive(false);
		failedText.gameObject.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void GameOver (bool win) {
		if (win) {
			successText.gameObject.SetActive(true);
		} else {
			failedText.gameObject.SetActive(true);
		}
	}

	public void toggleStatus() {
		if (showStatus) {
			health.gameObject.SetActive(false);
			points.gameObject.SetActive(false);
		} else if (!showStatus) {
			health.gameObject.SetActive(true);
			points.gameObject.SetActive(true);
		}
	}


}
