using UnityEngine;
using UnityEngine.UI;

public class HealthManager : MonoBehaviour
{
    // ---- / Serialized Variables / ---- //
    [SerializeField] private Image corduraMeter;
    [SerializeField] private Sprite[] corduraSprites;
    
    // ---- / Private Variables / ---- //
    private GameManager _gameManager;
    private float _maxHp;
    
    void Start()
    {
        _gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        corduraMeter.sprite = corduraSprites[0];
        _maxHp = _gameManager.hp;
    }

    void Update()
    {
        if (_gameManager.hp >= _maxHp)
        {
            corduraMeter.sprite = corduraSprites[0];
        }
        else if (_gameManager.hp <= _maxHp * 0.6)
        {
            corduraMeter.sprite = corduraSprites[1];
        }
        else if (_gameManager.hp <= _maxHp * 0.3)
        {
            corduraMeter.sprite = corduraSprites[2];
        }
        else if (_gameManager.hp <= 0)
        {
            corduraMeter.sprite = corduraSprites[3];
        }
    }
}
