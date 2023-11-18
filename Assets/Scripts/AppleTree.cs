using UnityEngine;

public class AppleTree : MonoBehaviour
{
    // Apple template
    [Header("Set in inspector")] public GameObject applePrefab;

    public float speed = 1;

    public float leftAndRightEdge = 10;
    
    public float chanceToChangeDirections = 0.1f;
    
    public float secondsBetweenAppleDrops = 1;
    
    // Start is called before the first frame update
    private void Start()
    {
        Invoke(nameof(DropApple), 2);
    }
    
    // Update is called once per frame
    private void Update()
    {
        var pos = transform.position;
        pos.x += speed * Time.deltaTime;
        transform.position = pos;

        if (pos.x < -leftAndRightEdge)
            speed = Mathf.Abs(speed); // Move right
        else if (pos.x > leftAndRightEdge)
            speed = -Mathf.Abs(speed); // Move left
    }

    private void FixedUpdate()
    {
        if (Random.value < chanceToChangeDirections)
            speed *= -1; // Change direction
    }
    
    private void DropApple()
    {
        var apple = Instantiate(applePrefab);
        apple.transform.position = transform.position;
        
        Invoke(nameof(DropApple), secondsBetweenAppleDrops);
    }
}
