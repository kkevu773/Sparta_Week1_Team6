using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Board : MonoBehaviour
{
    public GameObject Card;

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < 12; i++)
        {
            GameObject go = Instantiate(Card, this.transform);

            float x = (i % 3) * 1.4f - 1.4f;
            float y = (i / 3) * 1.4f - 3.4f;

            go.transform.position = new Vector2(x, y);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
