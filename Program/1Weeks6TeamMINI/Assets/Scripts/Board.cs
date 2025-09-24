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
        //��ġ�Ϸ��� ī�尡 12���̹Ƿ� 5f���� �����
        for (int i = 0; i < 12; i++)// 12�� ����
        {
            GameObject go = Instantiate(card, this.transform);

            float x = (i % 3) * 1.6f - 2.1f;
            float y = (i / 3) * 1.6f - 3.0f;
            //3���� 4���� ������ �����⸦ 4�� �ƴ� 3���� �����ؾ� ��
            go.transform.position = new Vector2(x, y);
            go.GetComponent<card>().Setting(arr[i]);
        }

        GameManager.Instance.cardCount = arr.Length;
    }
}
