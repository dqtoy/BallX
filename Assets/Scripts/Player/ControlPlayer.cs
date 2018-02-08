using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ControlPlayer : MonoBehaviour {

    public Text BestScore;
    public bool SceneLimited = true;
    public GameObject UIWin;
    public GameObject UIReplay;
    public float TimePlayInThisStage = 120;
	public bool isRandom = false;
	public GameObject[] gameObjectsBarriers;
    public float WaitForDisplayBarrier = 5;
    public GameObject effectWin;
    public string menuSceneMenu = "Menu";

    private GameObject laterObject;
	private int Index = 0;

    public static Text sBestScore;
    public static bool sSceneLimited;
    public static GameObject EffectWin;
    public static float Scale = 1;
    public static GameObject ball;
    public static bool IsSounded = true;
    public static GameObject SUIWin;
    public static GameObject SUIReplay;
    
	// Use this for initialization
    void Awake()
    {

        sBestScore = BestScore;
        sSceneLimited = SceneLimited;
        EffectWin = effectWin;
        ControlPlayer.Scale = 1;
        ball = GetComponentInChildren<ControllBall>().gameObject;
        SUIWin = UIWin;
        SUIReplay = UIReplay;
        IsSounded = SaveData.IsSoundy();
		Index = 0;
		StartCoroutine(WaitAndDo(WaitForDisplayBarrier));
	}

	IEnumerator WaitAndDo(float Wait){
        if (Index < gameObjectsBarriers.Length)
        {
            yield return new WaitForSeconds(Wait);
                if (isRandom)
                    Index = (int)Random.Range(0, gameObjectsBarriers.Length - 0.001f);

                Instantiate(gameObjectsBarriers[Index].transform);
            if (sSceneLimited)
                Index++;

            StartCoroutine(WaitAndDo(WaitForDisplayBarrier));
        }
	}

	// Update is called once per frame
	void Update () {
        if (Input.GetKey(KeyCode.Escape))
        {
            Application.LoadLevel(menuSceneMenu);
        }
	}

	public static IEnumerator  waitAndtimeScaleIs (float wa,int Nb){
		yield return new WaitForSeconds (wa);
		Time.timeScale = Nb;
	}

    public static void YouWin()
    {
        if (100 <= ControllBall.NbPercentage)
        {
            ControlPlayer.Scale = 0;
            SaveData.SetBestPercentage(100);
            int diamonds = Diamond.NbOfDiamonds;

            if (diamonds > SaveData.GetBestNbDiamonds())
            {
                SaveData.SetBestNbDiamonds(diamonds);
            }
            ControlPlayer.EffectWin.SetActive(true);
            ControlSounds.StopMusic();
            SUIWin.SetActive(true);
            ControlPlayer.ball.SetActive(false);
            AdManager.ShowVideo();
        }
    }

    public static void StageFiniched()
    {
        if (sSceneLimited)
        {
            float nb = ControllBall.NbPercentage;
            if (nb < 100)
            {
                if (nb > SaveData.GetBestPercentage())
                {
                    SaveData.SetBestPercentage(nb);
                }
            }
        }
        else
        {
            int nbCurrent = ControllBall.NbOfJupm;
            int nbBest = SaveData.GetBestNbOfJupm();
            if (nbBest < nbCurrent)
            {
                SaveData.SetBestNbOfJupm(nbCurrent);
            }
            sBestScore.text = SaveData.GetBestNbOfJupm().ToString();
        }
        // Sounds
        ControlSounds.PlaySoundLoss();
        ControlSounds.StopMusic();

        ControllBall.Effects.SetActive(true);
        ControllBall.Effects.transform.parent = ControlPlayer.ball.transform.parent;
        ControlPlayer.SUIReplay.SetActive(true);

        ControlPlayer.ball.SetActive(false);
        ControlPlayer.Scale = 0;
        AdManager.ShowVideo();
    }

    public static void AcceleraionScale(float FactorSpeed)
    {
        ControlPlayer.Scale += FactorSpeed;
    } 
}
