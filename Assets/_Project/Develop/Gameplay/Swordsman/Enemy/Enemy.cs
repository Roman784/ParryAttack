using UnityEngine;
using Zenject;

public class Enemy : Swordsman
{
    private PlayerInput _playerInput;

    /*[Inject]
    private void Construct(Input playerInput)
    {
        _playerInput = playerInput;
    }*/

    private new void Awake()
    {
        base.Awake();

        //Input = new EnemyInput();
    }

    private void Update()
    {
    }
}
