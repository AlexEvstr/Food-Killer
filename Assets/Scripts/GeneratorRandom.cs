using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static GeneratorRandom;

public class GeneratorRandom : MonoBehaviour
{
    #region Data
    public WaveData[] waveDatas;
    private FoodFactory _foodFactory;
    private BombFactory _bombFactory;
    public AudioSource foodSpawnSound;
    private int _spawnInterval = 3;
    private int index;
    private int lastindex;

    #endregion



    public void Start()
    {
        _foodFactory = GetComponent<FoodFactory>();
        _bombFactory = GetComponent<BombFactory>();

        waveDatas = new WaveData[21];
        waveDatas[0] = new WaveData() { CountFruit = 1, CountBomb = 0, SleepForSpawn = 1 };
        waveDatas[1] = new WaveData() { CountFruit = 2, CountBomb = 0, SleepForSpawn = 1 };
        waveDatas[2] = new WaveData() { CountFruit = 3, CountBomb = 0, SleepForSpawn = 1 };
        waveDatas[3] = new WaveData() { CountFruit = 4, CountBomb = 0, SleepForSpawn = 1 };
        waveDatas[4] = new WaveData() { CountFruit = 3, CountBomb = 0, SleepForSpawn = 0.5f };
        waveDatas[5] = new WaveData() { CountFruit = 4, CountBomb = 0, SleepForSpawn = 0.5f };
        waveDatas[6] = new WaveData() { CountFruit = 0, CountBomb = 1, SleepForSpawn = 1 };
        waveDatas[7] = new WaveData() { CountFruit = 0, CountBomb = 2, SleepForSpawn = 1 };
        waveDatas[8] = new WaveData() { CountFruit = 0, CountBomb = 3, SleepForSpawn = 1 };
        waveDatas[9] = new WaveData() { CountFruit = 0, CountBomb = 2, SleepForSpawn = 0.5f };
        waveDatas[10] = new WaveData() { CountFruit = 0, CountBomb = 3, SleepForSpawn = 0.5f };
        waveDatas[11] = new WaveData() { CountFruit = 0, CountBomb = 4, SleepForSpawn = 0.5f };
        waveDatas[12] = new WaveData() { CountFruit = 0, CountBomb = 5, SleepForSpawn = 0.5f };
        waveDatas[13] = new WaveData() { CountFruit = 1, CountBomb = 1, SleepForSpawn = 1 };
        waveDatas[14] = new WaveData() { CountFruit = 2, CountBomb = 2, SleepForSpawn = 1 };
        waveDatas[15] = new WaveData() { CountFruit = 3, CountBomb = 3, SleepForSpawn = 1 };
        waveDatas[16] = new WaveData() { CountFruit = 4, CountBomb = 1, SleepForSpawn = 1 };
        waveDatas[17] = new WaveData() { CountFruit = 1, CountBomb = 1, SleepForSpawn = 0.5f };
        waveDatas[18] = new WaveData() { CountFruit = 2, CountBomb = 2, SleepForSpawn = 0.5f };
        waveDatas[19] = new WaveData() { CountFruit = 3, CountBomb = 3, SleepForSpawn = 0.5f };
        waveDatas[20] = new WaveData() { CountFruit = 4, CountBomb = 4, SleepForSpawn = 0.5f };

        StartCoroutine(Generator());
    }

    private IEnumerator Generator()
    {
        WaitForSeconds waitForSeconds = new WaitForSeconds(_spawnInterval);
        while (true)
        {
           
            int newindexgen()
            {
                index = Random.Range(0, waveDatas.Length);
                if (index != lastindex)
                {
                    lastindex = index;
                    return index;
                }
                else
                {
                    return newindexgen();
                }
            }
            WaveData currentWave = waveDatas[newindexgen()];
            int countAllElementsInWave = currentWave.CountFruit + currentWave.CountBomb;
            bool isFruit = true;
            Debug.Log(index);
            for (int i = 0; i < countAllElementsInWave; i++)
            {
                if (currentWave.CountFruit > 0 && (isFruit == true || currentWave.CountBomb == 0))
                {
                    CreateFruit();
                    foodSpawnSound.Play();
                    currentWave.CountFruit--;
                    isFruit = false;
                    
                }
                else if (currentWave.CountBomb > 0)
                {
                    CreateBomb();
                    foodSpawnSound.Play();
                    currentWave.CountBomb--;
                    isFruit = true;
                }
                
                yield return new WaitForSeconds(currentWave.SleepForSpawn);

            }
            yield return waitForSeconds;
        }
    }

    public void CreateFruit()
    {
        int i = Random.Range(0, 3);

            if (i == 0)
            {
                var foodSmall = _foodFactory.CreateSmall();
                foodSmall.transform.position = new Vector2(Random.Range(-3, 3), Random.Range(1, 2));
                foodSmall.transform.SetParent(transform);
               
            }
            else if (i == 1)
            {
                var foodNormal = _foodFactory.CreateNormal();
                foodNormal.transform.position = new Vector2(Random.Range(-3, 3), Random.Range(1, 2));
                foodNormal.transform.SetParent(transform);
                
            }
            else if (i == 2)
            {
                var foodBig = _foodFactory.CreateBig();
                foodBig.transform.position = new Vector2(Random.Range(-3, 3), Random.Range(1, 2));
                foodBig.transform.SetParent(transform);
                
            }   
    }

    public void CreateBomb()
    {
        int i = Random.Range(0, 3);

        if (i == 0)
        {
            var bombSmall = _bombFactory.CreateBombSmall();
            bombSmall.transform.position = new Vector2(Random.Range(-3, 3), Random.Range(1, 2));
            bombSmall.transform.SetParent(transform);

        }
        else if (i == 1)
        {
            var bombNormal = _bombFactory.CreateBombNormal();
            bombNormal.transform.position = new Vector2(Random.Range(-3, 3), Random.Range(1, 2));
            bombNormal.transform.SetParent(transform);

        }
        else if (i == 2)
        {
            var bombBig = _bombFactory.CreateBombBig();
            bombBig.transform.position = new Vector2(Random.Range(-3, 3), Random.Range(1, 2));
            bombBig.transform.SetParent(transform);

        }
    }

    public struct WaveData
    {
        public int CountFruit;
        public int CountBomb;
        public float SleepForSpawn;

        public WaveData(int countFruit, int countBomb, float sleepForSpawn)
        {
            CountFruit = countFruit;
            CountBomb = countBomb;
            SleepForSpawn = sleepForSpawn;
        }
    }
}

