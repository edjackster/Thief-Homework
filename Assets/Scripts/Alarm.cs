using System.Collections;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class Alarm : MonoBehaviour
{
    private const float MinVolume = 0;
    private const float MaxVolume = 1;
    private const float MinTimeStep = 0.1f;

    [SerializeField] private float _changeVolumeDuration = 2f;

    private AudioSource _audioSource;
    private float _step;
    private Coroutine _coroutine;

    private void Awake()
    {
        _audioSource = GetComponent<AudioSource>();
        _step = MinTimeStep / _changeVolumeDuration;
        Debug.Log(_step);
    }

    public void TurnOn()
    {
        Debug.Log("Turned On");
        
        if (_coroutine != null)
            StopCoroutine(_coroutine);
        
        _coroutine = StartCoroutine(TurnUpVolume());
    }

    public void TurnOff()
    {
        Debug.Log("Turned Off");
        
        if (_coroutine != null)
            StopCoroutine(_coroutine);
        
        _coroutine = StartCoroutine(TurnDownVolume());
    }

    private IEnumerator TurnUpVolume()
    {
        var wait = new WaitForSeconds(MinTimeStep);
        
        while (_audioSource.volume < MaxVolume)
        {
            Debug.Log(_audioSource.volume);
            _audioSource.volume = Mathf.MoveTowards(_audioSource.volume, MaxVolume, _step);
            yield return wait; 
        }
    }

    private IEnumerator TurnDownVolume()
    {
        var wait = new WaitForSeconds(MinTimeStep);
        
        while (_audioSource.volume > MinVolume)
        {
            Debug.Log(_audioSource.volume);
            _audioSource.volume = Mathf.MoveTowards(_audioSource.volume, MinVolume, _step);
            yield return wait; 
        }
    }

    //private IEnumerator VolumeUp()
    //{
    //    while (_isAlarmOn && _audioSource.volume < MaxVolume)
    //    {
    //        _audioSource.volume = Mathf.MoveTowards(_audioSource.volume, MaxVolume, _changeVolumeSpeed * Time.deltaTime);
    //    }
    //}
}
