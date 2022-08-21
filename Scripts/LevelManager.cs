using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public static LevelManager instance;
    private void Awake()
    {
        instance = this;
    }

    [SerializeField] private GameObject[] levelSpawns;
    private int levelIter = 0;
    private GameObject player;
    [SerializeField] private int startLevelIndex;

    
    private void Start()
    {
        EventManager.Current.onPlayerTouchGoal += Current_onPlayerTouchGoal;
        player = FindObjectOfType<PlayerMovementController>().gameObject;
        ChooseLevel(0);
        levelIter++;

    }

    private void Current_onPlayerTouchGoal()
    {
        NextLevel();
    }
    public void NextLevel()
    {
        print("Moving player to level with index " + levelIter);
        player.transform.position = new Vector3(levelSpawns[levelIter].transform.position.x, levelSpawns[levelIter].transform.position.y, player.transform.position.z);
        Camera.main.transform.position = new Vector3(levelSpawns[levelIter].transform.position.x, Camera.main.transform.position.y, Camera.main.transform.position.z);
        levelIter++;

    }
    public void ChooseLevel(int levelIndex)
    {
        player.transform.position = new Vector3(levelSpawns[levelIndex].transform.position.x, levelSpawns[levelIndex].transform.position.y, player.transform.position.z);
        Camera.main.transform.position = new Vector3(levelSpawns[levelIndex].transform.position.x, Camera.main.transform.position.y, Camera.main.transform.position.z);
    }
    private void OnDestroy()
    {
        EventManager.Current.onPlayerTouchGoal -= Current_onPlayerTouchGoal;

    }
}
