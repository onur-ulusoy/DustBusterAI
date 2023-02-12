# Simulation
Before investing resources into building a physical prototype of a robot, it's crucial to validate the underlying algorithms that will govern its behavior. This involves simulating the robot's movements and interactions with the environment to verify that the algorithms are functioning as intended. Unity, a popular game engine and simulation platform, provides a powerful toolset for creating these simulations. By building a virtual prototype in Unity, developers can test and refine the algorithms that will ultimately drive the physical robot's behavior, without the risks and expenses associated with building and testing a physical prototype. This can help to identify and resolve potential issues early on in the development process, ensuring that the final product is as efficient and effective as possible. Once the algorithms have been thoroughly tested and optimized in the Unity simulation, developers can confidently move forward with building the physical robot.
## Unity Simulation Stages
At each stage of development, the code may receive various changes, optimizations, and improvements. As the algorithm becomes more refined, it may go through iterations of testing and debugging to ensure its accuracy and efficiency. These stages may involve input from multiple team members, including developers, designers, and quality assurance personnel. Ultimately, the goal is to create a robust and reliable algorithm that can perform its intended task with minimal errors and maximum efficiency. Through a well-planned and executed development process, the code can evolve into a powerful tool that can make a significant impact on the intended users and stakeholders.

- [Stage 1](#stage-1)
- [Stage 2](#stage-2)
- [Stage 3](#stage-3)
- [Stage 4](#stage-4)

It is continued to develop simulation stages.

## Stage 1
In the first stage of our project, we are focused on finding the most efficient path between two points. To accomplish this, we have chosen to use the A* algorithm, a popular pathfinding algorithm commonly used in robotics and game development. The A* algorithm works by evaluating potential paths based on a combination of the distance to the goal and an estimate of the remaining distance. This heuristic approach allows the algorithm to prioritize paths that are both short and promising, resulting in faster and more efficient pathfinding.

To apply the A* algorithm, we first define the problem as a graph, with nodes representing the possible locations the robot can move to, and edges representing the connections between those locations. We then use the algorithm to search this graph, evaluating potential paths and selecting the most promising one. This process is repeated until the algorithm has found the optimal path between the two points.

While the A* algorithm is a well-established pathfinding approach, there are still many considerations and decisions that must be made in its implementation. For example, we must decide on a suitable heuristic function, choose an appropriate data structure to represent the graph, and consider any obstacles or constraints that may impact the robot's movement. With careful planning and implementation, however, the A* algorithm can be a powerful tool for finding efficient paths in a wide range of applications.

https://user-images.githubusercontent.com/95442568/218341805-e407c6ba-9822-4ce0-ae93-5c523d458c80.mp4

## Stage 2

In the second stage of our project, we are focused on determining the optimal path for a robot to traverse a set of locations. To accomplish this, we have chosen to use the Traveling Salesman Problem (TSP) algorithm, a well-known optimization algorithm that seeks to find the shortest possible route that visits all the given locations.

The TSP algorithm works by first creating a complete graph with nodes representing each of the locations and edges representing the distances between them. The algorithm then searches through all possible permutations of the nodes, evaluating the total distance of each path and selecting the one with the shortest distance as the optimal path.

While the TSP algorithm can be computationally expensive, there are several techniques and heuristics that can be used to make the optimization process more efficient. For example, we can use approximation algorithms to quickly identify promising paths or incorporate constraints such as time windows or capacity limits into the optimization process.

By using the TSP algorithm in the second stage of our project, we can determine the most efficient order in which a robot should visit the set of locations, minimizing the total distance traveled and maximizing the robot's productivity. This can have a significant impact on the overall performance and efficiency of the robot, enabling it to complete tasks more quickly and with less wasted time and energy.

https://user-images.githubusercontent.com/95442568/218341971-a5bad637-7aa1-437e-b50a-78f03a2e0828.mp4

## Stage 3

In the third stage of our project, we are focused on integrating the A* algorithm and the TSP algorithm to create a more powerful optimization solution. By combining these two algorithms, we can take advantage of their complementary strengths to create an even more efficient and effective pathfinding system.

To integrate the A* algorithm into the TSP algorithm, we first use the A* algorithm to find the shortest path between each pair of locations. We then use these distances to build a distance matrix, which we can use as input to the TSP algorithm. By incorporating the A* algorithm's ability to quickly find the shortest path between two points, we can significantly reduce the search space of the TSP algorithm, making it more efficient and effective.

Additionally, we can use the A* algorithm to help guide the optimization process by identifying and prioritizing key locations that are critical to the overall success of the robot's mission. By emphasizing these locations in the TSP optimization, we can ensure that the robot is spending the majority of its time and resources on the most important tasks.

Through the integration of the A* algorithm and the TSP algorithm, we can create a powerful pathfinding system that is capable of efficiently and effectively optimizing the robot's path through a set of locations. This can have a significant impact on the robot's overall performance, enabling it to complete tasks more quickly and with greater precision.

https://user-images.githubusercontent.com/95442568/218342097-bc9af08e-f666-4a49-8c68-78c8f171b612.mp4

## Stage 4

In the fourth stage of our project, we have focused on discretizing the area in which the robot will operate. Discretization involves dividing the continuous space into a finite number of discrete points, which can be designated as targets for the robot to visit. By discretizing the area, we can simplify the pathfinding problem and make it more computationally efficient.

Initially, we have used a plane to discretize the area in which the robot will operate, but in the future, we plan to extend this to cover all walkable areas. This will involve mapping out the boundaries of the walkable area and using algorithms to identify the optimal placement of discrete points within this area.

The advantage of discretizing the area is that it enables us to plan the robot's path more effectively. Rather than having to search through an infinite number of possible paths, we can limit our search to a finite set of discrete points. This can reduce the computational resources required for pathfinding and make the process faster and more efficient.

Furthermore, by designating specific targets for the robot to visit, we can ensure that it is completing the tasks that are most critical to the mission. We can also use the discretized points to create a more detailed map of the area, which can be used for navigation and tracking purposes.

Overall, by discretizing the area in which the robot operates, we can create a more efficient and effective pathfinding system that is better suited to the robot's capabilities and limitations.

https://user-images.githubusercontent.com/95442568/218342408-01527365-9dfb-44d2-ae56-826d1409f608.mp4

