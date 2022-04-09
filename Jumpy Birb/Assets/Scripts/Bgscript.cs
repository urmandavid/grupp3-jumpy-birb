using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bgscript : MonoBehaviour
{
    public static Bgscript BgInstance;
    public AudioSource source;
    public AudioClip audioClip;

    private void Awake(){
        if(BgInstance != null && BgInstance != this){
            Destroy(this.gameObject);
            return;
        }
        BgInstance = this;
        DontDestroyOnLoad(this.gameObject);
    }

    private void Start()
    {
        source = GetComponent<AudioSource>();
        source.clip = audioClip;
        source.Play();
    }
}
