using UnityEngine;

public class CandleController : MonoBehaviour
{
    // ---- / Public Variables / ---- //
    public int order;

    // ---- / Serialized Variables / ---- //
    [Header("Visuals")]
    [SerializeField] private Sprite unlitCandleSprite;
    [SerializeField] private Sprite litCandleSprite;

    [Header("Audio")]
    [SerializeField] private AudioClip lightCandle;
    [SerializeField] private AudioClip turnOffCandle;
    
    // ---- / Private Variables / ---- //
    private SpriteRenderer _spriteRenderer;
    private bool _lightState;
    private AudioSource _audioSource;
    
    private void Start()
    {
        _spriteRenderer = GetComponentInChildren<SpriteRenderer>();
        _audioSource = GetComponent<AudioSource>();
        if (_spriteRenderer.sprite == litCandleSprite)
        {
            _lightState = true;
        }
    }

    public void ForceState(bool lit)
    {
        ChangeSprite(lit);
        _lightState = lit;
    }

    public void ChangeLightState()
    {
        _lightState = !_lightState;
        ChangeSprite(_lightState);
    }

    public void ChangeSprite(bool state)
    {
        if (state)
        {
            _spriteRenderer.sprite = litCandleSprite;
            _audioSource.PlayOneShot(lightCandle);
        }
        else
        {
            _spriteRenderer.sprite = unlitCandleSprite;
            _audioSource.PlayOneShot(turnOffCandle);
        }
    }
}
