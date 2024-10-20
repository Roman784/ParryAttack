using UnityEngine;

[CreateAssetMenu(fileName = "UISoundsConfig", menuName = "Configs/Audio/UISounds")]
public class UISoundsConfig : ScriptableObject
{
    [field: SerializeField] public AudioClip _buttonClick;
}
