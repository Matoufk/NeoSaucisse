using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AudioManager : MonoBehaviour
{

    private static AudioManager instance = null;

    public static AudioManager Instance
    {
        get { return instance; }
    }

    private AudioSource aud;
    public AudioClip music;
    public AudioClip music2;

    void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(this.gameObject);
            return;
        }
        else
        {
            instance = this;
        }
        DontDestroyOnLoad(this.gameObject);
        aud = GetComponent<AudioSource>();
    }


    // Start is called before the first frame update
    void Start()
    {
        PlayMusic();
    }

    // Update is called once per frame
    void Update()
    {
        if(aud.isPlaying == false)
        {
            PlayMusic2();
        }
    }

    public void PlayMusic()
    {
        aud.Stop();
        aud.clip = music;
        aud.Play();
    }

    public void PlayMusic2()
    {
        aud.Stop();
        aud.clip = music2;
        aud.Play();
    }
}
