using System.Collections;
using UnityEngine;

// It's a class, not an interface, in order to be found in the scene.
public abstract class EntryPoint : MonoBehaviour
{
    public abstract IEnumerator Run();
}
