using UnityEngine;
using System.Collections;

public class MoveHalfBall1 : MonoBehaviour {
	// Use this for initialization
    public Vector2 speed;
    public GameObject Ball;
    private Rigidbody2D rigid;
	void Start () {
        rigid = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {
		#if UNITY_EDITOR
		if (Time.timeScale != 0){
            if (Input.GetMouseButtonDown(0))
            {
                Vector2 worldPoint = Camera.main.ScreenToWorldPoint(Input.mousePosition) - Ball.transform.position;
                float distance = Vector2.Distance(Camera.main.ScreenToWorldPoint(Input.mousePosition), Ball.transform.position);
                rigid.velocity = new Vector2(worldPoint.x * ControlPlayer.Scale * speed.x * Time.deltaTime, ControlPlayer.Scale * speed.y * Time.deltaTime);
            }
		}

		#elif UNITY_ANDROID
		if (Time.timeScale != 0){
			foreach (Touch touch in Input.touches) {
                if (touch.phase == TouchPhase.Began)
                {
                    Vector2 worldPoint = Camera.main.ScreenToWorldPoint(touch.position) - Ball.transform.position;
                    float distance = Vector2.Distance(Camera.main.ScreenToWorldPoint(Input.mousePosition), Ball.transform.position);
                    rigid.velocity = new Vector2(worldPoint.x * ControlPlayer.Scale * speed.x * Time.deltaTime, ControlPlayer.Scale * speed.y * Time.deltaTime);
                }
			}
		}
#endif
    }
}
