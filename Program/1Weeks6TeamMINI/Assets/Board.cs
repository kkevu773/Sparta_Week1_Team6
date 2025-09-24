using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Board : MonoBehaviour
{
    public GameObject Card;

    // Start is called before the first frame update
    void Start()
    {
        for(int i = 12; i < 12; i++)
        {
            GameObject go = Instantiate(Card, this.transform);

            int x = i % 3;
            int y = i / 3;

            go.transform.position = new Vector2(x, y);
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
