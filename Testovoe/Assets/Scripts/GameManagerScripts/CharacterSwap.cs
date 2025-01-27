using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CharacterSwap : MonoBehaviour
{
    [SerializeField] private List<Transform> possibleCharacters;
    public Transform character;
    private int whichCharacter;

    [SerializeField] private CinemachineVirtualCamera cam;
    
    void Start()
    {
        if(character == null && possibleCharacters.Count >= 1)
        {
            character = possibleCharacters[0];
        }

        Swap();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            if(whichCharacter == 0)
            {
                whichCharacter = possibleCharacters.Count - 1;
            }
            else
            {
                whichCharacter -= 1;
            }

            Swap();

        }

    }

    public void Swap()
    {
        character = possibleCharacters[whichCharacter];
        character.GetComponent<PlayerController>().enabled = true;

        for (int i = 0; i < possibleCharacters.Count; i++)
        {
            if(possibleCharacters[i] != character)
            {
                possibleCharacters[i].GetComponent<PlayerController>().enabled = false;
            }

        }

        cam.LookAt = character;
        cam.Follow = character;

    }

    public void FinishSwap()
    {
        if (whichCharacter == 0)
        {
            whichCharacter = possibleCharacters.Count - 1;
        }
        else
        {
            whichCharacter -= 1;
        }

        Swap();
    }

}
