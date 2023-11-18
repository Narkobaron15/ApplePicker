using UnityEngine;

public class Apple : MonoBehaviour
{
    public static float BottomY = -20f;
    
    // Start is called before the first frame update
    private void Start()
    {
        
    }

    // Update is called once per frame
    private void Update()
    {
        if (transform.position.y < BottomY)
        {
            // Destroy this Apple
            Destroy(gameObject);
            
            // Decrease HP by 1 heart
        }
    }
}
