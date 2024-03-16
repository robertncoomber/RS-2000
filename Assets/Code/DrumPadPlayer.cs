using System;
using System.Collections;
using System.Collections.Generic;
using Oculus.Interaction;
using UnityEngine;

public class DrumPadPlayer : MonoBehaviour
{
    [SerializeField] private AudioClip clip;
    private AudioSource source;
    [SerializeField] private InteractableUnityEventWrapper _interactableUnityEventWrapper;
    private PokeInteractable _pokeInteractable;

    private void Awake()
    {
        _pokeInteractable = gameObject.GetComponentInParent<PokeInteractable>();
        
        source = gameObject.AddComponent<AudioSource>();
        source.clip = clip;
        source.playOnAwake = false;
    }

    private void Start()
    {
        _interactableUnityEventWrapper.WhenSelect.AddListener(PlayAudioSource);
    }

    public void PlayAudioSource()
    {
        source.Play();
    }
}
