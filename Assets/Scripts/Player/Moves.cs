using UnityEngine;
using System.Collections;

public class Moves : MonoBehaviour {
    public float speedRotate = 1;
    public int direction = 1;
    public bool IstransformRotate = true;
	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
        if (IstransformRotate) rotateObject();
	}

    void rotateObject()
    {
        transform.Rotate(new Vector3(0, 0, direction * speedRotate * Time.deltaTime));
    }
}
