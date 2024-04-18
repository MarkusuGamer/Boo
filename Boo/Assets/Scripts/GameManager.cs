using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Candle
{
    public int candleOrder;
    public GameObject candleObject;

    Candle(float timeToLight)
    {
        this.candleOrder = candleOrder;
    }
}
public class GameManager : MonoBehaviour
{
    public int Hp = 3;

    private int candleCount;

    [SerializeField] private GameObject candleObject;

    [SerializeField] private Candle[] candles;
    private Candle[] orderedCandles;
    // Start is called before the first frame update
    void Start()
    {
        candleCount = 0;
        foreach(Candle candle in candles)
        {
            candle.candleObject = Instantiate(candleObject,10*(Quaternion.AngleAxis((360/candles.Length*candleCount),transform.up)*transform.forward),Quaternion.identity);
            candleCount++;
        }
        candleCount = 0;
        orderedCandles = new Candle[candles.Length];
        CombinationStart();
    }

    // Update is called once per frame
    void ClickCandle(int candleOrder)
    {
        if (candleOrder == candleCount)
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
        while (candleCount < candles.Length)
        {
            foreach(Candle candle in candles)
            {
                if (candle.candleOrder == candleCount)
                {
                    orderedCandles[candleCount] = candle;
                }
            }
            candleCount++;
        }

        StartCoroutine(waiter());
    }

    IEnumerator waiter()
    {
        foreach (Candle candle in orderedCandles)
        {
            yield return new WaitForSeconds(2);
            ActivateCandle(candle);
        }
    }

        void NextCandle()
    {
        candleCount++;
    }

    void Error()
    {
        candleCount = 0;
        Hp--;
        if(Hp== 0)
        {
            GameOver();
        }
        CombinationStart();
    }

    void ActivateCandle(Candle candle)
    {
        candle.candleObject.GetComponent<MeshRenderer>().enabled= false;
    }

    void GameOver()
    {

    }
}
