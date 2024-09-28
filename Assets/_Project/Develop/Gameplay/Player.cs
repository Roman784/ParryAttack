using System.Collections;
using UnityEngine;
using Zenject;

public class Player : MonoBehaviour
{
    private bool _isAttacking;

    private IInput _input;

    [Inject]
    private void Construct(IInput input)
    {
        _input = input;
    }

    private void Update()
    {
        if (_input.IsParrying())
        {
            Parry();
        }
        else if (_input.IsAttacking() && !_isAttacking)
        {
            Coroutines.StartRoutine(Attack());
        }
    }

    private IEnumerator Attack()
    {
        _isAttacking = true;
        Debug.Log("Attack");

        yield return new WaitForSeconds(1f);

        _isAttacking = false;
    }

    private void Parry()
    {
        Debug.Log("Parry");
    }
}
