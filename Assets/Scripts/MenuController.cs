using UnityEngine;

public class MenuController : MonoBehaviour
{
    public GameObject menuCanvas;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        menuCanvas.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            // ensure menu can't open in other situtations
            if (!menuCanvas.activeSelf && PauseController.isPaused)
            {
                return;
            }

            menuCanvas.SetActive(!menuCanvas.activeSelf);
            PauseController.setPause(menuCanvas.activeSelf);
        }
    }
}
