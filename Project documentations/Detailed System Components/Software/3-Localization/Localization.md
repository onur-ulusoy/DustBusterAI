# Localization

Localization is the process of determining the position and orientation of a robot with respect to its surrounding world. Localization algorithms utilize position data predictions by filtering them to accurately determine the robot's position and orientation in real-time.

Various data sources can be used for localization, including Global Positioning System (GPS), vision-based sensors, sonar, and LIDAR. While GPS is suitable for outdoor environments, vision-based sensors and other detection technologies are generally more effective in indoor environments. However, since each source has its advantages and limitations, combining multiple data sources usually yields the most effective results.

In DustbusterAI, this version utilizes localization based on odometry and mapping data. Odometry tracks the robot's movement and continuously updates its position and orientation based on this information. Mapping helps the robot understand its surroundings and interact with the world. The combination of these two sources of information allows for a unified and accurate position estimation.

## Impact of Odometry on Localization

Odometry plays a fundamental role in the localization process, which involves determining the robot's own position and orientation relative to its environment. This process includes analyzing data from motion sensors, wheels, and internal mechanics.

Odometry tracks the robot's movements and collects data that determines the dimensions, speed, and direction of these movements. This information is then used to determine the robot's current position and movement direction. In particular, accurately tracking and updating the robot's motion and position is essential for precise navigation.

The data provided by odometry is continuously processed and analyzed by localization algorithms. These algorithms filter and interpret the incoming odometry data with respect to a predefined reference frame to assist in determining the robot's position in real-time. This process enables predicting the robot's position at a specific time, taking into account its movement direction and speed.

## Mapping and Localization

Mapping is another significant factor in determining the robot's position. A robot requires a map to understand and navigate its environment. The mapping process involves collecting environmental data perceived by the robot and transforming this data into a framework, usually a map.

Combining odometry and mapping often leads to more accurate and effective localization. This combination, often referred to as sensor fusion, involves integrating data from multiple sensors to achieve more accurate position estimation. While odometry data tracks the robot's own movement, mapping data provides information about the robot's surroundings. The fusion of these two sources enhances the robot's ability to determine its position and orientation.

<p align="center">
    <img width="300" src="Images/localization-schematic.png" alt="Localization Schematic">
</p>
<p align="center"><em>Localization Schematic</em></p>

TO BE CONT.