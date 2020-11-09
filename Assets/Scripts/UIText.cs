using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class UIText : MonoBehaviour
{
    public Text LivesText;
    private GameObject gameManager;
    private int Lives;
    // Start is called before the first frame update
    void Start()
    {
        gameManager = this.gameObject;
        Lives = gameManager.GetComponent<GameManager>().Lives;
    }

    // Update is called once per frame
    void Update()
    {
        Lives = gameManager.GetComponent<GameManager>().Lives;
        LivesText.text = "Lives = " + Lives;
    }
}
