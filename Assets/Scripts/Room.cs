using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Room : MonoBehaviour
{
    public int TILENUM;
    public float TILEVER;
    public float TILEHOR;
    public int ROOMSIZE;
    private Furniture[,] Matrix;
    private Pair[] CoorMatrix;

    public GameObject EmptySpace;
    public GameObject Wall;

    public void Start()
    {
        BuildCoordenates();
        BuildRoom();
    }
    public void BuildRoom()
    {
        Matrix = new Furniture[ROOMSIZE, ROOMSIZE];

        for (int r = ROOMSIZE - 10; r < ROOMSIZE; r++)
        {
            for (int l = 0; l < 10; l++)
            {
                Matrix[r, l] = Instantiate(Wall).GetComponent<Furniture>();
                Matrix[r, l].Build(true, CoorMatrix[ROOMSIZE * r + l].x, CoorMatrix[ROOMSIZE * r + l].y);
            }
        }
        for (int l = 0; l < ROOMSIZE; l++)
        {
            int r = ROOMSIZE - 8;
            Matrix[r, l] = Instantiate(Wall).GetComponent<Furniture>();
            Matrix[r, l].Build(true, CoorMatrix[ROOMSIZE * r + l].x, CoorMatrix[ROOMSIZE * r + l].y);
        }
        for (int r = 0; r < ROOMSIZE; r++)
        {
            int l = 7;
            Matrix[r, l] = Instantiate(Wall).GetComponent<Furniture>();
            Matrix[r, l].Build(true, CoorMatrix[ROOMSIZE * r + l].x, CoorMatrix[ROOMSIZE * r + l].y);
        }

        for (int r = 0; r < ROOMSIZE; r++)
        {
            for (int l = 0; l < ROOMSIZE; l++)
            {
                if (Matrix[r, l] is null)
                {
                    Matrix[r, l] = Instantiate(EmptySpace).GetComponent<Furniture>();
                    Matrix[r, l].Build(true, CoorMatrix[ROOMSIZE * r + l].x, CoorMatrix[ROOMSIZE * r + l].y);
                }
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
            CoorHor[ROOMSIZE - 1 - i] = -(TILEHOR / 2) * i;
            CoorHor[i+ROOMSIZE-1] = (TILEHOR / 2) * i;
        }
        for (int i = 1; i < ROOMSIZE; i++)
        {
            CoorVer[i] = (TILEVER / 2) * (i);
            CoorVer[2*ROOMSIZE-1-i] = -(TILEVER / 2) * (i);
        }

        int x = 0;
        int y = 0;
        int c = 1;
        for (int r = 0; r < TILENUM; r++)
        {
            CoorMatrix[r] = new Pair(CoorHor[x], CoorVer[y]);
            if ((r + 1) % ROOMSIZE == 0)
            {
                x = c;
                y = 2*ROOMSIZE - c - 1;
                c++;
            }
            else
            {
                x++;
                y++;
            }
            if (y == CoorVer.Length)
            {
                y = 0;
            }
            if (x == CoorHor.Length)
            {
                x = 0;
            }
        }
    }

    public int GetRoom(int r, int l)
    {
        if (l < 7)
        {
            return 1;
        }
        else if (r > ROOMSIZE - 8)
        {
            return 3;
        }
        else return 2;
    }

    public void BuildModeOn()
    {
        for (int r = 0; r < ROOMSIZE; r++)
        {
            if (Matrix[r, ROOMSIZE-1] is EmptySpace)
            {
                Matrix[r, ROOMSIZE-1].TurnOn();
            }
        }
        for (int l = 0; l < ROOMSIZE; l++)
        {
            if(Matrix[0,l] is EmptySpace)
            {
                Matrix[0, l].TurnOn();
            }
        }
        for (int l = 0; l < 7; l++)
        {
            if (Matrix[ROOMSIZE-7, l] is EmptySpace && l != 13)
            {
                Matrix[ROOMSIZE-7, l].TurnOn();
            }
        }
        for (int r = 0; r < ROOMSIZE; r++)
        {
            if (Matrix[r, 6] is EmptySpace && r!=3)
            {
                Matrix[r, 6].TurnOn();
            }
        }
    }
}
