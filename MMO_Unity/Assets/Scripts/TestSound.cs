using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestSound : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public AudioClip audioclip;
    public AudioClip audioclip2;

    int i = 0;

    private void OnTriggerEnter(Collider other)
    {
        //AudioSource audio = GetComponent<AudioSource>();]
        //audio.PlayClipAtPoint();
        //audio.PlayOneShot(audioclip);
        //audio.PlayOneShot(audioclip2);
        i++;
        if(i % 2 == 0)
        {
            Managers.Sound.Play(audioclip, Define.Sound.Bgm);
        }
        else
        {
            Managers.Sound.Play("UnityChan/univ0002", Define.Sound.Bgm);
        }
    }
}
