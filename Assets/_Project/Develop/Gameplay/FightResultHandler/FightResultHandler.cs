public class FightResultHandler
{
    public FightResultHandler(Player player, Enemy enemy)
    {
        player.OnDefeated.AddListener(HandleEnemyDefeat);
        enemy.OnDefeated.AddListener(HandleEnemyDefeat);
    }

    private void HandlePlayerDefeat()
    {

    }

    private void HandleEnemyDefeat()
    {

    }
}
