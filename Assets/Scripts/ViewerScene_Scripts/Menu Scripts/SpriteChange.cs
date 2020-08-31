using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteChange : MonoBehaviour
{
    public Sprite[] sprites = new Sprite[2];
    public static SpriteChange sc;
    // Start is called before the first frame update
    void Start()
    {
        sc = this;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
