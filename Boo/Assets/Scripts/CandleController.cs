using UnityEngine;

public class CandleController : MonoBehaviour
{
    private Light _light;
    private bool _lightState;
    
    private void Start()
    {
        _light = GetComponentInChildren<Light>();
        _lightState = _light.enabled;
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
        }
        else
        {
            _light.enabled = false;
        }
    }
}