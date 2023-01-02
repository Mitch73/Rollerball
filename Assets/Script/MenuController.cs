using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*recognise text mesh pro*/
using TMPro;

public class MenuController : MonoBehaviour
{
    public GameObject endPanel;
    public TextMeshProUGUI[] countText;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

/*lose scene*/
    public void LoseGame()
    {
        endPanel.SetActive(true);
        endPanel.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = "Game over...";
    }

    public void WinGame()
    {
        endPanel.SetActive(true);
        endPanel.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = "You Win!!";
    }

    public void AddCountText(int playerIndex, int count)
    {
        countText[playerIndex].text = "Count " + count.ToString();
    }
}
