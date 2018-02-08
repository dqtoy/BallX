using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UIStages : MonoBehaviour {
    public int IndexLevel = 0;
	// Use this for initialization
	void Start () {
        SaveData.SetIndexLevel(IndexLevel);
	}
	
	// Update is called once per frame
	void Update () {
	    
	}

    public void transmissionScene(string nameScene)
    {
        Application.LoadLevel(nameScene);
    }
}
