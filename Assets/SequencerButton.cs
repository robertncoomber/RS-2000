using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SequencerButton : MonoBehaviour
{
    [SerializeField] public Image Image;
    [SerializeField] private SequenceChannel _channel;
    [SerializeField] private int beatIndex;

    private void Awake()
    {
        Metronome.beatEvent += BeatEvent;
    }

    private void BeatEvent(int obj)
    {
        if (beatIndex == obj)
        {
        }
        else
        {
        }

        StartCoroutine(BeatEventRoutine(obj));
    }

    IEnumerator BeatEventRoutine(int index)
    {
        if (index == beatIndex)
        {
            var tmpCol = Image.color;
            Image.color = Color.yellow;
            yield return new WaitForSeconds(0.1f);
            Image.color = tmpCol;
        }
    }

    public void Setup(SequenceChannel _channel, int index)
    {
        beatIndex = index;
        this._channel = _channel;
        this._channel.button = this;

        if (this._channel.beats[index])
        {
            Image.color = Color.blue;
        }
        else
        {
            Image.color = Color.white;
        }
    }

    public void OnClick()
    {
        _channel.beats[beatIndex] = !_channel.beats[beatIndex];

        if (this._channel.beats[beatIndex])
        {
            Image.color = Color.blue;
        }
        else
        {
            Image.color = Color.white;
        }
    }
}