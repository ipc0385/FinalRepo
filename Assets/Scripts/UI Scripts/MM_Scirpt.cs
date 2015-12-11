using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class MM_Scirpt : MonoBehaviour {

    public Canvas quitMenu;
    public Button start_b;
    public Button collections;
    public Button quit_b;
    private RawImage background;

	// Use this for initialization
	void Start () {

        quitMenu = quitMenu.GetComponent<Canvas>();
        start_b = start_b.GetComponent<Button>();
        collections = collections.GetComponent<Button>();
        quit_b = quit_b.GetComponent<Button>();
        background = this.GetComponent<RawImage>();
        quitMenu.enabled = false;

	}
	
	// Update is called once per frame
	void Update () {

	
	}

    public void ExitPress()
    {
        quitMenu.enabled = true;
        start_b.enabled = false;
        collections.enabled = false;
        quit_b.enabled = false;
        background.color = Color.Lerp(new Color(255,255,255),new Color(1,1,1), Time.time);
    }

    public void NoPress()
    {
        quitMenu.enabled = false;
        start_b.enabled = true;
        collections.enabled = true;
        quit_b.enabled = true;
        background.color = Color.Lerp(new Color(131,131,131), new Color(255, 255, 255), Time.time);

    }

    public void Quit_Confirm()
    {
        Application.Quit();
    }

    public void StartPress()
    {
        Application.LoadLevel("GameBoardScene");
    }
}
