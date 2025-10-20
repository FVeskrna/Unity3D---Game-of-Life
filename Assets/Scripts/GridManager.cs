using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.ConstrainedExecution;
using UnityEditor;
using UnityEngine;

public class GridManager : MonoBehaviour
{
    public bool SimulationRunning = false;
    public bool BoardGenerated = false;
    public int _width, _height;

    [SerializeField] private int SizeMultiplier;

    [SerializeField] private Tile _tilePrefab;

    [SerializeField] private Transform _cam;


    public Tile[,] Tiles; 


    public void StartGame()
    {
        _width = Screen.width;
        _height = Screen.height;
        Tiles = new Tile[(int)_width / 10, (int)_height / 10];
        Debug.Log(Tiles.GetLength(0).ToString() + "  "  +Tiles.GetLength(1).ToString());


        
        GenerateGrid();
        AdjustCamera();

        BoardGenerated = true;

    }
    private void Update()
    {
        if (!BoardGenerated)
            return;

        if (Input.GetKeyDown("space"))
        {
            StartStopSimulation();
        }

        if (SimulationRunning)
            return;

        if (Input.GetKeyDown(KeyCode.R))
            ResetBoard();

        if (Input.GetKeyDown(KeyCode.Q))
            ScrumbleBoard();

        if (Input.GetKeyDown(KeyCode.W))
            ScrumbleBoardSymmetrical();
    }
    public void ResetBoard()
    {
        int xsize = Tiles.GetLength(0);
        int ysize = Tiles.GetLength(1);
        for (int i = 0; i < xsize; i++)
        {
            for (int j = 0; j < ysize; j++)
            {
                Tiles[i, j].State = 0;
                Tiles[i, j].TurnAction();
            }
        }
    }
    public void ScrumbleBoard()
    {
        int xsize = Tiles.GetLength(0);
        int ysize = Tiles.GetLength(1);
        for (int i = 0; i < xsize; i++)
        {
            for (int j = 0; j < ysize; j++)
            {
                int RandomNum = UnityEngine.Random.Range(0, 10);
                if(RandomNum > 7)
                {
                    Tiles[i, j].nextState = true;
                }
                else{
                    Tiles[i, j].nextState = false;
                    Tiles[i,j].State = 0;
                }

                Tiles[i, j].TurnAction();
            }
        }
    }

    public void ScrumbleBoardSymmetrical()
    {
        int xsize = Tiles.GetLength(0);
        int ysize = Tiles.GetLength(1);
        for (int i = 0; i < xsize/2; i++)
        {
            for (int j = 0; j < ysize/2; j++)
            {
                int RandomNum = UnityEngine.Random.Range(0, 10);
                if (RandomNum > 7)
                {
                    Tiles[i, j].nextState = true;
                    Tiles[i, ysize-j-1].nextState = true;
                    Tiles[xsize -i-1, j].nextState = true;
                    Tiles[xsize - i - 1, ysize - j - 1].nextState = true;
                }
                else
                {
                    Tiles[i, j].nextState = false;
                    Tiles[i, ysize - j - 1].TurnAction();
                    Tiles[xsize - i - 1, j].nextState = false;
                    Tiles[xsize - i - 1, ysize - j - 1].nextState = false;
                    Tiles[i, j].State = 0;
                    Tiles[i, ysize - j - 1].State = 0;
                    Tiles[xsize - i - 1, j].State = 0;
                    Tiles[xsize - i - 1, ysize - j - 1].State = 0;
                }

                Tiles[i, j].TurnAction();
                Tiles[i, ysize - j - 1].TurnAction();
                Tiles[xsize - i - 1, j].TurnAction();
                Tiles[xsize - i - 1, ysize - j - 1].TurnAction();
            }
        }
    }

    public void StartStopSimulation()
    {

        if(SimulationRunning){
            CancelInvoke("LifeCycle");
            SimulationRunning = false;
        }
        else 
        {
            InvokeRepeating("LifeCycle", 0, 0.05f);
            SimulationRunning = true;
        }

    }
    void GenerateGrid()
    {
        
        for (int x = 0; x < _width; x += 10)
        {
            for (int y = 0; y < _height; y += 10)
            {

                var spawnedTile = Instantiate(_tilePrefab, new Vector3(x/10f, y/10f), Quaternion.identity);
                spawnedTile.name = $"Tile {x} {y}";
                spawnedTile.transform.SetParent(transform);
                spawnedTile.Xcoord = x / 10;
                spawnedTile.Ycoord = y / 10;
                
                spawnedTile.Init();
                Tiles[x/10,y/10] = spawnedTile;
                
            }
        }

        //_cam.transform.position = new Vector3((float)Screen.width / 200 , (float)Screen.height / 200 , -10);
    }

    void LifeCycle()
    {
        int xsize = Tiles.GetLength(0);
        int ysize = Tiles.GetLength(1);
        for (int i = 0; i < xsize; i++)
        {
            for (int j = 0; j < ysize; j++)
            {
                int numOfNeighbours = CalculateNeighbours(i, j);

                if (numOfNeighbours == 2 && Tiles[i,j].isAlive)
                {
                    Tiles[i, j].nextState = true;
                }
                else if (numOfNeighbours == 3)
                {
                    Tiles[i, j].nextState = true;
                }
                /*
                if (!Tiles[i, j].isAlive && numOfNeighbours == 3)
                {
                    Tiles[i, j].nextState = true;
                }
                else if (Tiles[i, j].isAlive)
                {
                    if(numOfNeighbours == 2 || numOfNeighbours == 3)
                        Tiles[i, j].nextState = true;
                }
                */
            }
        }

        for (int i = 0; i < xsize; i++)
        {
            for (int j = 0; j < ysize; j++)
            {
                Tiles[i, j].TurnAction();
            }
        }
    }
    int CalculateNeighbours(int x, int y)
    {
        int numOfNeighbours = 0;
        int xsize = Tiles.GetLength(0);
        int ysize = Tiles.GetLength(1);


        for (int p = Math.Max(x - 1, 0); p < Math.Min(x + 2, xsize); p++)
        {
            for (int q = Math.Max(y - 1, 0); q < Math.Min(y + 2, ysize); q++)
            {
                if (Tiles[p, q].isAlive)
                    numOfNeighbours++;
            }
                
        }

        if (Tiles[x, y].isAlive)
            numOfNeighbours--;

        return Math.Max(0,numOfNeighbours);
    }

    void AdjustCamera()
    {
        Camera.main.orthographicSize = 1080 / (2 * 10);
        // Get the current camera's orthographic size
        float orthographicSize = Camera.main.orthographicSize;
       
        // Calculate the desired position based on the screen size and camera aspect ratio
        float screenWidth = Screen.width;
        float screenHeight = Screen.height;
        float aspectRatio = screenWidth / screenHeight;
        Vector3 desiredPosition = new Vector3(orthographicSize * aspectRatio, orthographicSize, -10f);
        desiredPosition += new Vector3(-0.5f, -0.5f, 0);

        // Set the camera's position to the desired position
        Camera.main.transform.position = desiredPosition;
    }
}