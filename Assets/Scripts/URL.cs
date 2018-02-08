using UnityEngine;
using System.Collections;

public class URL : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void InputURL(string URL) {
        Application.OpenURL(URL);
    }
}
