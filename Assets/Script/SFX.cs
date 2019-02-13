using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SFX : MonoBehaviour{

    static SFX instance;
    AudioSource audioSource;
    public AudioClip eat, fix, helicopter, explosion;
    void Start(){
        instance = this;
        audioSource = GetComponent<AudioSource>();
        audioSource.loop = false;
    }
    public void Play(AudioClip clip){
        audioSource.Stop();
        audioSource.clip = clip;
        audioSource.Play();
    }
    public static void PlayEat(){
        instance.Play(instance.eat);
    }    
    public static void PlayFix(){
        instance.Play(instance.fix);
    }    
    public static void PlayHelicopter(){
        instance.Play(instance.helicopter);
    }    
    public static void PlayExplosion(){
        instance.Play(instance.explosion);
    }
}