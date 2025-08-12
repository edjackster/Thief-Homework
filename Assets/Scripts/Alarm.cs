using UnityEngine;

[RequireComponent(typeof(AudioSource), typeof(Collider))]
public class Alarm : MonoBehaviour
{
    const float MinVolume = 0;
    const float MaxVolume = 1;

    [SerializeField] private float _changeVolumeSpeed = 0.5f;

    private AudioSource _audioSource;
    private bool _isAlarmOn = false;

    private void Awake()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    private void Update()
    {
        if (_isAlarmOn)
            _audioSource.volume = Mathf.MoveTowards(_audioSource.volume, MaxVolume, _changeVolumeSpeed * Time.deltaTime);
        else
            _audioSource.volume = Mathf.MoveTowards(_audioSource.volume, MinVolume, _changeVolumeSpeed * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<Thief>(out var thief) == false)
            return;

        _isAlarmOn = true;
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.TryGetComponent<Thief>(out var thief) == false)
            return;

        _isAlarmOn = false;
    }
}
