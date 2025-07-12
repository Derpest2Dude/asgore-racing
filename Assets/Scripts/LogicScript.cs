using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering.Universal;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LogicScript : MonoBehaviour
{
    public int playerScore;
    public float timerScore;
    private float timerInterval = 0.0003f;
    private int timerDisplay = 0;
    private bool gameStarted = false;
    
    public Text timerText;
    public Text scoreText;
    public Text finalScore;
    
    public GameObject gameOverScreen;
    public GameObject gameMenu;

    public ObstacleSpawnScript coneSpawner;
    public ObstacleSpawnScript logSpawner;
    public ObstacleSpawnScript tapeSpawner;
    public ObstacleSpawnScript stopSignSpawner;
    public ObstacleSpawnScript bananaSpawner;
    public ObstacleSpawnScript torielSpawner;
    public ObstacleSpawnScript potholeSpawner;
    public ObstacleSpawnScript hatSpawner;
    public ObstacleSpawnScript deerSignSpawner;
    public ObstacleSpawnScript dessSpawner;
    public ObstacleSpawnScript dogSpawner;

    public ObstacleMover coneMover;
    public ObstacleMover logMover;
    public ObstacleMover tapeMover;
    public ObstacleMover stopSignMover;
    public ObstacleMover bananaMover;
    public ObstacleMover torielMover;
    public ObstacleMover potholeMover;
    public ObstacleMover hatMover;
    public ObstacleMover deerSignMover;
    public ObstacleMover dessMover;
    public ObstacleMover dogMover;
    
    public ObstacleMover roadMover;
    public ObstacleMover smallTreeMover;
    public ObstacleMover largeTreeMover;
    public ObstacleMover skyMover;
    public ObstacleMover rainbowMover;

    public RoadSpawnScript roadSpawnScript;
    public RoadSpawnScript bigTreeSpawner;
    public RoadSpawnScript smallTreeSpawner;
    public RoadSpawnScript skySpawner;

    public RoadSpawnScript rainbowSpawnScript;

    public SoundManager soundManager;
    
    
    private void Update()
    {
        
        if (timerScore < timerInterval) 
        {
            timerScore += Time.deltaTime;
        }
        else if (gameStarted)
        {
            timerScore = 0;
            timerDisplay += 1;
            timerText.text = timerDisplay.ToString();
        }


        if (timerDisplay == 175000)
        {
            DrinkBeer();
            dogSpawner.enabled = true;
        }
        else if (timerDisplay == 150000)
        {
            DrinkBeer();
            deerSignSpawner.enabled = true;
            dessSpawner.enabled = true;
        }
        else if (timerDisplay == 125000)
        {
            DrinkBeer();
            RoadEnabler(false);
            hatSpawner.enabled = true;
            soundManager.StartRainbowMusic();
        }
        else if (timerDisplay == 100000)
        {
            DrinkBeer();
            potholeSpawner.enabled = true;
        }
        else if (timerDisplay == 75000)
        {
            DrinkBeer();
            stopSignSpawner.enabled = true;
            bananaSpawner.enabled = true;
        }
        else if (timerDisplay == 50000)
        {
            DrinkBeer();
            torielSpawner.enabled = true;
        }
        else if (timerDisplay == 25000)
        {
            DrinkBeer();
            tapeSpawner.enabled = true;
            
        }
        else if (timerDisplay == 1000)
        {
            coneSpawner.enabled = true;
            logSpawner.enabled = true;
        }
    }
    

    public void AddScore(int scoreToAdd)
    {
        playerScore = playerScore + scoreToAdd;
        scoreText.text = playerScore.ToString();
    }
    

    public void RemoveScore(int scoreToRemove)
    {
        playerScore = playerScore - scoreToRemove;
        scoreText.text = playerScore.ToString();

        if (playerScore <= 0)
        {
            GameOver();
        }
    }

    public void StartGame()
    {
        ResetEverything();
        gameStarted = true;
        gameMenu.SetActive(false);
        //audio stuff
        soundManager.StartNightMusic();
        
    }

    public void RestartGame()
    {
        ResetEverything();
        timerDisplay = 0;
        gameStarted = false;
        gameOverScreen.SetActive(false);
        gameMenu.SetActive(true);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void GameOver()
    {
        gameOverScreen.SetActive(true);
        finalScore.text = timerDisplay.ToString();
        soundManager.StopAllMusic();
        ResetEverything();
    }

    private void DrinkBeer()
    {
        coneMover.moveSpeed *= 1.25f;
        logMover.moveSpeed *= 1.25f;
        tapeMover.moveSpeed *= 1.25f;
        bananaMover.moveSpeed *= 1.25f;
        stopSignMover.moveSpeed *= 1.25f;
        torielMover.moveSpeed *= 1.25f;
        potholeMover.moveSpeed *= 1.25f;
        hatMover.moveSpeed *= 1.25f;
        deerSignMover.moveSpeed *= 1.25f;
        dessMover.moveSpeed *= 1.25f;
        dogMover.moveSpeed *= 1.25f;

        roadMover.moveSpeed *= 1.25f;
        smallTreeMover.moveSpeed *= 1.25f;
        largeTreeMover.moveSpeed *= 1.25f;
        skyMover.moveSpeed *= 1.25f;

        rainbowMover.moveSpeed *= 1.25f;
        
        //road spawning interval increasing

        roadSpawnScript.spawnRate /= 1.25f;
        bigTreeSpawner.spawnRate /= 1.25f;
        smallTreeSpawner.spawnRate /= 1.25f;
        skySpawner.spawnRate /= 1.25f;
        rainbowSpawnScript.spawnRate /= 1.25f;
        
        //obstacle spawn rate increases
        
        coneSpawner.spawnRate /= 1.25f;
        logSpawner.spawnRate /= 1.25f;
        tapeSpawner.spawnRate /= 1.25f;
        stopSignSpawner.spawnRate /= 1.25f;
        potholeSpawner.spawnRate /= 1.25f;
        hatSpawner.spawnRate /= 1.25f;
        
        //play sounds
        soundManager.PlayDrinkBeerSound();
    }

    private void ResetEverything()
    {
        //reset movespeed of objects
        coneMover.moveSpeed = 5;
        logMover.moveSpeed = 5;
        tapeMover.moveSpeed = 5;
        bananaMover.moveSpeed = 2.5f;
        stopSignMover.moveSpeed = 5;
        torielMover.moveSpeed = 10;
        potholeMover.moveSpeed = 5;
        hatMover.moveSpeed = 5;
        deerSignMover.moveSpeed = 5;
        dessMover.moveSpeed = 2;
        dogMover.moveSpeed = 15;

        roadMover.moveSpeed = 5;
        smallTreeMover.moveSpeed = 3;
        largeTreeMover.moveSpeed = 4;
        skyMover.moveSpeed = 1;

        rainbowMover.moveSpeed = 5;
        
        //reset spawn rates of roads
        
        roadSpawnScript.spawnRate = 7;
        bigTreeSpawner.spawnRate = 2.65f;
        smallTreeSpawner.spawnRate = 10;
        skySpawner.spawnRate = 7.5f;
        rainbowSpawnScript.spawnRate = 7;
        
        //reset obstacle spawn rates
        
        coneSpawner.spawnRate = 6;
        logSpawner.spawnRate = 8.5f;
        tapeSpawner.spawnRate = 14.5f;
        stopSignSpawner.spawnRate = 17;
        potholeSpawner.spawnRate = 7;
        hatSpawner.spawnRate = 6;
        
        //reset spawners
        coneSpawner.enabled = false;
        logSpawner.enabled = false;
        tapeSpawner.enabled = false;
        bananaSpawner.enabled = false;
        stopSignSpawner.enabled = false;
        torielSpawner.enabled = false;
        potholeSpawner.enabled = false;
        hatSpawner.enabled = false;
        deerSignSpawner.enabled = false;
        dessSpawner.enabled = false;
        dogSpawner.enabled = false;
        
        RoadEnabler(true);
        
    }

    private void RoadEnabler(bool active)
    {
        if (active)
        {
            roadSpawnScript.enabled = true;
            bigTreeSpawner.enabled = true;
            smallTreeSpawner.enabled = true;
            skySpawner.enabled = true;
        }
        else
        {
            roadSpawnScript.enabled = false;
            bigTreeSpawner.enabled = false;
            smallTreeSpawner.enabled = false;
            skySpawner.enabled = false;
        }

    }
}
