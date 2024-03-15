using TMPro;
using UnityEngine;
using UnityEngine.Serialization;

public class Metronome : MonoBehaviour
{
    public float bpm = 120f; // Beats per minute
    public AudioSource audioSource; // Reference to the AudioSource component
    public TextMeshProUGUI bpmText;
    public TextMeshProUGUI playText;
    
    private float beatInterval; // Time interval between each beat
    private float timer; // Timer to keep track of the beat interval
    private bool isRunning = true;
    
    private void Start()
    {
        // Calculate the beat interval based on the BPM
        beatInterval = 60f / bpm;
        timer = 0f;
        bpmText.text = bpm.ToString();
        playText.text = isRunning ? "pause" : "play";
    }

    public void Increase()
    {
        bpm += 1;
        beatInterval = 60f / bpm;
        bpmText.text = bpm.ToString();
    }

    public void Decrease()
    {
        bpm -= 1;
        beatInterval = 60f / bpm;
        bpmText.text = bpm.ToString();
    }

    public void TogglePlay()
    {
        isRunning = !isRunning;
        playText.text = isRunning ? "pause" : "play";
    }

    private void Update()
    {
        if (!isRunning)
        {
            return;
            timer = 0f;
        }
        
        // Update the timer
        timer += Time.deltaTime;

        // Check if the timer exceeds the beat interval
        if (timer >= beatInterval)
        {
            // Reset the timer
            timer = 0f;

            // Play the audio
            PlayBeat();
        }
    }

    private void PlayBeat()
    {
        // Play the audio source
        audioSource.Play();
    }
}

