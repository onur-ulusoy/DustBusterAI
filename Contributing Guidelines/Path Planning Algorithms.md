# Path Planning Algorithms for Autonomous Land Robot Project

## Introduction

This project aims to develop a full autonomous land robot capable of cleaning a room by scanning it with LIDAR and roaming around obstacles. The robot is three-wheeled, with two wheels in the back actuated by DC motors. It will use an IMU and encoders to determine its current location and decide where to go next.

## Path Planning Algorithms

There are several algorithms that can be used for path planning in this project, including:

1. A* Algorithm: A popular algorithm for finding the shortest path between two points in a graph.

2. Rapidly-Exploring Random Trees (RRTs): An algorithm for generating a tree of points in the environment and finding a path from a start location to a goal location.

3. Potential Field Algorithms: An algorithm that uses a potential field to guide the robot towards the goal while avoiding obstacles.

4. Model Predictive Control (MPC): A control algorithm that models the motion of the robot and predicts the outcome of different control inputs, selecting the best control input to execute based on the predictions.

5. Probabilistic Roadmaps (PRMs): An algorithm that generates a roadmap of the environment and finds a path between the start and goal locations by searching the roadmap.

## Integration with Unity

The path planning algorithms can be implemented and integrated with the Unity platform, which provides a flexible and powerful environment for developing simulation and visualization. The Unity scripting API can be used to write the code for the algorithms, and Unity's visualization tools can be used to display the planned path and other information about the robot's motion. The Unity physics engine can also be used to simulate the motion of the robot in the virtual environment.

## Conclusion

This project provides a great opportunity to implement and integrate path planning algorithms with Unity. The algorithms mentioned above can be used to plan a path for the robot to clean the room, and Unity provides a valuable tool for debugging and testing. Implementing and integrating these algorithms may require significant programming and technical expertise, but the result will be a fully autonomous land robot capable of cleaning a room.
