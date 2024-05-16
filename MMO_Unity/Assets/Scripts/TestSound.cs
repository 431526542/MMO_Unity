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

    private void OnTriggerEnter(Collider other)
    {
        //AudioSource audio = GetComponent<AudioSource>();
        //audio.PlayOneShot(audioclip);
        //audio.PlayOneShot(audioclip2);

        Managers.Sound.Play(Define.Sound.Effect, "UnityChan/univ0001");
    }
}
