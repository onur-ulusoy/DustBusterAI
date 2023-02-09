using System.Threading;
using GeneticSharp.Domain;
using GeneticSharp.Domain.Crossovers;
using GeneticSharp.Domain.Mutations;
using GeneticSharp.Domain.Populations;
using GeneticSharp.Domain.Selections;
using GeneticSharp.Domain.Terminations;
using GeneticSharp.Infrastructure.Framework.Threading;
using UnityEngine;
using System.Collections.Generic;
using System.Collections;

public class GAController : MonoBehaviour
{
    private GeneticAlgorithm m_ga;
    private Thread m_gaThread;

    public int m_numberOfCities = 20;
    public Object CityPrefab;

    private System.Collections.Generic.IList<TspCity> Cities;
    public List<GameObject> citiesGO;
    public GameObject target;
    public GameObject robot;
    public GameObject plane;

    private bool m_isEnabled = false;


    private LineRenderer m_lr;
    private void Awake()
    {
        target.transform.position = robot.transform.position;
        m_lr = GetComponent<LineRenderer>();
        m_lr.positionCount = m_numberOfCities + 1;
    }
    private void Start()
    {
        var fitness = new TspFitness(m_numberOfCities, plane, robot);
        var chromosome = new TspChromosome(m_numberOfCities);

        // This operators are classic genetic algorithm operators that lead to a good solution on TSP,
        // but you can try others combinations and see what result you get.
        var crossover = new OrderedCrossover();
        var mutation = new ReverseSequenceMutation();
        var selection = new RouletteWheelSelection();
        var population = new Population(50, 100, chromosome);

        m_ga = new GeneticAlgorithm(population, fitness, selection, crossover, mutation);
        m_ga.Termination = new TimeEvolvingTermination(System.TimeSpan.FromHours(1));

        // The fitness evaluation of whole population will be running on parallel.
        m_ga.TaskExecutor = new ParallelTaskExecutor
        {
            MinThreads = 100,
            MaxThreads = 200
        };

        // Everty time a generation ends, we log the best solution.
        m_ga.GenerationRan += delegate
        {
            var distance = ((TspChromosome)m_ga.BestChromosome).Distance;
            //Debug.Log($"Generation: {m_ga.GenerationsNumber} - Distance: ${distance}");
        };

        //Cities = DrawCities();
        DrawCities();

        // Starts the genetic algorithm in a separate thread.
        try
        {
            m_gaThread = new Thread(() => m_ga.Start());
            m_gaThread.Start();
            //StartCoroutine(LateStart(0f));
            StartCoroutine(LateStart(0.2f));
            
        }

        catch
        {
            ;
        }
        

    }
    IEnumerator LateStart(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        DrawRoute();
        m_isEnabled = true;
        target.transform.position = citiesGO[0].transform.position;
    }
    private void OnDestroy()
    {
        // When the script is destroyed we stop the genetic algorithm and abort its thread too.
        m_ga.Stop();
        m_gaThread.Abort();
    }


    void DrawCities()
    {
        var cities = ((TspFitness)m_ga.Fitness).Cities;

        for (int i = 0; i < m_numberOfCities; i++)
        {
            var city = cities[i];
            var go = Instantiate(CityPrefab, city.Position, Quaternion.identity) as GameObject;
            citiesGO.Add(go);
            go.GetComponent<CityController>().Data = city;
            city.go = go;
            //go.GetComponentInChildren<TextMesh>().text = i.ToString();
            go.name = "City " + i;
        }

    }

    TspCity prevCity;
    List<TspCity> orderedCities;
    public void DrawRoute()
    {
        prevCity = new TspCity
        {
            next = null
        };
        var c = m_ga.Population.CurrentGeneration.BestChromosome as TspChromosome;

        if (c != null)
        {
            var genes = c.GetGenes();
            var cities = ((TspFitness)m_ga.Fitness).Cities;
            orderedCities = new List<TspCity>();

            for (int i = 0; i < genes.Length; i++)
            {
                var city = cities[(int)genes[i].Value];
                city.prev = prevCity;

                city.next = (i == genes.Length - 1) ? cities[(int)genes[0].Value] : new TspCity();

                m_lr.SetPosition(i, city.Position);
                city.Order = i;
                city.go.GetComponentInChildren<TextMesh>().text = city.Order.ToString();
                prevCity.next = city;
                prevCity = city;
            }

            var initialCity = cities[0];
            
            initialCity.Order = 0;
            initialCity.go.GetComponentInChildren<TextMesh>().text = initialCity.Order.ToString();
            orderedCities.Add(initialCity);
            var iter = initialCity.next;


            int order = 1;
            while (order < m_numberOfCities)
            {
                iter.Order = order++;
                iter.go.GetComponentInChildren<TextMesh>().text = iter.Order.ToString();
                orderedCities.Add(iter);
                iter = iter.next;
            }

               

            var firstCity = cities[(int)genes[0].Value];
            m_lr.SetPosition(m_numberOfCities, firstCity.Position);




        }
    }

    public void Reset()
    {
        Debug.ClearDeveloperConsole();
        order = 0;
        UnityEngine.SceneManagement.SceneManager.LoadScene(0);
    }

    int order = 0;
    private void Update()
    {
        //DrawRoute();
        if (m_isEnabled)
        {
            if (order < m_numberOfCities)
            {
                if (Mathf.Abs(robot.transform.position.x - target.transform.position.x) < 0.1 && Mathf.Abs(robot.transform.position.z - target.transform.position.z) < 0.1)
                {
                    try {
                        orderedCities[order].go.GetComponentInChildren<TextMesh>().color = Color.green;
                        order++;
                        if (order < m_numberOfCities)
                            target.transform.position = orderedCities[order].go.transform.position;
                    }

                    catch
                    {
                        DrawRoute();
                    }
                    
                }
            }
        }
    }

}