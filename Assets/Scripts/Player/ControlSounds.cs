using UnityEngine;
using System.Collections;

public class ControlSounds : MonoBehaviour {
    public AudioSource soundsBallJump;
    private static AudioSource SoundsBallJump;

    public AudioSource soundsLoss;
    private static AudioSource SoundsLoss;

    public AudioSource soundsEat;
    private static AudioSource SoundsEat;

    public AudioSource[] soundsMusic;
    private static string nameDataSound = "DataSound";
    private static AudioSource[] SoundsMusic;
    private static int Index;
	// Use this for initialization
	void Start () {
        if (PlayerPrefs.GetInt(nameDataSound) == 0) PlayerPrefs.SetInt(nameDataSound,1);

        if (PlayerPrefs.GetInt(nameDataSound) != -1)
        {
            SoundsBallJump = soundsBallJump;
            SoundsLoss = soundsLoss;
            SoundsMusic = soundsMusic;
            SoundsEat = soundsEat;
            Index = (int)Random.Range(0, SoundsMusic.Length - 0.001f);
            PlayMusic();
        }
	}
	
	// Update is called once per frame
	void Update () {
	    
	}
    public static bool IsSound (){
        if (PlayerPrefs.GetInt(nameDataSound) == -1) return false;
        else return true;
    }
    public static void OnSound (){
        PlayerPrefs.SetInt(nameDataSound, 1);
    }

    public static void OffSound()
    {
        PlayerPrefs.SetInt(nameDataSound, -1);
    }
    public static void PlaySoundJump(){
        if (PlayerPrefs.GetInt(nameDataSound) != -1)
        {
            SoundsBallJump.Play();
        }
    }

    public static void PlaySoundLoss()
    {
        if (PlayerPrefs.GetInt(nameDataSound) != -1)
            SoundsLoss.Play();
    }
    public static void StopSoundLoss()
    {
        if (PlayerPrefs.GetInt(nameDataSound) != -1)
            SoundsLoss.Stop();
    }

    public static void PlayMusic()
    {
        if (PlayerPrefs.GetInt(nameDataSound) != -1)
            SoundsMusic[Index].Play();
    }
    public static void StopMusic()
    {
        if (PlayerPrefs.GetInt(nameDataSound) != -1)
            SoundsMusic[Index].Stop();
    }

    public static void PlaySoundsEat()
    {
        if (PlayerPrefs.GetInt(nameDataSound) != -1)
            SoundsEat.Play();
    }

}
