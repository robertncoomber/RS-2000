using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class Sequencer : MonoBehaviour
{
    [SerializeField] private Metronome _metronome;
    public SequenceChannel[] channels;
    [SerializeField] private AudioMixer Mixer;
    [SerializeField] private Image image;
    [SerializeField] private SequencerView sv;
    private void Awake()
    {
        foreach (SequenceChannel sequenceChannel in channels)
        {
            sequenceChannel.Source = gameObject.AddComponent<AudioSource>();
            sequenceChannel.Source.outputAudioMixerGroup = Mixer.FindMatchingGroups("drums")[0];
            sv.SetupSequencerChannelView(sequenceChannel);
        }

        Metronome.beatEvent += BeatEvent;
    }

    private void BeatEvent(int beatInt)
    {
        foreach (SequenceChannel sequenceChannel in channels)
        {
            if (sequenceChannel.beats[beatInt])
            {
                sequenceChannel.Source.clip = sequenceChannel.clip;
                sequenceChannel.Source.Play();

            }
        }
    }

}