using UnityEngine;

public class CandleController : MonoBehaviour
{
    // ---- / Serialized Variables / ---- //
    [SerializeField] private AudioClip lightCandle;
    [SerializeField] private AudioClip turnOffCandle;
    
    // ---- / Private Variables / ---- //
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
            _audioSource.PlayOneShot(lightCandle);
        }
        else
        {
            _light.enabled = false;
            _audioSource.PlayOneShot(turnOffCandle);
        }
    }
}
