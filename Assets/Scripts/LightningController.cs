using UnityEngine;
using UnityEngine.UI;

public class LightningController : MonoBehaviour
{
    public GameObject lightningPrefab;
    public Transform player;
    public Button lightningButton;
    private bool isSelectingTarget = false;

    void Start()
    {
        if (lightningButton == null)
        {
            Debug.LogError("Lightning button is not assigned!");
            return;
        }
        lightningButton.onClick.AddListener(OnLightningButtonClicked);
    }

    void Update()
    {
        if (isSelectingTarget && Input.GetMouseButtonDown(0))
        {
            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mousePosition.z = 0;
            ShootLightning(mousePosition);
            isSelectingTarget = false;
        }
    }

    void OnLightningButtonClicked()
    {
        isSelectingTarget = true;
    }

    void ShootLightning(Vector3 targetPosition)
    {
        GameObject lightning = Instantiate(lightningPrefab, player.position, Quaternion.identity);
        lightning.GetComponent<LightningMovement>().Initialize(player.position, targetPosition);

        // ≈сли молни€ уничтожает шарики, добавим метод начислени€ монет здесь
        // Ќапример:
        // collider.GetComponent<BallMovement>().player.GetComponent<PlayerController>().AddCoin();
    }
}
