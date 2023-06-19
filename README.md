# DustBusterAI

<div style="display: flex; align-items: center; justify-content: center;">
    <a href="https://example.com/image1"><img src="Images/tech-used/ros-logo2.png" alt="Image 1" style="margin-right: 20px; width: 200px;"></a>
    <a href="https://example.com/image2"><img src="Images/tech-used/gazebo-logo.png" alt="Image 2" style="width: 100px; margin-right: 32px;"></a>
    <a href="https://example.com/image2"><img src="Images/tech-used/ubuntu-logo.png" alt="Image 2" style="width: 250px;"></a>
</div>
<br clear="both">



<div style="display: flex; align-items: center; justify-content: center;">
    <a href="https://example.com/image1"><img src="Images/tech-used/pi-logo.png" alt="Image 1" style="margin-right: 20px; width: 110px;"></a>
    <a href="https://example.com/image2"><img src="Images/tech-used/arduino-logo.png" alt="Image 2" style="width: 100px;margin-right: 34px; "></a>
    <a href="https://example.com/image1"><img src="Images/tech-used/Unity-Logo.png" alt="Image 1" style="margin-right: 20px; width: 200px;"></a>

</div>
<br clear="both">

---

<div style="display: flex; align-items: center; justify-content: center; margin-top: 30px; margin-bottom: 0px;">
    <a href="https://example.com/image2"><img src="Images/tech-used/evolutionary-robotics-logo2.png" alt="Image 2" style="width: 400px;"></a>
</div>
<br clear="both">

---
<p style="margin-bottom: 1em;"></p>

