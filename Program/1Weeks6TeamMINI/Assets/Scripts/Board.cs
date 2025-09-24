using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class NewBehaviourScript : MonoBehaviour
{
    //public Transform cards;
    public GameObject card;
    // Start is called before the first frame update
    void Start()
    {
        int[] arr = { 0, 0, 1, 1, 2, 2, 3, 3, 4, 4, 5, 5 };
        arr = arr.OrderBy(x => Random.Range(0f, 5f)).ToArray();
        //배치하려는 카드가 12개이므로 5f까지 남기기
        for (int i = 0; i < 12; i++)// 12로 변경
        {
            GameObject go = Instantiate(card, this.transform);

            float x = (i % 3) * 1.6f - 2.1f;
            float y = (i / 3) * 1.6f - 3.0f;
            //3개씩 4줄을 내려면 나누기를 4가 아닌 3으로 조정해야 함
            go.transform.position = new Vector2(x, y);
            go.GetComponent<card>().Setting(arr[i]);
        }

        GameManager.Instance.cardCount = arr.Length;
    }
}
