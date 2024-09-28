using System.Collections;
using UnityEngine;
using Zenject;

public abstract class EntryPoint : MonoBehaviour
{
    protected UIRoot UIRoot;

    [Inject]
    private void Construct(UIRoot uIRoot)
    {
        UIRoot = uIRoot;
    }

    public abstract IEnumerator Run();
}
