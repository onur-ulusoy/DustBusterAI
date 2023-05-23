# Genetic Algorithm
Genetic algorithms are optimization algorithms designed to simulate the natural evolutionary process. They provide evolutionary solutions to problems and model the solution search process similarly to elements of biological evolution such as genes, individuals, populations, fitness values, and evolutionary mechanisms. The core principle of these algorithms is that solutions with higher fitness values are more likely to be selected and passed onto subsequent generations than solutions with lower fitness values.

## Working of a Genetic Algorithm
A genetic algorithm creates a population of potential solutions to solve a problem. These solutions are typically encoded as binary strings or other data structures. Each solution is considered an "individual", and each individual has a "fitness value". This fitness value indicates how well the individual's solution fits the problem.

The genetic algorithm evolves the population over a series of "generations". In each generation, individuals are selected and "mate" - a process through which they pass their genes to individuals of the next generation. Genetic operators, usually crossover and mutation, are used during this mating process. Crossover is the process of combining genes of two individuals, often occurring through a random point division and swapping of genes. Mutation is the process of making random, minor changes in an individual's genes.

Subsequent generations comprise the fittest individuals from the previous generation and newly formed individuals. The genetic algorithm repeats this process until a particular stopping criterion (for example, a certain number of generations or a specific fitness value) is met.


<p align="center">
    <img width="600" src="Images/genetic-unity.gif" alt="TSP Problem Solved by Genetic Algorithm Visualized in Unity Platform">
</p>
<p align="center"><em>TSP Problem Solved by Genetic Algorithm Visualized in Unity Platform</em></p>

## Limitations of Genetic Algorithms
Despite numerous strengths, genetic algorithms also come with a number of challenges and limitations. Firstly, the performance of genetic algorithms is often sensitive to the choice of specific parameters (population size, crossover and mutation rates, etc.). Proper tuning of these parameters can greatly affect the effectiveness and performance of the algorithm. However, determining the optimal values for these parameters is usually difficult and often done by trial and error. Hence, adopting an adaptive control technique for these parameters is planned for future versions.

