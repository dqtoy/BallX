using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ControllBall : MonoBehaviour {

    public Text [] TextPercentage;
    public Text [] diamond;
    public int MaxNbDiamonds = 5;
    public float IncPercentage = 1f;
    public float FactorSpeed = 0.001f;
    public bool AccelerationJump = false;
    public float speedY = 1000f;
    public float speedX = 100f;
    public GameObject effects;

    private Rigidbody2D rigid;
	private Image imageID0;

    public static float NbPercentage = 0;
    public static int NbOfJupm = 0;
    public static GameObject Effects;

	// Use this for initialization
	void Start () {
        NbOfJupm = 0;
        Diamond.NbOfDiamonds = 0;
        NbPercentage = 0;
        Effects = effects;
        AdManager.ShowBanner();
		rigid = GetComponent <Rigidbody2D> ();
	}
	
	// Update is called once per frame
	void Update () {
	}

	void OnCollisionEnter2D(Collision2D coll) {
        if (coll.gameObject.name == SaveData.GetNameHalfBall())
        {
            ControlSounds.PlaySoundJump();
            float difference = transform.position.x - coll.gameObject.transform.position.x;
            if (AccelerationJump)
                rigid.velocity = new Vector2(difference * ControlPlayer.Scale * speedX * Time.deltaTime, speedY * ControlPlayer.Scale * Time.deltaTime);
            else
                rigid.velocity = new Vector2(difference * ControlPlayer.Scale * speedX * Time.deltaTime, speedY * Time.deltaTime);

            if (ControlPlayer.sSceneLimited)
            {
                if (ControllBall.NbPercentage <= 100)
                {
                    NbPercentage += IncPercentage;
                    if (NbPercentage > 100) NbPercentage = 100;
                    for (int i = 0; i < TextPercentage.Length; i++)
                        TextPercentage[i].text = ((int)NbPercentage).ToString() + "%";
                }
                ControlPlayer.YouWin();
            }
            else
            {
                NbOfJupm++;
                ControlPlayer.AcceleraionScale(FactorSpeed);
                for (int i = 0; i < TextPercentage.Length; i++)
                    TextPercentage[i].text = NbOfJupm.ToString();
            }
        }
	}

    void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.transform.gameObject.layer == LayerMask.NameToLayer("Diamond"))
        {
            for (int i = 0; i < diamond.Length; i++)
                diamond[i].text = Diamond.NbOfDiamonds.ToString() + "/" + MaxNbDiamonds;
        }
    }
}
