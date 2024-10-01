using UnityEngine;
using Zenject;

public class SwordsmenInstaller : MonoInstaller
{
    [SerializeField] private Player _playerPrefab;
    [SerializeField] private Enemy _enemyPrefab;

    public override void InstallBindings()
    {
        BindSwordsmen();
    }

    private void BindSwordsmen()
    {
        Container.Bind<Player>().FromComponentInNewPrefab(_playerPrefab).AsSingle();
        Container.Bind<Enemy>().FromComponentInNewPrefab(_enemyPrefab).AsSingle();
    }
}