[![License](https://img.shields.io/badge/License-MIT-green.svg)](LICENSE)
[![ROS2 Version](https://img.shields.io/badge/ROS2-Humble-blue.svg)](https://docs.ros.org/en/rolling/Releases/Release-Humble-Hawksbill.html)
[![Ubuntu Version](https://img.shields.io/badge/Ubuntu-22.04%20Jelly-orange.svg)](https://releases.ubuntu.com/22.04/)
[![Python](https://img.shields.io/badge/Language-Python-yellow.svg)](https://www.python.org/)
[![C++](https://img.shields.io/badge/Language-C%2B%2B-red.svg)](https://en.cppreference.com/)
[![C#](https://img.shields.io/badge/Language-C%23-purple.svg)](https://docs.microsoft.com/en-us/dotnet/csharp/)
[![Unity](https://img.shields.io/badge/Simulation-Unity-green.svg)](https://unity.com/)


## Table of Contents

- [DustBusterAI](#dustbusterai)
  - [Table of Contents](#table-of-contents)
  - [Project Overview](#project-overview)
  - [Autonomous Overview](#autonomous-overview)
    - [Sense](#sense)
    - [Interpret](#interpret)
    - [Plan](#plan)
    - [Navigate](#navigate)
    - [Actuate](#actuate)
    - [Overall](#overall)
  - [Sub-repositories](#sub-repositories)
  - [Project Goals](#project-goals)
  - [Project Team](#project-team)
  - [Technologies Used](#technologies-used)
  - [Project Timeline](#project-timeline)
  - [Project Budget](#project-budget)
  - [Donate](#donate)
  - [Project Challenges](#project-challenges)
  - [Project Status](#project-status)
  - [Pre Simulations](#pre-simulations)
  - [License](#license)
  - [Conclusion](#conclusion)

## Project Overview
DustBuster is an AI-powered full autonomous differential vehicled robot that is designed to clean plain floors in wide areas such as airports in the possible shortest period of time. DustBuster is equipped with advanced path planning, decision-making, and optimal motion control algorithms that enable it to navigate through complex environments while avoiding obstacles. Its powerful electric motors and durable wheels allow it to move quickly and efficiently across large areas, while its integrated cleaning system ensures that every nook and cranny is thoroughly cleaned. Vehicle electronics including hardware, firmwares, and sensor system is designed with efficiency and reliability in mind, as the robot needs to be able to operate for extended periods of time without interruptions. This requires careful power management and fault tolerance design.

DustBusterAI uses the Robot Operating System 2 (ROS2), the well known and effective framework, to implement AI-based cleaning solutions for the robot. It employs simulation and monitoring platforms, Gazebo and RViz, for efficient development. 

In addition to its autonomous capabilities, DustBuster also offers a range of features that make it easy to use and maintain. Its intuitive interface allows operators to monitor its progress and adjust settings as needed, while its modular design makes it easy to replace worn components and perform routine maintenance tasks.

Overall, DustBuster represents a significant advancement in the field of autonomous cleaning robots, offering a powerful, efficient, and user-friendly solution for cleaning large areas quickly and effectively.

## Autonomous Overview

<p align="center">
    <img width="1300" src="Images/Autonomous-Overview.png" alt="Autonomous Overview">
</p>
The autonomous architecture of our DustBuster robot consists of five primary stages: perception, interpretation, planning, and navigation, followed by the actuation or motor drive stage. Detailed documentation of each of these stages can be found in the corresponding project folders and they are summarized below subsections.
<p style="margin-bottom: 1em;"></p>

<p style="margin-bottom: 1em;"></p>

---

<p style="margin-bottom: 1.5em;"></p>
<p align="center">
    <img width="75" src="Images/autonomous-logos/sense.pnG" alt="Autonomous Overview">
</p>

### **Sense**

In the perception or sensing stage, the robot collects data from various sensors. We first employ a 2D Lidar. This sensor utilizes a laser beam within a 240-degree field of view to detect structures in the environment in two dimensions. Next in line are the encoders, which provide information about the vehicle's location by determining the degree of wheel rotation. Finally, the Inertial Measurement Unit (IMU) assists and provides reliability to the other sensors by detecting the vehicle's instant motion.

Raw data obtained is often noisy and may contain outliers or irrelevant information. To ensure the quality and reliability of the data, we employ various filtering techniques to reduce the noise and enhance the valuable information. 

For a deeper dive into DustBuster's sensing mechanisms, please refer to the following resources:

- [Electronics Documentations](/Project%20Documentations/Detailed%20System%20Components/Electronics) offer detailed insights into the sensors and their configurations that enable DustBuster's operation.
- [Electronics Repository](https://github.com/onur-ulusoy/DustBusterAI-Electronics) houses the electronic design files and code that power DustBuster's sensor systems.

<p style="margin-bottom: 1em;"></p>


---

<p style="margin-bottom: 1.5em;"></p>


<p align="center">
    <img width="75" src="Images/autonomous-logos/interpret.png" alt="Autonomous Overview">
</p>


### **Interpret**

The next stage is interpretation. In this stage, the processed sensor data is evaluated to gain an understanding of the robot's environment. This process aim to create environmental awareness for the robot. It answers critical questions like, "Where am I currently located?", "What obstacles are present in my surroundings?", and so on.

We combine sensor data for localization and mapping, thereby obtaining more precise and reliable information. Initially, we determine the vehicle's current position by passing encoder and IMU data through a Kalman filter. We then utilize the Lidar data directly to generate the map.

Sensing & Interpretation stages can be summarized with below schematic.

<p style="margin-bottom: 2em;"></p>


<p align="center">
    <img width="900" src="Images/sensor-processing-line.png" alt="Autonomous Overview">
</p>
<p align="center"><em>Sensing & Interpretation Stages Schematic</em></p>
<p style="margin-bottom: 2em;"></p>

For a comprehensive understanding of the interpretation process, kindly refer to the following detailed documentations:

- [Odometry](/Project%20Documentations/Detailed%20System%20Components/Software/1-Odometry/Odometry.md) provides information on how the robot's current position is computed.
- [Mapping](/Project%20Documentations/Detailed%20System%20Components/Software/2-Mapping/Mapping.md) explains how Lidar data is utilized to generate the map.
- [Localization](/Project%20Documentations/Detailed%20System%20Components/Software/3-Localization/Localization.md) expounds on the combination of sensor data for precise localization.
- [Software Repository](https://github.com/onur-ulusoy/DustBusterAI-Software) provides a broader view of the entire software of autonomous system with the source code.
<p style="margin-bottom: 1em;"></p>

---
<p style="margin-bottom: 1.5em;"></p>

<p align="center">
    <img width="75" src="Images/autonomous-logos/plan.png" alt="Autonomous Overview">
</p>

### **Plan**

We then proceed to the planning stage. Using artificial intelligence algorithms and map data, we determine the general route that the robot will take. The goal here is to find the optimal path that ensures efficiency and safety while achieving the desired cleaning objectives.

We use evolutionary algorithms to determine the optimal path at specified time stamps according to the situation. It can be seen in the below simulation the optimal path determination at the initial state of the robot in Unity platform.

<p style="margin-bottom: 1em;"></p>

<p align="center">
    <img width="600" src="Images/genetic-unity.gif" alt="Route Determined by Genetic Algorithm Visualized in Unity Platform">
</p>
<p align="center"><em>Route Determined by Genetic Algorithm Visualized in Unity Platform</em></p>

- [AI Overview](/Project%20Documentations/Detailed%20System%20Components/Software/4-Artificial%20Intelligence/AI%20Overview.md): An overview of the AI systems in DustBuster.
- [Genetic Algorithm](/Project%20Documentations/Detailed%20System%20Components/Software/4-Artificial%20Intelligence/Genetic%20Algorithm.md): A detailed look into how we utilize genetic algorithms for path planning.
- [Unity Simulation](/Simulations/DustBusterAI%20Unity%20Simulation/): Our simulation environment built on Unity to develop and test evolutionary algorithms.
- [Software Repository](https://github.com/onur-ulusoy/DustBusterAI-Software): Access to the codebase that powers DustBuster's software systems.


<p style="margin-bottom: 1 em;"></p>

---

<p align="center">
    <img width="90" src="Images/autonomous-logos/navigate.png" alt="Autonomous Overview">
</p>

### **Navigate**

Following planning, we reach the navigation stage. Here, the paths to the planned waypoints are generated, producing real-time velocity commands for the robot. This stage ensures the smooth and accurate execution of the planned route, responding dynamically to any changes in the environment.

Below is a video demonstration showcasing how DustBuster operates within an environment that is completely unknown to it initially.

<p style="margin-bottom: 1em;"></p>

<p align="center">
    <img width="1300" src="Images/full-simulation.gif" alt="Demonstration of Route Navigation via Genetic Algorithm in Gazebo Simulation">
</p>
<p align="center"><em>Demonstration of Route Navigation via Genetic Algorithm in Gazebo Simulation</em></p>

For a more thorough understanding of our navigation approach, consider checking out the following resources:

- [Navigation Overview](/Project%20Documentations/Detailed%20System%20Components/Software/5-Navigation/Navigation%20Overview.md): An overview of DustBuster's navigation systems.
- [Navigation Detailed](/Project%20Documentations/Detailed%20System%20Components/Software/5-Navigation/Navigation.md): An in-depth examination of our navigation processes.
- [Software Repository](https://github.com/onur-ulusoy/DustBusterAI-Software): Access to the codebase that powers DustBuster's software systems.
---
<p style="margin-bottom: 1.5em;"></p>


<p align="center">
    <img width="90" src="Images/autonomous-logos/actuate.png" alt="Autonomous Overview">
</p>


### **Actuate**


Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.

<p style="margin-bottom: 1em;"></p>

---

### **Overall**
Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.

<p style="margin-bottom: 1em;"></p>


<p align="center">
    <img width="1200" src="Images/autonomous-schematic.png" alt="General Schematic">
</p>



## Sub-repositories
[DustBusterAI](https://github.com/onurulusoy4/DustBusterAI)
(this) is the main repository of the project and contains general planning, management and visualisation. 

Sub-repositories are,
- [DustBusterAI-Software](https://github.com/onurulusoy4/DustBusterAI-Software)
- [DustBusterAI-Control](https://github.com/onurulusoy4/DustBusterAI-Control)
- [DustBusterAI-Electronics](https://github.com/onurulusoy4/DustBusterAI-Electronics)
- [DustBusterAI-Mechanics](https://github.com/onurulusoy4/DustBusterAI-Software)

## Project Goals
The goals of the DustBusterAI project are:

- To create, optimize and visualize the algorithms in simulation platforms (Unity, Gazebo)
- To make algorithms to run on ROS environment
- To develop and integrate sensors and feedback mechanisms
- To design required hardwares and firmwares
- To find effective cleaning solutions and improve the mechanical design through this way
- To design and build a working prototype of the robot
- To develop a user-friendly interface for monitoring the robot

## Project Team
The DustBusterAI project is being developed by a team of engineering students. The team includes:

- [Onur Ulusoy](https://github.com/onurulusoy4/)
- Kemal Turan
- Efecan Becer

## Technologies Used
The following technologies will be used in the DustbusterAI project:

- Firmware development: C and C++ for programming the embedded systems of the robot
- ROS-based software development: C++, Python for developing the software that runs on the robot's onboard computer
- Simulation and visualization: Unity C# and Gazebo for creating a realistic virtual environment to test the robot's behavior
- Version control: Git for tracking changes and managing collaboration among team members
- Continuous integration and deployment: tools like Jenkins or Travis CI for automating the build, test, and deployment process
- Hardware design: Altium Designer and LTSpice for designing and prototyping the robot's electronic hardware
- Communication protocols: UART, SPI, and I2C for ensuring seamless communication between the various components of the robot. Bluetooth and Wi-Fi is supported for monitoring.
- Structural 3D design and analysis: Utilizing industry-leading software such as Fusion 360 and Catia for comprehensive design, while ANSYS and Abaqus provide advanced analysis capabilities to ensure optimal structural integrity.

## Project Timeline
- Q1 2023: Begin algorithm development and optimization in simulation environments, start designing electronic and mechanical design
- Q2 2023: Integrate sensors and feedback mechanisms, continue algorithm development and optimization in ROS environment, improve mechanical design based on testing results, get manufactured the required hardware and mechanical parts 
- Q3 2023: Complete algorithm development and optimization, design and build a working prototype of the robot, begin development of user-friendly interface for monitoring the robot

- Q4 2023: Finalize user-friendly interface, perform testing and debugging, prepare for potential launch or deployment of the DustBusterAI robot.

## Project Budget

The project budget for DustBusterAI is estimated for the first prototype to be $5000, including costs for materials, components, hardware and firmware development, software development, algorithm optimization, and prototype testing. This budget will be allocated across the different phases of the project according to the timeline outlined above.
## Donate
Donate to Support the DustBusterAI Project.

We are having economic burdens in our country which usually result in the necessary materials or manufacturing fees such as PCB production or 3D printing to be overpriced.
We rely on the support of donors like you to bring the DustBusterAI project to life. Your contribution will help us purchase the necessary equipment and materials to build a working prototype of the robot, as well as fund the development of the necessary software and algorithms to make it run. By donating, you can be a part of revolutionizing the cleaning industry and making our world a cleaner, more efficient place. Thank you for your support!

To donate to our project please contact [Onur Ulusoy](https://www.linkedin.com/in/onurulusoy7/)

## Project Challenges
The DustBusterAI project faces several difficulty, including:

- Lack of funding to the project delays in procuring or manufacturing necessary components and materials
- Difficulty in optimizing the robot's navigation and cleaning algorithms to improve efficiency and effectiveness
- Market competition from other cleaning robots and devices

## Project Status
As of March 25, 2023, the DustBusterAI project is in the design and planning phase. The team is currently working on developing the robot's decision making algorithms and testing using ROS2 framework, in Gazebo and RViz platforms. The project is on track to meet its Q1 2023 deadline for completing the prototype.

## Pre Simulations
Since most of the algorithms are handled by development team, before creating ROS environment or investing resources into building a physical prototype of a robot, it's crucial to validate the underlying algorithms that will govern its behavior. This involves simulating the robot's movements and interactions with the environment to verify that the algorithms are functioning as intended. Unity, a popular game engine and simulation platform, provides a powerful toolset for creating these simulations. By building a virtual prototype in Unity, developers can test and refine the algorithms that will ultimately drive the physical robot's behavior, without the risks and expenses associated with building and testing a physical prototype. This can help to identify and resolve potential issues early on in the development process, ensuring that the final product is as efficient and effective as possible. Once the algorithms have been thoroughly tested and optimized in the Unity simulation, developers can confidently move forward with building the physical robot.

Algorithms first tested in Unity Engine and this is the main repository, not contain much another code, that's why the project is seen as C#.

Current unity simulation status can be checked from [Simulation Stages](https://github.com/onurulusoy4/DustBusterAI/tree/master/Pre-Simulations/DustBusterAI%20Unity%20Simulation)


https://user-images.githubusercontent.com/95442568/222244447-768bc50f-41e9-4a67-80c4-689e2ca3722b.mp4

**Note:** Pre Simulations in Unity Engine is over, we jumped into developing ROS environment using Gazebo and RViz tools. [DustBusterAI-Software](https://github.com/onurulusoy4/DustBusterAI-Software)



## License

All software and hardware designs created for the DustBusterAI project are released under the [MIT License](https://github.com/onurulusoy4/DustBusterAI/blob/master/LICENSE). This includes the source code, CAD files, and any other materials created for the project. You are free to use, modify, and distribute this project for both commercial and non-commercial purposes. However, the authors of this project make no warranties or guarantees as to the reliability, suitability, or accuracy of the materials provided. Use at your own risk.

## Conclusion
The DustbusterAI project is an ambitious undertaking that aims to develop an autonomous robot capable of cleaning a room using path planning, decision making, and motion control algorithms. By leveraging the latest technologies and techniques in robotics, the project hopes to create a robot that can handle different room sizes and shapes, as well as different types of obstacles.



