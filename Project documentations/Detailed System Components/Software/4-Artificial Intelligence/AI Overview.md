# Artificial Intelligence

Artificial Intelligence (AI) is a technology discipline designed to enable computers and software to perform specific tasks automatically and intelligently. It typically includes capabilities such as data analysis, learning (both supervised and unsupervised), perception, and generating responses. AI is widely used in robotics due to its ability to perform automatic decision-making, problem-solving, and complex analyses.

## AI and Navigation

In robotics, artificial intelligence is often utilized in automatic navigation and adaptive decision-making processes. The robot typically analyzes a map, perceives its surroundings, makes decisions, and moves based on those decisions. This process often involves environment perception, situation analysis, path planning, and action selection stages. The advanced AI developed in this stage encompasses the fundamental decision-making processes of the robot and will be further enhanced in future versions.

In our project, the robot discretizes the traversable map created by the Cartographer package at each stage within a certain sampling rate and generates waypoints. This enables the robot to perceive its surroundings more easily and effectively and gain a better understanding of its environment. This scenario often transforms into an optimization problem known as the Traveling Salesman Problem (TSP).

## Genetic Algorithm and TSP

Genetic algorithms are artificial intelligence control techniques inspired by evolutionary biology that attempt to find optimal or approximate solutions by searching among a set of possible solutions. Genetic algorithms commonly employ operations known as selection, crossover, and mutation. TSP is typically solved using genetic algorithms because this approach can effectively search within large solution spaces and approximate a global optimum.

In our project, the robot determines the best path using a genetic algorithm. This process involves a series of iterations, with each iteration helping the robot find a more efficient path. Additionally, the robot avoids revisiting an area it has already traveled to, making the navigation process more efficient.

This approach allows the robot to perceive its environment, evaluate situations, and adapt to various circumstances. It enables the robot to develop more general, flexible, and efficient strategies to cope with different situations.

## Selection of Genetic Algorithm

The main reason for using a genetic algorithm is its ability to adapt to any environment and its generalization capability. Other artificial intelligence methods, such as machine learning, often perform learning and modeling for specific situations or environments. These methods are usually most effective when continuously operating in a specific environment. However, we want our robot to adapt to any environment and situation, so we prefer to develop and utilize a genetic algorithm. This algorithm provides a more flexible solution for finding general solutions for various environments and situations.

A genetic algorithm attempts to find global or approximate optimal solutions by searching through solutions. It does not rely on pre-learned information specific to a particular environment or situation, making the genetic algorithm capable of creating more flexible and adaptable solutions for various situations and environments.

However, in addition to the genetic algorithm, we also consider using machine learning in the future, particularly to find faster and more efficient solutions for specific environments and situations. By combining the generalization capability of the genetic algorithm with the learning capability of machine learning, we may obtain more efficient solutions for a wider range of situations and environments. However, this requires the learning and modeling of specific environments and situations and may not be effective in new environments that are not specific to our current environment. Therefore, we need to carefully evaluate this balance between the genetic algorithm and machine learning and determine which method is most effective for a particular situation or environment.
