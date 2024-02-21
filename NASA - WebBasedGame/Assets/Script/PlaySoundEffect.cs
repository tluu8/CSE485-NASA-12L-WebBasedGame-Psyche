using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaySoundEffect : MonoBehaviour { 

    public AudioSource audio;   // Create AudioSource object

    // Play audio file method
    public void playSound() { 

        audio.Play();
    }
}
