using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class SfxManager : MonoBehaviour
{
    
    public AudioSource Audio;

    public AudioClip Death;
    
    public AudioClip Jump;

    public static SfxManager SfxInstance;

    public bool alreadyPlayed = false;

    private void awake() {

        if (SfxInstance != null && SfxInstance != this )
        {
            Destroy(this.gameObject);
            return;
        }

        SfxInstance = this.gameObject.GetComponent<SfxManager>();
        DontDestroyOnLoad(this.gameObject);
    }
    public void playSwimSound()
    {
        Audio.PlayOneShot(Jump);
    }
    public void playDeathSound()
    {
        if (!alreadyPlayed)
        {
            Audio.PlayOneShot(Death);
            alreadyPlayed = true;
        }
        
    }
}
