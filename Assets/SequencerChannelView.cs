using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SequencerChannelView : MonoBehaviour
{
    public GameObject sequenceButton;

    public void SetupSequenceChannelView(SequenceChannel ch)
    {
        int amt = ch.beats.Length;

        for (int i = 0; i < amt; i++)
        {
            var sb = Instantiate(sequenceButton);
            sb.transform.SetParent(this.transform, false);

            SequencerButton seqB = sb.GetComponent<SequencerButton>();
            seqB.Setup(ch, i);
        }
    }
}
