using UnityEngine;

public abstract class HealthView : MonoBehaviour
{
    public abstract void CreateBar(int amount);
    public abstract void UpdateBar(int amount);
}
