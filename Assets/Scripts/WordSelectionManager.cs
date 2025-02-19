using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class WordSelectionManager : MonoBehaviour
{
    public static WordSelectionManager Instance; // Singleton for global access
    private bool isSelecting = false;
    void Awake()
    {
        Instance = this;
    }

    private List<string> selectedTiles = new List<string>();

    //public TextMeshProUGUI selectedWordText;

    void Update()
    {
        //Touch touch = Input.GetTouch(0);
        if (Input.GetMouseButtonDown(0) /*|| touch.phase == TouchPhase.Began*/) // Start selection
        {
            isSelecting = true;
            //DetectLetterUnderTouch();
            DetectLetterUnderMouse();
            selectedTiles.Clear(); // Clear previous selection
        }
        else if (Input.GetMouseButtonUp(0) /*|| touch.phase == TouchPhase.Ended*/) // End selection
        {
            isSelecting = false;
        }

    }

    void DetectLetterUnderTouch()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0); // Get first touch
            Vector2 touchPos = Camera.main.ScreenToWorldPoint(touch.position); // Convert touch position to world space

            RaycastHit2D hit = Physics2D.Raycast(touchPos, Vector2.zero); // Raycast to detect colliders

            if (hit.collider != null)
            {
                string tile = hit.collider.GetComponent<string>();
                if (tile != null)
                {
                    Debug.Log("Touched Letter: " + tile);
                    //WordSelectionManager.Instance.AddLetter(tile);
                }
            }
        }
    }

    void DetectLetterUnderMouse()
    {
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition); // Convert screen space to world space
        Collider2D[] hitCollider = Physics2D.OverlapPointAll(mousePos); // Check for collision at mouse position

        //if (hitCollider != null)
        //{
        //    string tile = hitCollider.GetComponent<string>(); // Get LetterTile component
        //    if (tile != null && !selectedTiles.Contains(tile)) // Avoid selecting the same tile multiple times
        //    {
        //        Debug.Log("Touched Letter: " + tile);
        //    }
        //}
    }
}
