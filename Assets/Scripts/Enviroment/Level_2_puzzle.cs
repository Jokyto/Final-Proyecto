using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level_2_puzzle : MonoBehaviour
{
    [SerializeField] GameObject[] randomizer_1;
    [SerializeField] GameObject[] randomizer_2;
    [SerializeField] GameObject[] randomizer_3;
    [SerializeField] GameObject[] randomizer_4;
    [SerializeField] GameObject[] puzzle_solution;
    [SerializeField] float randomized = 0;

    private void Start() 
    {
        Random.Range(1,4);
        if (randomized == 1)
        {
            puzzle_solution = randomizer_1; 
        }

        if (randomized == 2)
        {
            puzzle_solution = randomizer_2;
        }

        if (randomized == 3)
        {
            puzzle_solution = randomizer_3;
        }

        if (randomized == 4)
        {
            puzzle_solution = randomizer_4;
        }
        foreach (GameObject totem in puzzle_solution)
        {
            if (puzzle_solution[0] != totem)
            {
                totem.SetActive(false);
            }
        }
    }

    private void Update() 
    {

    }



}
