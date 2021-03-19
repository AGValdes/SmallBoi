using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MusicClass : MonoBehaviour
{
    [SerializeField]
    private AudioSource audio;
    [SerializeField]
    private GameObject obj;

    void Start()
    {
        var x = SceneManager.GetActiveScene().name;

        if(x != "Credits" || x != "Main")
        {
            DontDestroyOnLoad(transform.gameObject);
            audio = GetComponent<AudioSource>();
            obj = GetComponent<GameObject>();
        }

        if (x == "Credits")
        {
            Destroy(obj);
            Destroy(audio);
        }
    }
    public void PlayMusic()
    {
        if (audio.isPlaying)
        {
            return;
        }
    audio.loop = true;
        audio.Play();
    }

    private void Update()
    {
        var x = SceneManager.GetActiveScene().name;
        if (x == "Credits")
        {
            Destroy(obj);
            Destroy(audio);
        }
    }

    public void Stop()
    {
        audio.Stop();
    }

}
