using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoveSystem : MonoBehaviour
{
    [Header("Hearts")]
    public Image heart1;
    public Image heart2;
    public Image heart3;
    public Sprite openHeart;
    public Sprite closeHeart;
    public string lover;

    // current scores
    private int temuScore = 0;
    private int snakeScore = 0;
    private int octopusScore = 0;

    // Start is called before the first frame update
    void Start()
    {
        if (lover == "Temu" && temuScore != GameHandler.MazeMinigame) {
            if (GameHandler.MazeMinigame >= 1) changeHeart(heart1, openHeart);
            if (GameHandler.MazeMinigame >= 2) changeHeart(heart2, openHeart);
            if (GameHandler.MazeMinigame == 3) changeHeart(heart3, openHeart);
            temuScore = GameHandler.MazeMinigame;
        }
        else if (lover == "Snake" && snakeScore != GameHandler.RhythymMinigame) {
            if (GameHandler.RhythymMinigame >= 1) changeHeart(heart1, openHeart);
            if (GameHandler.RhythymMinigame >= 2) changeHeart(heart2, openHeart);
            if (GameHandler.RhythymMinigame == 3) changeHeart(heart3, openHeart);
            snakeScore = GameHandler.RhythymMinigame;
        }
        else if (lover == "Octopus" && octopusScore != GameHandler.FishingMinigame) {
            if (GameHandler.FishingMinigame >= 1) changeHeart(heart1, openHeart);
            if (GameHandler.FishingMinigame >= 2) changeHeart(heart2, openHeart);
            if (GameHandler.FishingMinigame == 3) changeHeart(heart3, openHeart);
            octopusScore = GameHandler.FishingMinigame;
        }
    }


    private void changeHeart(Image heart, Sprite image) {

        heart.sprite = image;
    }
}
