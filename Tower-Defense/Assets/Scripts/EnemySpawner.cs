using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] float secondsBetweenSpawns = 3f;
    [SerializeField] EnemeyMovement enemyPrefab;
    [SerializeField] Transform enemyParentTransform;
    [SerializeField] TextMeshProUGUI spawnerText;
    [SerializeField] AudioClip spawnerSFX;
    

    int enemyCounter;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(EnemySpawn());
        spawnerText.text=enemyCounter.ToString();
    }

    // Update is called once per frame
    

    IEnumerator EnemySpawn()
    {
        while (true)
        {
            EnemyCounter();
            GetComponent<AudioSource>().PlayOneShot(spawnerSFX);

            var enemyInstance = Instantiate(enemyPrefab, transform.position, Quaternion.identity);
            enemyInstance.transform.parent = enemyParentTransform;
            yield return new WaitForSeconds(secondsBetweenSpawns);
        }
    }

    private void EnemyCounter()
    {
        enemyCounter++;
        spawnerText.text = enemyCounter.ToString();
    }
}
