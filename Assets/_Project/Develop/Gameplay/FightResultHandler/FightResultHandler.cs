using System.Collections;
using UnityEngine;

public class FightResultHandler
{
    private Player _player;
    private Enemy _enemy;
    private SceneLoader _sceneLoader;

    public FightResultHandler(Player player, Enemy enemy, SceneLoader sceneLoader)
    {
        _player = player;
        _enemy = enemy;
        _sceneLoader = sceneLoader;

        _player.OnDefeated.AddListener(HandlePlayerDefeat);
        _enemy.OnDefeated.AddListener(HandleEnemyDefeat);
    }

    private void HandlePlayerDefeat()
    {
        ForbidFight();
        Coroutines.StartRoutine(RestartLevel());
    }

    private void HandleEnemyDefeat()
    {
        ForbidFight();
    }

    private void ForbidFight()
    {
        _player.ForbidFight();
        _enemy.ForbidFight();
    }

    private IEnumerator RestartLevel()
    {
        yield return new WaitForSeconds(2f);

        _sceneLoader.LoadGameplay();
    }
}
