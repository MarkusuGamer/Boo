using UnityEngine;

public class CandleController : MonoBehaviour
{
    private Light _light;
    private bool _lightState;
    private AudioSource _audioSource;
    public int order;
    private void Start()
    {
        _light = GetComponentInChildren<Light>();
        _audioSource = GetComponentInChildren<AudioSource>();
        _lightState = _light.enabled;
    }


    public void ForceState(bool lit)
    {
        _light.enabled = lit;
        _lightState = lit;
    }
    public bool IsCandleLit()
    {
        return _lightState;
    }

    public void ChangeLightState()
    {
        _lightState = !_lightState;

        if (_lightState)
        {
            _light.enabled = true;
            _audioSource.Play();
        }
        else
        {
            _light.enabled = false;
        }
    }
}
