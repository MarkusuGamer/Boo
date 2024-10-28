using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Candle
{
    public int CandleOrder;
    public GameObject CandleObject;
}
public class GameManager : MonoBehaviour
{
    // ---- / Public Variables / ---- //
    public int hp = 3;
    
    // ---- / Serialized Variables / ---- //
    [SerializeField] private GameObject candleObject;
    [SerializeField] private int howMuchCandles = 3;
    
    // ---- / Private Variables / ---- //
    private ClickCandleController _clickCandleController;
    private int _candleCount;
    private List<int> _numberArr = new List<int>();
    
    private Candle[] _candles;
    private Candle[] _orderedCandles;
    
    void Start()
    {
        _clickCandleController = GetComponent<ClickCandleController>();
        _candleCount = 0;
        _candles = new Candle[howMuchCandles];
        for (int i = 0; i < howMuchCandles; i++)
        {
            _numberArr.Add(i);
            _candles[i] = new Candle();
        }

        for (int i = 0; i < howMuchCandles; i++)
        {

            int randomNumber = Random.Range(0, howMuchCandles - _candleCount);
            _candleCount++;
            _candles[i].CandleOrder = _numberArr[randomNumber];
            _numberArr.RemoveAt(randomNumber);
        }



        _candleCount = 0;
        foreach(Candle candle in _candles)
        {
            Vector3 upVector = new Vector3(0, -0.85f, 0.53f);
            Vector3 forwardVector = Vector3.Cross(upVector, transform.forward);

            Vector3 offsetPosition = new Vector3(0, -1.8f, 0);
            float circleRadius = 9;
            float angleOffset = 19;
            
            candle.CandleObject = Instantiate(candleObject, offsetPosition + circleRadius * (Quaternion.AngleAxis((angleOffset + (360 / _candles.Length * _candleCount)), upVector) * forwardVector),Quaternion.identity);
            candle.CandleObject.GetComponent<CandleController>().order = candle.CandleOrder;
            _candleCount++;
        }
        _candleCount = 0;
        _orderedCandles = new Candle[_candles.Length];

        while (_candleCount < _candles.Length)
        {
            foreach (Candle candle in _candles)
            {
                if (candle.CandleOrder == _candleCount)
                {
                    _orderedCandles[_candleCount] = candle;
                }
            }
            _candleCount++;
        }

        _candleCount = 0;

        CombinationStart();
    }

    public void ClickCandle(int candleOrder)
    {
        if (candleOrder == _candleCount)
        {
            NextCandle();
        }
        else
        {
            Error();
        }
    }

    void CombinationStart()
    {
        _clickCandleController.enabled = false;

        _candleCount = 0;

        StartCoroutine(Waiter());
    }

    IEnumerator Waiter()
    {
        foreach (Candle candle in _orderedCandles)
        {
            yield return new WaitForSeconds(1f);
            ActivateCandle(candle);
        }
        _clickCandleController.enabled = true;
    }

    void NextCandle()
    {
        _candleCount++;
        if(_candleCount == howMuchCandles)
        {
            Win();
        }
    }

    void Win()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    void Error()
    {
        _candleCount = 0;
        hp--;
        if(hp== 0)
        {
            GameOver();
        }

        foreach(Candle candle in _candles)
        {
            candle.CandleObject.GetComponent<CandleController>().ForceState(false);
        }

        CombinationStart();
    }

    void ActivateCandle(Candle candle)
    {
        candle.CandleObject.GetComponent<CandleController>().ChangeLightState();
    }

    void GameOver()
    {
        SceneManager.LoadScene(SceneManager.sceneCount-1);
    }
}
