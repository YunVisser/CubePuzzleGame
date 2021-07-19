using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Score : MonoBehaviour
{
    public CharController player;
    public TextMeshProUGUI scoreText;

    private void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        scoreText.text = "You still have " + player.maxMoves.ToString() + " move(s)";
    }
}
