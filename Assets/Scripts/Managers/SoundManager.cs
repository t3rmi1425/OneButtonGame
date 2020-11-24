using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public AudioSource coinEffect;

    // Start is called before the first frame update
    void Start()
    {
        coinEffect.GetComponent<AudioSource>();
    }
}
