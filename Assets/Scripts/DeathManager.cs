using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class DeathManager : MonoBehaviour
{
    public CharacterMovement characterMovement;
    private int[] Distract;
    private int[] Eletricity;
    private int[] Water;
    private int[] Temperature;
    private int[] TV;
    private int[] Light;
    private int[] Music;

    public TMP_Text deathtextbox;
    public Sprite dead;

    // Start is called before the first frame update
    void Start()
    {
        Distract = new int[3];
        Eletricity = new int[3];
        Water = new int[3];
        Temperature = new int[3];
        TV = new int[3];
        Light = new int[3];
        Music = new int[3];
        characterMovement = GameObject.FindGameObjectsWithTag("character")[0].GetComponent<CharacterMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        int i = GetRoom() - 1;

        //Debug.Log("[ROOM " + i + "] Distract:" + Distract[i] + " Eletricity:" + Eletricity[i] + " Water:" + Water[i] + " Temperature:" + Temperature[i] + " TV:" + TV[i] + " Light:" + Light[i] + " Music:" + Music[i] + "");

        if (Water[i] >= 1 && Distract[i] >= 1)
        {
            SlipperyDeath();
        }
        if (Temperature[i] >= 3)
        {
            TemperatureDeath();
        }
        if (TV[i] >= 1 && Light[i] >= 1 && Music[i] >= 1)
        {
            TVDeath();
        }
    }

    public void Environment(List<Quality> qualities, int room)
    {
        foreach (Quality quality in qualities)
        {
            switch (quality)
            {
                case Quality.Distract:
                    Distract[0]++;
                    Distract[1]++;
                    Distract[2]++;
                    break;

                case Quality.Electricity:
                    Eletricity[room - 1]++;
                    break;

                case Quality.Water:
                    Water[room - 1]++;
                    break;
                case Quality.Temperature:
                    Temperature[room - 1]++;
                    break;
                case Quality.TV:
                    TV[room - 1]++;
                    break;
                case Quality.Light:
                    Light[room - 1]++;
                    break;
                case Quality.Music:
                    Music[room - 1]++;
                    break;
            }
        }
    }

    public void EnvironmentRemove(List<Quality> qualities, int room)
    {
        foreach (Quality quality in qualities)
        {
            switch (quality)
            {
                case Quality.Distract:
                    Distract[0]--;
                    Distract[1]--;
                    Distract[2]--;
                    break;

                case Quality.Electricity:
                    Eletricity[room - 1]--;
                    break;

                case Quality.Water:
                    Water[room - 1]--;
                    break;
                case Quality.Temperature:
                    Temperature[room - 1]--;
                    break;
                case Quality.TV:
                    TV[room - 1]--;
                    break;
                case Quality.Light:
                    Light[room - 1]--;
                    break;
                case Quality.Music:
                    Music[room - 1]--;
                    break;
            }
        }
    }

    public int GetRoom()
    {
        int r = characterMovement.position.x;
        int l = characterMovement.position.y;
        if (l < 7)
        {
            return 1;
        }
        else if (r > 17 - 8)
        {
            return 3;
        }
        else return 2;
    }

    public void ElectricityDeath()
    {
        //deathtextbox.text = "There's too many things on!! Bzzzzzz Bzzzzzzz";
        Die();
    }
    public void SlipperyDeath()
    {
        //deathtextbox.text = "Oh no! I got distracted and didn't notice this very wet floor! AAAAAHHHHH";
        Die();
    }
    public void TemperatureDeath()
    {
        //deathtextbox.text = "So cold... Brrrrr... Goodbye world...";
        Die();
    }
    public void TVDeath()
    {
        //deathtextbox.text = "So scary! My heart!";
        Die();
    }
    public void PlantDeath()
    {
        //deathtextbox.text = "DON'T EAT ME! AHHHHH";
        Die();
    }
    public void BathDeath()
    {
        //deathtextbox.text = "No stair? Guess I die";
        Die();
    }
    public void Die()
    {
        Debug.Log("Faleceu");
        StartCoroutine(ExampleCoroutine());
        characterMovement.stop = true;
        GameObject.FindGameObjectsWithTag("child")[0].GetComponent<SpriteRenderer>().sprite = dead;
        GameObject.FindGameObjectsWithTag("child")[0].GetComponent<Animator>().enabled = false;
    }
    IEnumerator ExampleCoroutine()
    {
        yield return new WaitForSeconds(7);
        SceneManager.LoadScene("MainScene");
    }
}
