using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverManager : MonoBehaviour
{
    public AudioSource audiosource;
    public AudioClip gameoverBGM;
    // Start is called before the first frame update
    void Start()
    {
        audiosource.PlayOneShot(gameoverBGM);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
