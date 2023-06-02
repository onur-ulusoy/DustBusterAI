# Navigation

Navigation is the process of moving from a starting point to a target point within obstacles in an effective and safe manner. This process usually consists of a series of sub-processes such as determining the current location, setting the target, planning the route, and moving according to this plan.

## Navigation Use in Robots

In robotics, navigation enables the robot to move effectively in its environment and carry out specific tasks. This is especially important in complex or uncertain environments or situations where a specific route needs to be followed to reach a specific goal. For example, a robot can carry materials to a specific workstation in a factory or clean a specific room in a house. Such situations require the robot to perceive its environment accurately, set its target, plan an effective route, and follow this route.

## Path Planning

Path planning is a navigation method that determines the route of a robot from the starting point to the target point. This is usually done by taking into account obstacles in the robot's environment and observing specific optimization goals such as energy efficiency or travel time. Path planning algorithms often include techniques such as A*, Dijkstra, Rapidly-exploring Random Tree (RRT), and Adaptive Monte Carlo.

## Path Planning Algorithms

A* and Dijkstra are shortest path algorithms that take advantage of mathematical structures based on graph theory. These algorithms determine the shortest path between the nodes of a network (for example, a map).

RRT and Adaptive Monte Carlo are sample-based algorithms. Such algorithms are typically used for more complex or high-dimensional environments such as autonomous driving and aviation, and they also find use in other fields besides robotics.

The foundation of these algorithms usually relies on mathematics, control, and computer sciences. The choice of algorithms usually depends on the specific needs, environment, and objectives of a particular robot.

## Dependencies of Navigation

Navigation primarily depends on the robot having accurate localization and mapping information. This is typically obtained from various sensors (e.g., LIDAR, radar, cameras, IMUs, etc.) and various software (e.g., SLAM, Cartographer, etc.). Also, it relies on the robot's ability to perceive its environment accurately and move accordingly.
