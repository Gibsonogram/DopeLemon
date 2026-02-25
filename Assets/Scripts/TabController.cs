using UnityEngine;
using UnityEngine.UI;

public class TabController : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public Image[] tabImages;
    public GameObject[] pages;

    void Start()
    {
        
    }

    public void ActivateTab(int tabNum)
    {
        for (int ii = 0; ii < pages.Length; ii++)
        {
            pages[ii].SetActive(false);
            tabImages[ii].color = Color.gray;
        }

        pages[tabNum].SetActive(true);
        tabImages[tabNum].color = Color.white;

    }

}
