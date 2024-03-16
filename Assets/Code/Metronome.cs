using System;
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using Random = UnityEngine.Random;

public class Metronome : MonoBehaviour
{
    public float bpm = 120f; // Beats per minute
    public AudioSource audioSource; // Reference to the AudioSource component
    public TextMeshProUGUI bpmText;
    public TextMeshProUGUI playText;

    private float beatInterval; // Time interval between each beat
    private float timer; // Timer to keep track of the beat interval
    private bool isRunning = true;

    public static Action<int> beatEvent;
    private int currentBeat = 0;
    private int beatsPerMeasure = 16;

    public bool PlaySound = false;

    private void OnValidate()
    {
        UpdateBeatInterval();
    }

    private void Start()
    {
        // Calculate the beat interval based on the BPM
        beatInterval = 60f / bpm / 4; // /4 = 16 beats per measure
        timer = 10000;
        UpdateText();
    }

    private void UpdateText()
    {
        if (bpmText != null)
        {
            bpmText.text = bpm.ToString();
        }

        if (playText != null)
        {
            playText.text = isRunning ? "pause" : "play";
        }
    }

    private void UpdateBeatInterval()
    {
        beatInterval = 60f / bpm / 4;
        UpdateText();
    }

    public void Increase()
    {
        bpm += 1;
        UpdateBeatInterval();
    }

    public void Decrease()
    {
        bpm -= 1;
        UpdateBeatInterval();
    }

    public void TogglePlay()
    {
        isRunning = !isRunning;
        UpdateBeatInterval();
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
        if (currentBeat == 0)
        {
            audioSource.pitch = 2.0f;
            if (PlaySound)
            {
                audioSource.Play();
                audioSource.pitch = Random.Range(0.8f, 1.2f);
                audioSource.volume = Random.Range(0.7f, 1.0f);
            }
        }
        else if (currentBeat % 4 == 0)
        {
            audioSource.pitch = 1.3f;
            if (PlaySound)
            {
                audioSource.pitch = Random.Range(0.8f, 1.2f);
                audioSource.volume = Random.Range(0.7f, 1.0f);
                audioSource.Play();
            }
        }

        // Play the audio source

        beatEvent?.Invoke(currentBeat);
        currentBeat++;
        currentBeat %= beatsPerMeasure;
    }
}