using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Candle
{
    public int candleOrder;
    public GameObject candleObject;
}
public class GameManager : MonoBehaviour
{
    private ClickCandleController cc;

    public int Hp = 3;

    private int candleCount;

    private List<int> NumberArr = new List<int>();

    [SerializeField] private GameObject candleObject;

    [SerializeField] private int howMuchCandles = 3;

    private Candle[] candles;
    private Candle[] orderedCandles;
    
    void Start()
    {
        cc = GetComponent<ClickCandleController>();
        candleCount = 0;
        candles = new Candle[howMuchCandles];
        for (int i = 0; i < howMuchCandles; i++)
        {
            NumberArr.Add(i);
            candles[i] = new Candle();
        }

        for (int i = 0; i < howMuchCandles; i++)
        {

            int rndnumber = Random.Range(0, howMuchCandles - candleCount);
            candleCount++;
            candles[i].candleOrder = NumberArr[rndnumber];
            NumberArr.RemoveAt(rndnumber);
        }



        candleCount = 0;
        foreach(Candle candle in candles)
        {
            candle.candleObject = Instantiate(candleObject,10*(Quaternion.AngleAxis((360/candles.Length*candleCount),transform.up)*transform.forward),Quaternion.identity);
            candle.candleObject.GetComponent<CandleController>().order = candle.candleOrder;
            candleCount++;
        }
        candleCount = 0;
        orderedCandles = new Candle[candles.Length];

        while (candleCount < candles.Length)
        {
            foreach (Candle candle in candles)
            {
                if (candle.candleOrder == candleCount)
                {
                    orderedCandles[candleCount] = candle;
                }
            }
            candleCount++;
        }

        candleCount = 0;

        CombinationStart();
    }

    // Update is called once per frame
    public void ClickCandle(int candleOrder)
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
        cc.enabled = false;

        candleCount = 0;

        StartCoroutine(waiter());
    }

    IEnumerator waiter()
    {
        foreach (Candle candle in orderedCandles)
        {
            yield return new WaitForSeconds(1f);
            ActivateCandle(candle);
        }
        cc.enabled = true;
    }

    void NextCandle()
    {
        candleCount++;
        if(candleCount == howMuchCandles)
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
        candleCount = 0;
        Hp--;
        if(Hp== 0)
        {
            GameOver();
        }

        foreach(Candle candle in candles)
        {
            candle.candleObject.GetComponent<CandleController>().ForceState(true);
        }

        CombinationStart();
    }

    void ActivateCandle(Candle candle)
    {
        candle.candleObject.GetComponent<CandleController>().ChangeLightState();
    }

    void GameOver()
    {
        SceneManager.LoadScene(SceneManager.sceneCount-1);
    }
}
