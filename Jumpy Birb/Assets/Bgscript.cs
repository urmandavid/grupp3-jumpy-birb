using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bgscript : MonoBehaviour
{
    public static Bgscript BgInstance;

    private void Awake(){
        if(BgInstance != null && BgInstance != this){
            Destroy(this.gameObject);
            return;
        }
        BgInstance = this;
        DontDestroyOnLoad(this.gameObject);
    }
}
