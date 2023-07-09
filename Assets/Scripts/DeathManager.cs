using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class DeathManager : MonoBehaviour
{
    public CharacterMovement characterMovement;
    private int[] Distract;
    private int[] Eletricity;
    private int[] Water;
    private int[] Temperature;
    private bool[] TV;
    private bool[] Light;
    private bool[] Music;

    public TMP_Text deathtextbox;

    // Start is called before the first frame update
    void Start()
    {
        Distract = new int[3];
        Eletricity = new int[3];
        Water = new int[3];
        Temperature = new int[3];
        TV = new bool[3];
        Light = new bool[3];
        Music = new bool[3];
        characterMovement = GameObject.FindGameObjectsWithTag("character")[0].GetComponent<CharacterMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        int i = GetRoom() - 1;
        if (Water[i] >= 1 && Distract[i] >= 1)
        {
            SlipperyDeath();
        }
        if (Temperature[i] >= 1)
        {
            TemperatureDeath();
        }
        if (TV[i] && Light[i] && Music[i])
        {
            TVDeath();
        }
    }

    public void Environment(List<Quality> qualities)
    {
        int room = GetRoom();
        foreach (Quality quality in qualities)
        {
            switch (quality)
            {
                case Quality.Distract:
                    Distract[room - 1]++;
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
                    TV[room - 1] = true;
                    break;
                case Quality.Light:
                    Light[room - 1] = true;
                    break;
                case Quality.Music:
                    Music[room - 1] = true;
                    break;
            }
        }
    }

    public void EnvironmentRemove(List<Quality> qualities)
    {
        int room = GetRoom();
        foreach (Quality quality in qualities)
        {
            switch (quality)
            {
                case Quality.Distract:
                    Distract[room - 1]--;
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
                    TV[room - 1] = false;
                    break;
                case Quality.Light:
                    Light[room - 1] = false;
                    break;
                case Quality.Music:
                    Music[room - 1] = false;
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
        deathtextbox.text = "There's too many things on!! Bzzzzzz Bzzzzzzz";
        Die();
    }
    public void SlipperyDeath()
    {
        deathtextbox.text = "Oh no! I got distracted and didn't notice this very wet floor! AAAAAHHHHH";
        Die();
    }
    public void TemperatureDeath()
    {
        deathtextbox.text = "So cold... Brrrrr... Goodbye world...";
        Die();
    }
    public void TVDeath()
    {
        deathtextbox.text = "So scary! My heart!";
        Die();
    }
    public void PlantDeath()
    {
        deathtextbox.text = "DON'T EAT ME! AHHHHH";
        Die();
    }
    public void BathDeath()
    {
        deathtextbox.text = "No stair? Guess I die";
        Die();
    }
    public void Die()
    {
        ExampleCoroutine();
    }
    IEnumerator ExampleCoroutine()
    {
        yield return new WaitForSeconds(7);
        SceneManager.LoadScene("MainScene");

    }
}
