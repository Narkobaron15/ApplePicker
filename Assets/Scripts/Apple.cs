using UnityEngine;

public class Apple : MonoBehaviour
{
    private Camera _mainCamera;
    private ApplePicker _applePicker;

    private const float BottomY = -20f;

    // Start is called before the first frame update
    private void Start()
    {
        _mainCamera = Camera.main;
        _applePicker = _mainCamera!.GetComponent<ApplePicker>();
    }

    // Update is called once per frame
    private void Update()
    {
        if (transform.position.y < BottomY)
        {
            // Destroy this Apple
            Destroy(gameObject);
            
            // Decrease HP by 1 heart
            _applePicker.AppleDestroyed();
        }
    }
}
