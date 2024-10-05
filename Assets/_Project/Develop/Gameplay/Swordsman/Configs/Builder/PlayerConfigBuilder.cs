public class PlayerConfigBuilder : SwordsmanConfigBuilder
{
    public PlayerConfigBuilder(InitialSwordsmenConfig initialConfig) : base(initialConfig)
    {
    }

    public PlayerConfig Build()
    {
        SwordsmanConfig swordsmanConfig = BuildSwordsman();
        PlayerConfig playerConfig = new(swordsmanConfig);

        return playerConfig;
    }
}
