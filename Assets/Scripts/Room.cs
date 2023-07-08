using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Room : MonoBehaviour
{
    private Furniture[,] Matrix;
    private Pair[] CoorMatrix;
    public int TILENUM;
    public float TILESIZE;
    public int ROOMSIZE;

    public Pair[] WallList;

    public GameObject EmptySpace;
    public GameObject Wall;

    public void Start()
    {
        BuildCoordenates();
        BuildRoom();
    }

    public Furniture[,] getMatrix()
    {
        return Matrix;
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
        for (int i = 0; i < WallList.Length; i++)
        {
            int x = (int)WallList[i].x;
            int y = (int)WallList[i].y;
            Matrix[x, y] = Instantiate(Wall).GetComponent<Furniture>();
            Matrix[x, y].Build(true, CoorMatrix[ROOMSIZE * x + y].x, CoorMatrix[ROOMSIZE * x + y].y);
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

        int ra = 3, la = 7;
        Matrix[ra, la] = Instantiate(EmptySpace).GetComponent<Furniture>();
        Matrix[ra, la].Build(true, CoorMatrix[ROOMSIZE * ra + la].x, CoorMatrix[ROOMSIZE * ra + la].y);

        ra = 9; la = 13;
        Matrix[ra, la] = Instantiate(EmptySpace).GetComponent<Furniture>();
        Matrix[ra, la].Build(true, CoorMatrix[ROOMSIZE * ra + la].x, CoorMatrix[ROOMSIZE * ra + la].y);
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
}
