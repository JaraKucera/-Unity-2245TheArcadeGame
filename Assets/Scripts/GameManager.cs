using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public AudioManager audioManager;
    private static int gameLevel = 0, score = 0, lives = 3;
    public GameObject player, HUD, GameOverHUD;
    public static ArrayList enemies = new ArrayList();
    private float gameOverCheck = 2f;
    //Scene Methods
    void OnEnable() => SceneManager.sceneLoaded += OnLevelLoadGame;
    private void OnDisable() => SceneManager.sceneLoaded -= OnLevelLoadGame;
    private void OnLevelLoadGame(Scene sc, LoadSceneMode mode)
    {
        instance = this;
        score = 0;
        lives = 3;
        gameLevel = 0;
        gameOverCheck = 2f;
        Camera.main.transform.position = new Vector3(0f, 1f, -10f);
        Camera.main.transform.LookAt(Vector3.zero);
        int musicType = Random.Range(1, 8);
        audioManager.Play("Music"+musicType);
        CreatePlayer();
        StartNextLevel();
        InvokeRepeating("AllEnemiesDead", 2f, gameOverCheck);
    }
    //HUD Methods
    public int GetLives() => lives;
    public int GetLevel() => gameLevel;
    public int GetScore() => score;
    public void IncreaseScore() => score += 10;
    //Player Methods
    public void CreatePlayer()
    {
        GameObject player = (GameObject)Instantiate(Resources.Load("PlayerShip"));
        player.transform.position = new Vector3(0f, -7f, 0f);
        this.player = player;
    }
    public void ReduceHealth()
    {
        audioManager.Play("PlayerDamaged");
        if (!(player.GetComponent<PlayerShoot>().ReduceLevel()))
        {
            lives--;
            if (lives <= 0)
            {
                //GameOver
                foreach(GameObject enemy in enemies)
                {
                    Destroy(enemy);
                }
                enemies.Clear();
                audioManager.Play("GameOver");
                Destroy(player);
                gameOverCheck = 10000000000f;
                GameOver();
            }
        }
    }
    public Vector3 GetShipPosition()
    {
        try
        {
            return player.gameObject.GetComponent<PlayerMovement>().GetPlayerPosition();
        }
        catch (System.Exception) {}
        return new Vector3(0f, 0f, 0f);
    }
    //Enemy Methods
    public void AllEnemiesDead()
    {
        if(enemies.Count == 0)
        {
            StartNextLevel();
        }
    }
    public void CreateEnemy()
    {
        int enemyBodyType = ((int)(Random.Range(1f, 5f)));
        GameObject enemy = (GameObject)Instantiate(Resources.Load("EnemyBody" + enemyBodyType));    //Decide which Enemy Body to use

        enemy.AddComponent<EnemyHealth>();  //Add Health Script
        enemy.GetComponent<EnemyHealth>().SetHealth(5 * (gameLevel * 2)); //Set Default Health

        int movementType = ((int)(Random.Range(1f, 6f)));
        if (movementType == 1)
        {
            enemy.AddComponent<Enemy1Movement>();   //Add Movement Script
            enemy.GetComponent<Enemy1Movement>().SetSpeed((10f * (gameLevel * 0.5f)) + (Random.Range(-2f, 5f)));     //Set Movement Speed
        }
        else if (movementType == 2)
        {
            enemy.AddComponent<Enemy2Movement>();   //Add Movement Script
            enemy.GetComponent<Enemy2Movement>().SetSpeed((10f * (gameLevel * 0.5f)) + (Random.Range(-2f, 5f)));     //Set Movement Speed
        }
        else if (movementType == 3)
        {
            enemy.AddComponent<Enemy3Movement>();   //Add Movement Script
            enemy.GetComponent<Enemy3Movement>().SetSpeed((10f * (gameLevel * 0.5f)) + (Random.Range(-2f, 5f)));     //Set Movement Speed
        }
        else if (movementType == 4)
        {
            enemy.AddComponent<Enemy4Movement>();   //Add Movement Script
            enemy.GetComponent<Enemy4Movement>().SetSpeed((10f * (gameLevel * 0.5f)) + (Random.Range(-2f, 5f)));     //Set Movement Speed
        }
        else if (movementType == 5)
        {
            enemy.AddComponent<Enemy5Movement>();   //Add Movement Script
            enemy.GetComponent<Enemy5Movement>().SetSpeed((10f * (gameLevel * 0.5f)) + (Random.Range(-2f, 5f)));     //Set Movement Speed
        }
        else if (movementType == 6)
        {
            enemy.AddComponent<Enemy6Movement>();   //Add Movement Script
            enemy.GetComponent<Enemy6Movement>().SetSpeed((10f * (gameLevel * 0.5f)) + (Random.Range(-2f, 5f)));     //Set Movement Speed
        }
        else
        {
            Debug.LogError("Movement Script Error: Failure to add Script");
        }

        if (movementType == 5)  //Ensure that Movement type 5 doesn't go off screen
        {
            enemy.transform.position = new Vector3(-Random.Range(-12f, 13f), Random.Range(-6f, 1f), 0f);   //Set starting position
        }
        else
        {
            enemy.transform.position = new Vector3(-Random.Range(-12f, 13f), Random.Range(-6f, 9f), 0f);   //Set starting position
        }
        enemy.AddComponent<EnemyShoot>();    //Add Shooting Script

        float shootSpeed = 1f - (0.1f * gameLevel+ Random.Range(-0.5f,0.6f));      //Gen Bullet Speed
        if (shootSpeed <= 0f)    //Bounded by min
        {
            shootSpeed = 0.1f;      //Fastest Freq of Bullets
        }
        enemy.GetComponent<EnemyShoot>().SetShootSpeed(shootSpeed);   //Set Frequency of shots

        enemies.Add(enemy);
    }
    public void RemoveFromEnemies(GameObject enemy) => enemies.Remove(enemy);
    //Game Related Methods
    private void Glitch()
    {
        int num = Random.Range(1, 5);
        if(num == 1)
        {
            Camera.main.GetComponent<Kino.AnalogGlitch>().colorDrift += 0.1f;
        }else if(num == 2)
        {
            Camera.main.GetComponent<Kino.AnalogGlitch>().scanLineJitter += 0.1f;
        }else if(num == 3)
        {
            Camera.main.GetComponent<Kino.AnalogGlitch>().verticalJump += 0.05f;
        }else if(num == 4)
        {
            Camera.main.GetComponent<Kino.AnalogGlitch>().horizontalShake += 0.05f;
        }
    }
    private void DeGlitch()
    {
        Camera.main.GetComponent<Kino.AnalogGlitch>().colorDrift = 0.1f;
        Camera.main.GetComponent<Kino.AnalogGlitch>().scanLineJitter = 0.1f;
        Camera.main.GetComponent<Kino.AnalogGlitch>().verticalJump = 0;
        Camera.main.GetComponent<Kino.AnalogGlitch>().horizontalShake = 0;
    }
    public void StartNextLevel()
    {
        if (lives > 0)
        {
            enemies.Clear();
            gameLevel++;
            audioManager.Play("EnemySpawn");
            Glitch();

            try
            {
                player.gameObject.GetComponent<PlayerShoot>().levelUp();
            }
            catch (System.Exception) { }


            for (int i = 0; i < gameLevel + 2 * gameLevel; i++)
            {
                CreateEnemy();
            }
        }
    }
    private void GameOver()
    {
        DeGlitch();
        HUD.SetActive(false);
        GameOverHUD.SetActive(true);
    }
}
