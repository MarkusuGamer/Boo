using UnityEngine;

public class ClickCandleController : MonoBehaviour
{
    private GameManager gm;

    private void Start()
    {
        gm = GameObject.Find("GameManager").GetComponent<GameManager>();
    }
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (LookForGameObject(out RaycastHit hit))
            {
                if (hit.collider.gameObject.TryGetComponent(out CandleController candleController))
                {
                    candleController.ChangeLightState();
                    gm.ClickCandle(candleController.order);
                }
            }
        }
    }

    private bool LookForGameObject(out RaycastHit hit)
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        return Physics.Raycast(ray, out hit);
    }
}