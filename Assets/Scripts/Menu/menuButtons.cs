using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class menuButtons : MonoBehaviour
{

    public Image Cadena;
    public string nameDataPercentage;
    public string nameScene;
    public int MaxDiamondsForEntry;
	// Use this for initialization
	void Start () {

        if ((int)PlayerPrefs.GetFloat(nameDataPercentage) == 100 && MaxDiamondsForEntry <= DataLevel.sumArrayLevel)
        {
            Destroy(Cadena.gameObject);
        }
        
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void ToScene()
    {
        if ((int)PlayerPrefs.GetFloat(nameDataPercentage) == 100 && MaxDiamondsForEntry <= DataLevel.sumArrayLevel)
        {
            Application.LoadLevel(nameScene);
        }
    }

    public void ToSceneDontStatement()
    {
        Application.LoadLevel(nameScene);
    }

}
