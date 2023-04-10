using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerSelection : MonoBehaviour
{
    // https://www.youtube.com/watch?v=3qlRgICRoeA

    public GameObject[] skins;
    public GameObject[] kits;
    public int selectedSkin = 0;
    public int selectedKit = 0;
    
    public void NextSkin()
    {
        skins[selectedSkin].SetActive(false);
        selectedSkin = (selectedSkin + 1) % skins.Length;
        skins[selectedSkin].SetActive(true);
    }
    
    public void PreviousSkin()
    {
        skins[selectedSkin].SetActive(false);
        selectedSkin--;

        if (selectedSkin < 0)
            selectedSkin += skins.Length;

        skins[selectedSkin].SetActive(true);
    }

    public void NextKit()
    {
        kits[selectedKit].SetActive(false);
        selectedKit = (selectedKit + 1) % kits.Length;
        kits[selectedKit].SetActive(true);
    }
    
    public void PreviousKit()
    {
        kits[selectedKit].SetActive(false);
        selectedKit--;

        if (selectedKit < 0)
            selectedKit += kits.Length;

        kits[selectedKit].SetActive(true);
    }

    public void StartGame()
    {
        PlayerPrefs.SetInt("selectedSkin", selectedSkin);
        PlayerPrefs.SetInt("selectedKit", selectedKit);
        SceneManager.LoadScene("_Test");
    }

    public void BackScreen()
    {
        SceneManager.LoadScene("_Selection");       
    }
    
}
