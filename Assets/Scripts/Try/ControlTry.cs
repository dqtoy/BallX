using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ControlTry : MonoBehaviour {
    public GameObject gDiamond;

    public Text Score;
    public Text Diamond;
    public float WaitAndGoToMenu;
    private int iScore = 0;
    private int iDiamond = 0;
    
	// Use this for initialization
	void Start () {
        StartCoroutine(waitAndGo());
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.name == SaveData.GetNameHalfBall())
        {
            iScore++;
            Score.text = iScore.ToString();
        }
    }

    void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.transform.gameObject.layer == LayerMask.NameToLayer("Diamond"))
        {

            iDiamond++;
            Diamond.text = iDiamond.ToString();
            Destroy(gDiamond);
        }
    }

    IEnumerator waitAndGo()
    {
        yield return new WaitForSeconds(WaitAndGoToMenu);
        Application.LoadLevel("Stages 0 1");
    }
}
