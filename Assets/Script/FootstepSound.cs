using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FootstepSound : MonoBehaviour{
    AudioSource audio;
    public AudioSource ambient;
    public AudioClip snow, wood, metal;
    bool wasInHouse;
    bool isInHouse{
        get { return PlayerStats.isInHouse; }
    }
    
    void Start(){
        audio = GetComponent<AudioSource>();
        audio.loop = true;

        wasInHouse = !isInHouse;
        CheckChange();
    }
    void Update(){
        CheckChange();
        if (PlayerStats.isWalking && PlayerStats.isOnGround){
            audio.UnPause();
        }
        else{
            audio.Pause();
        }

        if (isInHouse){
            ambient.volume = 1f/3;
        }
        else{
            ambient.volume = 1;
        }
    }
    bool CheckChange(){
        if (wasInHouse ^ isInHouse) {
            if (isInHouse){
                ChangeClip(wood);
            }
            else {
                ChangeClip(snow);
            }
            wasInHouse = isInHouse;
            return true;
        }
        else {
            return false;
        }
    }
    void ChangeClip(AudioClip clip){
        audio.Stop();
        audio.clip = clip;
        audio.Play();
    }
}