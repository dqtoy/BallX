using UnityEngine;
using System.Collections;

public class ControlMenu : MonoBehaviour {
    public int MaxIncrAnim = 3;

    private Vector2 vPhaceInit;
    private Animator anim;
    private int IndexAnim;

    public static Animator AnimCamera;
	// Use this for initialization
    void Start()
    {
        AnimCamera = anim = GetComponent<Animator>();
        IndexAnim = 0;
        anim.SetInteger("On", SaveData.GetIndexLevel());
	}

	// Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Escape))
        {
            anim.SetInteger("On", 0);
        }

        /*
#if UNITY_EDITOR
        if (Input.GetMouseButtonDown(0))
        {
            vPhaceInit = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        }

        if (Input.GetMouseButtonUp(0))
        {
            Vector2 pNew = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            float m = pNew.x - vPhaceInit.x;
            if (m > 0.2f && IndexAnim < MaxIncrAnim)
            {
                anim.SetInteger("On", anim.GetInteger("On") - 1);
                IndexAnim--;
            }
            else
                if (m < -0.2f && IndexAnim > 0)
                {
                    anim.SetInteger("On", IndexAnim + 1);
                    IndexAnim++;
                }
        }

#elif UNITY_ANDROID
        foreach (Touch touch in Input.touches)
        {
            if (touch.phase == TouchPhase.Began)
            {
                vPhaceInit = Camera.main.ScreenToWorldPoint(touch.position);
            }

            if (touch.phase == TouchPhase.Ended)
            {
            Vector2 pNew = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            float m = pNew.x - vPhaceInit.x;
            if (m > 0.2f && IndexAnim < MaxIncrAnim)
            {
                anim.SetInteger("On", IndexAnim + 1);
                IndexAnim++;
            }
            else
                if (m < -0.2f && IndexAnim > 0)
                {
                    anim.SetInteger("On", anim.GetInteger("On") - 1);
                    IndexAnim--;
                }
            }

        }
#endif
        */
    }
    public void ToStagesOne()
    {
        IndexAnim = 1;
        anim.SetInteger("On", 1);
    }

    public void Exet()
    {
        print("Exit");
        Application.Quit();
    }
}
