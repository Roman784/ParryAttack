using UnityEngine;

public class SwordsmanSound : MonoBehaviour
{
    [SerializeField] private AudioClip _damageSound;
    [SerializeField] private AudioClip _parrySound;
    [SerializeField] private AudioClip _attackSound;

    private AudioPlayer _audioPlayer;

    public void Init(AudioPlayer audioPlayer)
    {
        _audioPlayer = audioPlayer;
    }

    public void PlayDamageSound()
    {
        _audioPlayer.Play(_damageSound);
    }

    public void PlayParrySound()
    {
        _audioPlayer.Play(_parrySound);
    }

    public void PlayAttackSound()
    {
        _audioPlayer.Play(_attackSound);
    }
}
