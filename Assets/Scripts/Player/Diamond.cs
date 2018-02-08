using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Diamond : MonoBehaviour {
    public GameObject Effects;
    public float TimeDestroyEffects = 0.5f;

    public static int NbOfDiamonds;
	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
	}
    void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.gameObject == GameObject.Find(SaveData.GetNameBall()))
        {
            ControlSounds.PlaySoundsEat();
            NbOfDiamonds++;
            Effects.SetActive(true);
            SpriteRenderer sr = GetComponent<SpriteRenderer>();
            PolygonCollider2D poly = GetComponent<PolygonCollider2D>();
            poly.enabled = false;
            sr.enabled = false;
            StartCoroutine(WaitAndDestroy(gameObject));
        }
    }

    IEnumerator WaitAndDestroy (GameObject des){
        yield return new WaitForSeconds(TimeDestroyEffects);
        Destroy(des);
    }
}
