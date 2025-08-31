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
    }

    public void TurnOn()
    {
        if (_coroutine != null)
            StopCoroutine(_coroutine);
        
        _coroutine = StartCoroutine(ChangeVolumeSmoothly(MaxVolume));
    }

    public void TurnOff()
    {
        if (_coroutine != null)
            StopCoroutine(_coroutine);
        
        _coroutine = StartCoroutine(ChangeVolumeSmoothly(MinVolume));
    }

    private IEnumerator ChangeVolumeSmoothly(float targetVolume)
    {
        var wait = new WaitForSeconds(MinTimeStep);
        
        while (Mathf.Approximately(_audioSource.volume, targetVolume) == false)
        {
            _audioSource.volume = Mathf.MoveTowards(_audioSource.volume, targetVolume, _step);
            yield return wait; 
        }
    }
}
