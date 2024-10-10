public class PlayerConfigBuilder : SwordsmanConfigBuilder
{
    private readonly PlayerConfig _initial;
    private readonly PlayerProgressionConfig _progression;

    public PlayerConfigBuilder(PlayerConfig initial, PlayerProgressionConfig progressionConfig, float levelProgress) : 
        base(initial.SwordsmanConfig, progressionConfig.SwordsmanProgressionConfig, levelProgress)
    {
        _initial = initial;
        _progression = progressionConfig;
    }

    private SwordsmanSpritesConfig Sprites => _initial.SwordsmanConfig.SpritesConfig;

    public PlayerConfig Build()
    {
        var swordsman = BuildSwordsman();

        var player = new PlayerConfig(swordsman);
        return player;
    }

    protected override SwordsmanSpritesConfig BuildSprites()
    {
        var idle = Sprites.Idle;
        var preattack = Sprites.Preattack;
        var attack = Sprites.Attack;
        var parry = Sprites.Parry;
        var defeat = Sprites.Defeat;
        var profile = Sprites.Profile;

        var sprites = new SwordsmanSpritesConfig(idle, preattack, attack, parry, defeat, profile);
        return sprites;
    }
}
