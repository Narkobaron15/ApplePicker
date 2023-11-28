using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class Basket : MonoBehaviour
{
    private const int AppleScore = 100;

    private Camera _mainCamera;
    
    [Header("Set dynamically")]
    public TextMeshProUGUI scoreGt;

    private int PrevScore => Convert.ToInt32(scoreGt.text);
    
    // Start is called before the first frame update
    private void Start()
    {
        _mainCamera = Camera.main;

        var scoreGo = GameObject.Find("ScoreCounter");
        scoreGt = scoreGo.GetComponent<TextMeshProUGUI>();
        scoreGt.text = "0";
    }

    // Update is called once per frame
    private void Update()
    {
        // Current coordinates of the mouse on screen
        Vector3 mousePos2D = Input.mousePosition;
        // The camera's z position sets the how far the mouse is in 3D
        mousePos2D.z = -_mainCamera.transform.position.z;
        
        // Convert the point from 2D screen space into 3D game world space
        Vector3 mousePos3D = _mainCamera.ScreenToWorldPoint(mousePos2D);
        
        // Move the x position of this Basket to the x position of the mouse
        Vector3 pos = transform.position;
        pos.x = mousePos3D.x;
        transform.position = pos;
    }

    private void OnCollisionEnter(Collision collision)
    {
        var collidedWith = collision.gameObject;
        if (!collidedWith.CompareTag("Apple")) return;
        
        Destroy(collidedWith);
        AddScore();
        
        if (PrevScore > HighScore.Score) {
            HighScore.Score = PrevScore;
        }
    }
    
    private void AddScore()
    {
        int newScore = PrevScore + AppleScore + Random.Range(-20, 20);
        scoreGt.text = newScore.ToString();
    }
}
