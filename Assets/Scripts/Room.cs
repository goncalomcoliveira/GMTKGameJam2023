using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Room : MonoBehaviour
{
    public int TILENUM;
    public float TILESIZE;
    public int ROOMSIZE;
    private Furniture[] Matrix;
    private Pair[] CoorMatrix;

    public int[] WallList;

    public GameObject EmptySpace;
    public GameObject Wall;

    public void Start()
    {
        BuildCoordenates();
        BuildRoom();
    }
    public void BuildRoom()
    {
        Matrix = new Furniture[TILENUM];

        for(int i= 0; i <WallList.Length; i++)
        {
            int x = WallList[i];
            Matrix[x] = Instantiate(Wall).GetComponent<Furniture>();
            Matrix[x].Build(true, CoorMatrix[x].x, CoorMatrix[x].y);
        }

        for(int r=0; r< TILENUM; r++)
        {
            if(Matrix[r] is null)
            {
                Matrix[r] = Instantiate(EmptySpace).GetComponent<Furniture>();
                Matrix[r].Build(true, CoorMatrix[r].x, CoorMatrix[r].y);
            }
        }
    }

    public void BuildCoordenates()
    {
        CoorMatrix = new Pair[TILENUM];
        float[] CoorHor = new float[ROOMSIZE * 2 - 1];
        float[] CoorVer = new float[ROOMSIZE * 2 - 1];

        for (int i = 0; i < ROOMSIZE; i++)
        {
            CoorHor[ROOMSIZE - 1 - i] = -(TILESIZE / 2) * i;
            CoorHor[i+ROOMSIZE-1] = (TILESIZE / 2) * i;
        }
        for (int i = 1; i < ROOMSIZE; i++)
        {
            CoorVer[i] = (TILESIZE / 2) * (i);
            CoorVer[2*ROOMSIZE-1-i] = -(TILESIZE / 2) * (i);
        }
        for (int i = 0; i < CoorVer.Length; i++)
        {
            Debug.Log(CoorVer[i]);
        }
        int x = 0;
        int y = 0;
        int c = 1;
        for (int r = 0; r < TILENUM; r++)
        {
            CoorMatrix[r] = new Pair(CoorHor[x], CoorVer[y]);
            if ((x + 1) % ROOMSIZE == 0)
            {
                x = c;
                y = 2*ROOMSIZE - c - 2;
            }
            else
            {
                x++;
                y++;
            }
            if (y == CoorVer.Length - 1)
            {
                y = 0;
            }
            if (x == CoorHor.Length - 1)
            {
                x = 0;
            }
        }
    }

}
