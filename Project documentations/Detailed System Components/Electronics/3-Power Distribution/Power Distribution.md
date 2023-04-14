# Power Distribution

## Introduction

Our cleaning robot consists of various components with different voltage and current requirements. Power distribution plays a crucial role in ensuring a continuous and stable power supply to all the robot's components. It involves the distribution of electrical power from the battery to each component.

## Overview

The power distribution system in our robot is responsible for efficiently distributing power to the Raspberry Pi embedded computer, Arduino microcontroller, L298 motor drivers, LIDAR sensor, IMU (Inertial Measurement Unit), and wheel encoders. This ensures that all components receive the necessary power to operate effectively.

Since there is no specialized power distribution board available at the moment, we have implemented an alternative solution during the prototyping stage. The main power line from the battery output is divided into three separate branches using soldered wires connected to each other and a conductive plate. 

Power distribution ensures that each component receives the appropriate voltage and current to operate efficiently and reliably. It is a critical aspect of the robot's overall functionality and performance.

## Future Plans

In the future, we plan to develop a dedicated power distribution board to optimize power management, provide precise voltage and current delivery to each component, and enhance safety and stability. This improvement will allow us to fine-tune the power distribution configuration and ensure consistent and reliable operation of the robot.

---

**For more detailed information** about the power distribution system, including schematics and component specifications, please refer to our Electronics repository:

[DustBusterAI-Electronics](https://github.com/onur-ulusoy/DustBusterAI-Electronics)
