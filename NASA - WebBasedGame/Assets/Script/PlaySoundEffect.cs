using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlaySoundEffect : MonoBehaviour { 

    public AudioSource audio;   // Create AudioSource object
    public Slider volumeSlider;     // Create Slider object

    // Play audio file method
    public void playSound() { 

        audio.Play();
    }

    // Set volume at 100% at the begining method
    void Start() {

        volumeSlider.value = 1;
    }

    // Update the volume while sliding the volume bar method
    public void changeVolume() {

        AudioListener.volume = volumeSlider.value;
    }
}
