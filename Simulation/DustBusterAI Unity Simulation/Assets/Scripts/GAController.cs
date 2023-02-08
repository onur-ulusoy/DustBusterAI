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

    int order;

    private LineRenderer m_lr;
    private void Awake()
    {
        m_lr = GetComponent<LineRenderer>();
        m_lr.positionCount = m_numberOfCities + 1;
    }
    private void Start()
    {
        var fitness = new TspFitness(m_numberOfCities);
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

        Cities = DrawRandomCities();

        // Starts the genetic algorithm in a separate thread.
        m_gaThread = new Thread(() => m_ga.Start());
        m_gaThread.Start();
    }

    private void OnDestroy()
    {
        // When the script is destroyed we stop the genetic algorithm and abort its thread too.
        m_ga.Stop();
        m_gaThread.Abort();
    }

    System.Collections.Generic.IList<TspCity> DrawRandomCities()
    {
        var cities = ((TspFitness)m_ga.Fitness).Cities;
        for (int i = 0; i < m_numberOfCities; i++)
        {
            int j = Random.Range(-6, 6);
            int k = Random.Range(-6, 6);
            Vector3 randomXZ = PickRandomPointOnPlane();
            var city = cities[i];
            var go = Instantiate(CityPrefab, randomXZ, Quaternion.identity) as GameObject;
            go.name = "City " + i;
            citiesGO.Add(go);
            city.Position = go.transform.position;
            go.GetComponent<CityController>().Data = city;
            go.GetComponentInChildren<TextMesh>().text = i.ToString();
        }
        order = 0;
        target.transform.position = citiesGO[order].transform.position;
        return cities;
    }

    void DrawRoute()
    {
        var c = m_ga.Population.CurrentGeneration.BestChromosome as TspChromosome;

        if (c != null)
        {
            var genes = c.GetGenes();

            for (int i = 0; i < genes.Length; i++)
            {
                m_lr.SetPosition(i, citiesGO[i].transform.position);
            }

            var firstCity = Cities[(int)genes[0].Value];
            m_lr.SetPosition(m_numberOfCities, firstCity.Position);
        }
    }

    public void Reset()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(0);
    }

    private void Update()
    {
        DrawRoute();

        if (order < m_numberOfCities)
        {
            if (Mathf.Abs(robot.transform.position.x - target.transform.position.x) < 0.1 && Mathf.Abs(robot.transform.position.z - target.transform.position.z) < 0.1)
            {
                citiesGO[order].GetComponentInChildren<TextMesh>().color = Color.green;
                order++;
                if (order < m_numberOfCities)
                    target.transform.position = citiesGO[order].transform.position;
            }
        }
        
    }

    private Vector3 PickRandomPointOnPlane()
    {
        Vector3 planeSize = plane.GetComponent<Renderer>().bounds.size;
        Vector3 planePosition = plane.transform.position;

        float planeWidth = planeSize.x;
        float planeHeight = planeSize.z;

        float randomX = Random.Range(-planeWidth / 2, planeWidth / 2) + planePosition.x;
        float randomZ = Random.Range(-planeHeight / 2, planeHeight / 2) + planePosition.z;
        return new Vector3(randomX, 2.08f, randomZ);
    }
}