using UnityEngine;
using System.Collections;

public class SoundMenu : MonoBehaviour {
    public GameObject onSound;
    public GameObject offSound;
    public AudioSource source;
	// Use this for initialization
	void Start () {
        if (ControlSounds.IsSound())
            OnSound();
        else
            OffSound();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void OnSound()
    {
        onSound.SetActive(true);
        offSound.SetActive(false);
        ControlSounds.OnSound();
        source.Play();
    }

    public void OffSound()
    {
        onSound.SetActive(false);
        offSound.SetActive(true);
        ControlSounds.OffSound();

    }
}
