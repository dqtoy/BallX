using UnityEngine;
using System.Collections;

public class SaveData : MonoBehaviour {


    public string IndexStage = "1|1";

    public static string NbOfJupmSave;
    private static string nameDiamonds;
	private static string namePercentage;
	private static string nameBall = "ball";
	private static string nameHalfBall = "Half Ball";
    private static string nameSound = "Sound";
    private static string nameIndexLevel = "Index Level";

	// Use this for initialization
	void Start () {
        //SetBestNbOfJupm(0);
        NbOfJupmSave = "Jumps";
        nameDiamonds = "Diamonds";
        namePercentage = "Percentage";
        NbOfJupmSave += IndexStage;
        nameDiamonds += IndexStage;
        namePercentage += IndexStage;
	}
	
	// Update is called once per frame
	void Update () {

	}

    public static bool IsSoundy() {
        if (PlayerPrefs.GetInt(nameSound) == 1)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

   public static void SetOnSound() {
        PlayerPrefs.SetInt(nameSound,1);
    }

   public static void SetOffSound()
   {
       PlayerPrefs.SetInt(nameSound, -1);
   }

	public static string GetNameBall (){
		string Rus = nameBall;
		return Rus;
	}
	 
	public static string GetNameHalfBall (){
		string Rus = nameHalfBall;
		return Rus;
	}

	public static void SetNbKey (int keys){
        PlayerPrefs.SetInt(nameDiamonds, keys);
	}

	public static int GetNbKey (){
        return PlayerPrefs.GetInt(nameDiamonds);
	}

    public static void SetBestPercentage(float score)
    {
        PlayerPrefs.SetFloat(namePercentage, score);
	}

    public static float GetBestPercentage()
    {
        return PlayerPrefs.GetFloat(namePercentage);
    }

    public static void SetBestNbDiamonds(float score)
    {
        PlayerPrefs.SetFloat(nameDiamonds, score);
    }

    public static float GetBestNbDiamonds()
    {
        return PlayerPrefs.GetFloat(nameDiamonds);
    }

    public static void SetBestNbOfJupm(int score)
    {
        PlayerPrefs.SetInt(NbOfJupmSave, score);
    }

    public static int GetBestNbOfJupm()
    {
        return PlayerPrefs.GetInt(NbOfJupmSave);
    }

    public static void SetIndexLevel(int Index)
    {
        PlayerPrefs.SetInt(nameIndexLevel, Index);
    }

    public static int GetIndexLevel()
    {
        return PlayerPrefs.GetInt(nameIndexLevel);
    }
}
