using UnityEngine;
using UnityEngine.UI;

public class TowerController : MonoBehaviour
{
    public GameObject towerPrefab;
    public Button placeTowerButton;
    private bool isPlacingTower = false;
    private int towerCount = 0;
    public int maxTowers = 2;

    void Start()
    {
        if (placeTowerButton == null)
        {
            Debug.LogError("Place Tower button is not assigned");
            return;
        }
        placeTowerButton.onClick.AddListener(OnPlaceTowerButtonClicked);
    }

    void Update()
    {
        if (isPlacingTower && Input.GetMouseButtonDown(0))
        {
            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mousePosition.z = 0;
            PlaceTower(mousePosition);
            isPlacingTower = false;
        }
    }

    void OnPlaceTowerButtonClicked()
    {
        if (towerCount < maxTowers)
        {
            isPlacingTower = true;
        }
        else
        {
            Debug.Log("Maximum number of towers reached.");
        }
    }

    void PlaceTower(Vector3 position)
    {
        Instantiate(towerPrefab, position, Quaternion.identity);
        towerCount++;
    }
}
