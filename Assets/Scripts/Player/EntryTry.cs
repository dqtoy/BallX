using UnityEngine;
using System.Collections;

public class EntryTry : MonoBehaviour {
	// Use this for initialization
	void Awake () {
        int s = PlayerPrefs.GetInt("Nb Play");
        if (s == 0)
        {
            PlayerPrefs.SetInt("Nb Play", 1);
            Application.LoadLevel("Try");
        }
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
