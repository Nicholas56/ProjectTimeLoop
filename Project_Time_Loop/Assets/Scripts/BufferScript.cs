using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
//Nicholas Easterby - EAS12337350
//This script automatically loads the next scene, but allows other scripts to complete their functions at the same time

public class BufferScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        SceneManager.LoadScene("MakeData");
    }
}
