using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class SfxManager : MonoBehaviour
{
    
    public AudioSource Audio;
    
    public AudioClip Click;

    public static SfxManager SfxInstance;

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
        Audio.PlayOneShot(Click);
    }
}
