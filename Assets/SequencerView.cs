using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SequencerView : MonoBehaviour
{
    public GameObject sequenceChannelView;

    public void SetupSequencerChannelView(SequenceChannel ch)
    {
        var scvgo = Instantiate(sequenceChannelView);
        scvgo.transform.SetParent(this.transform, false);
        var scv = scvgo.GetComponent<SequencerChannelView>();
        scv.SetupSequenceChannelView(ch);
    }
}
