using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class stageFiniched : MonoBehaviour {
	public static bool GameIsOver = false;
	// Use this for initialization
	void Start () {
        GameIsOver = false;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D(Collider2D other) {
		if (other.gameObject.name == SaveData.GetNameBall ()) {
			if (!GameIsOver) {
                IsFiniched();
			}
		}
	}

	void OnCollisionEnter2D(Collision2D other) {
		if (other.gameObject.name == SaveData.GetNameBall ()) {
			if (!GameIsOver) {
				IsFiniched();
			}
		}
	}

    void IsFiniched()
    {
        ControlPlayer.StageFiniched();
        GameIsOver = true;
    }
}
