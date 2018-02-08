using UnityEngine;
using System.Collections;

public class MoveObject : MonoBehaviour {
	public Vector2 Direction;
	public static float speed = 5f;
	public float waitAndDestroy = 10f;

	// Use this for initialization
	void Start () {
		StartCoroutine (fWaitAndDestroy());
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        transform.position += new Vector3(Direction.x * Time.deltaTime * speed * ControlPlayer.Scale, Direction.y * Time.deltaTime * speed * ControlPlayer.Scale, 0);
	}

	IEnumerator fWaitAndDestroy (){
		yield return new WaitForSeconds(waitAndDestroy);
		Destroy (gameObject);
	}
}
