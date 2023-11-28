using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Serialization;

public class ApplePicker : MonoBehaviour
{
    public GameObject basketPrefab;
    public int numOfBaskets = 3;
    public float basketBottomY = -14f;
    public float basketSpacingY = 2f;
    
    [SerializeField] private List<GameObject> basketList = new();
    
    // Start is called before the first frame update
    private void Start()
    {
        for (int i = 0; i < numOfBaskets; i++)
        {
            var tBasketGo = Instantiate(basketPrefab);
            var pos = Vector3.zero;
            pos.y = basketBottomY + basketSpacingY * i;
            tBasketGo.transform.position = pos;
            
            basketList.Add(tBasketGo);
        }
    }

    // ReSharper disable Unity.PerformanceAnalysis
    public void AppleDestroyed()
    {
        var appleArray = GameObject.FindGameObjectsWithTag("Apple");
        foreach (var apple in appleArray)
            Destroy(apple);

        var basketGameObject = basketList[^1];
        basketList.RemoveAt(basketList.Count - 1);
        Destroy(basketGameObject);
        
        if (basketList.Count <= 0)
        {
            SceneManager.LoadScene("_Scene_0");
        }
    }
}
