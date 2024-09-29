using System.Collections;
using UnityEngine;

public class EnemyInput
{
    private bool? _isAttacking;
    private bool? _isParrying;

    private Coroutine _pressCoroutine;

    public EnemyInput()
    {
        _isAttacking = false;
        _isParrying = false;
    }

    public bool IsAttacking() => (bool)_isAttacking;

    public bool IsParrying() => (bool)_isParrying;

    public void PressAttack(float duration)
    {
        if (_pressCoroutine != null)
            Coroutines.StopRoutine(_pressCoroutine);

        _pressCoroutine = Coroutines.StartRoutine(Press(_isAttacking, duration));
    }

    public void PressParry(float duration)
    {
        if (_pressCoroutine != null)
            Coroutines.StopRoutine(_pressCoroutine);

        _pressCoroutine = Coroutines.StartRoutine(Press(_isAttacking, duration));
    }

    /*public override void Tick()
    {
        throw new System.NotImplementedException();
    }*/

    private IEnumerator Press(bool? input, float duration)
    {
        input = true;

        yield return new WaitForSeconds(duration);

        input = false;
    }
}
