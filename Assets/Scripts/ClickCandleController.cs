using UnityEngine;

public class ClickCandleController : MonoBehaviour
{
    // ---- / Private Variables / ---- //
    private GameManager _gameManager;

    private void Start()
    {
        _gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
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
                    _gameManager.ClickCandle(candleController.order);
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