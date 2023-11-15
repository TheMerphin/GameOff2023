using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VolumeSlider : MonoBehaviour
{
    private Slider volumeSlider;
    private AudioManager audioManager;
    // Start is called before the first frame update
    void Start()
    {
        audioManager = FindFirstObjectByType<AudioManager>();
        volumeSlider = gameObject.GetComponent<Slider>();
        

        // Setze den aktuellen Wert des Sliders auf die aktuelle Lautst�rke des AudioManager
        volumeSlider.value = audioManager.mixerGroup.audioMixer.GetFloat("Volume", out float volume) ? volume : 0f;

        // F�ge den OnValueChanged-Listener hinzu, um die Lautst�rke zu aktualisieren, wenn sich der Slider �ndert
        volumeSlider.onValueChanged.AddListener(ChangeVolume);
    
    }
    

    // Methode, um die Lautst�rke zu �ndern, wenn sich der Slider-Wert �ndert
    void ChangeVolume(float volume)
    {
        // Aktualisiere die Lautst�rke im AudioManager
        audioManager.mixerGroup.audioMixer.SetFloat("Volume", volume);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
