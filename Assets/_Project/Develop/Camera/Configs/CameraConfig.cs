using UnityEngine;

[CreateAssetMenu(fileName = "CameraConfig", menuName = "Configs/Camera")]
public class CameraConfig : ScriptableObject
{
    [field: Header("Movement")]
    [field: SerializeField] public float MoveSpeed { get; private set; }
    [field: SerializeField] public Vector3 Offset { get; private set; }

    [field: Header("Shaking")]
    [field: SerializeField] public float ShakeDuration { get; private set; }
    [field: SerializeField] public AnimationCurve ShakeOverTime { get; private set; }
}
