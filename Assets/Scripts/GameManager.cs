using UnityEngine;
using System;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
    {
        [SerializeField]
        GameObject onelaser;
        [SerializeField]
        GameObject laserWall;

        public static Action gameStart;
        
        public void OnEnable()
        {
            TimeController.laserSpawn += spawnLaser;
            TimeController.laserWallSpawn += spawnLaserWall;
            TimeController.timeOut += RestartScene;
            PlayerStats.dead += RestartScene;
            TimeController.timeStart += startGame;
        }
        public void OnDisable()
        {
            TimeController.laserSpawn -= spawnLaser;
            TimeController.laserWallSpawn -= spawnLaserWall;
            TimeController.timeOut -= RestartScene;
            PlayerStats.dead -= RestartScene;
            TimeController.timeStart -= startGame;
        }
        public void spawnLaser()
        {
            Instantiate(onelaser, transform.position, Quaternion.Euler(0,0,UnityEngine.Random.Range(0, 360)));
            
        }
        public void spawnLaserWall()
        {
            Instantiate(laserWall, new Vector3(transform.position.x + UnityEngine.Random.Range(0, 5f), transform.position.y, transform.position.z), Quaternion.identity);
            
        }

        public void RestartScene()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }

        public void startGame()
        {
            gameStart?.Invoke();
        }
    }
