using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class backgroundScrolling : MonoBehaviour
{

    //Speed aplied to all backgrounds
    public float baseScrollSpeed;

    //The Background Objects
    public GameObject[] backgrounds;

    public float[] scrollSpeed;

    void FixedUpdate()
    {
        for (int i = 0; i < backgrounds.Length; i++)
        {
            Renderer rend = backgrounds[i].GetComponent<Renderer>();
            float offset = Time.time * (scrollSpeed[i] + baseScrollSpeed);

            rend.material.SetTextureOffset("_MainTex", new Vector2(offset, 0));
        }
    }
}
