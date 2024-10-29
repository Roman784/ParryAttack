using System.Data;
using Zenject;

public class Translator
{
    private TranslationsConfig _config;
    private Language _language = Language.Ru;

    [Inject]
    private void Construct(TranslationsConfig config)
    {
        _config = config;
    }

    public void SetaLanguage(Language language)
    {
        _language = language;
    }

    public string GetEnemyName(string key)
    {
        foreach(var data in _config.Enemies)
        {
            if (data.Key == key)
                return GetTranslation(data);
        }

        return key;
    }

    private string GetTranslation(TranslationData data)
    {
        if (_language == Language.En)
            return data.En;
        else if (_language == Language.Ru)
            return data.Ru;
        else
            return data.Tr;
    }
}
