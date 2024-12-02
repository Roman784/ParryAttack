using UnityEngine;

[CreateAssetMenu(fileName = "AudioConfig", menuName = "Configs/Audio")]
public class AudioConfig : ScriptableObject
{
    [field: Header("UI")]
    [field: SerializeField] public AudioClip ButtonClickSound {  get; private set; }

    [field: Header("Background")]
    [field: SerializeField] public AudioClip[] BackgroundMusic { get; private set; }

    [field: Header("Fight result")]
    [field: SerializeField] public AudioClip VictorySound { get; private set; }
    [field: SerializeField] public AudioClip LosingSound { get; private set; }
}
