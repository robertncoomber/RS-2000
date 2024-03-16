using UnityEngine;

[CreateAssetMenu(fileName = "SequenceChannel", menuName = "SriptableObjects/SequenceChannel")]
public class SequenceChannel : ScriptableObject
{
    public AudioClip clip;
    public bool[] beats = new bool[16];
    public AudioSource Source;
    public SequencerButton button;
}