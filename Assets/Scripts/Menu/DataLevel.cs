using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class DataLevel : MonoBehaviour
{
    public int NbLevel = 1;
    public string IndexStage = "0";
	public GameObject panelTexts;
    public Text textBestScore;
    public static int sumArrayLevel = 0;
    public int MaxDiamondsForEntry;
    public GameObject CadenaDiamadsMax;

    private string NbOfJupmSave;
	private Text[] textsLevel;
	private int[] dataLevelDiamonds;

	// Use this for initialization
    void Awake(){
    
        NbOfJupmSave = "Jumps" + IndexStage;
        textBestScore.text = PlayerPrefs.GetInt(NbOfJupmSave).ToString();
		textsLevel = panelTexts.GetComponentsInChildren<Text> ();
        dataLevelDiamonds = new int[textsLevel.Length];
		for (int i = 0; i < textsLevel.Length;i++)
        {
            dataLevelDiamonds[i] = (int)PlayerPrefs.GetFloat("Diamonds" + NbLevel.ToString() + "|" + (i + 1).ToString());
            textsLevel[i].text = (dataLevelDiamonds[i]).ToString() + "/5";
            sumArrayLevel += dataLevelDiamonds[i];
        }

	}

    void Start()
    {
        if (MaxDiamondsForEntry <= DataLevel.sumArrayLevel)
            Destroy(CadenaDiamadsMax);
    }
	// Update is called once per frame
	void Update () {
        
	}

    public void MoveMenuCamera(int IndexMove)
    {
        ControlMenu.AnimCamera.SetInteger("On", IndexMove);
    }
}
