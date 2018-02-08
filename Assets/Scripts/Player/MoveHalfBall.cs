using UnityEngine;
using System.Collections;

public class MoveHalfBall : MonoBehaviour {
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		#if UNITY_EDITOR
		if (Time.timeScale != 0){
			Vector2 worldPoint = Camera.main.ScreenToWorldPoint (Input.mousePosition);
			transform.position = new Vector3 (worldPoint.x,transform.position.y,transform.position.z);
		}

		#elif UNITY_ANDROID
		if (Time.timeScale != 0){
			foreach (Touch touch in Input.touches) {
				Vector2 pMouse = Camera.main.ScreenToWorldPoint (Input.GetTouch(0).position);
					transform.position = new Vector3 (pMouse.x,transform.position.y,transform.position.z);
			}
		}
#endif
    }
}
