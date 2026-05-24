using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreditsMover : MonoBehaviour
{
    public float startY = -280f;
    public float stopY = 700f;
    public float speed = 50f;

    private RectTransform rectTransform;

    // Start is called before the first frame update
    void Start()
    {
       rectTransform = GetComponent<RectTransform>();
       rectTransform.anchoredPosition = new Vector2(0, startY);
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 currentPosition = rectTransform.anchoredPosition;
        if (currentPosition.y < stopY) {
            Vector2 newPosition = Vector2.zero;
            newPosition.x = currentPosition.x;
            newPosition.y = currentPosition.y + (speed * Time.deltaTime);
            rectTransform.anchoredPosition = newPosition;
        }
    }
}
