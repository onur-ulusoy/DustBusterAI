# Communications

In our project, effective communication between the various components is crucial for the successful operation of our cleaning robot. The communication setup enables the coordination and exchange of data between key elements such as the Arduino Mega microcontroller, Raspberry Pi embedded computer, LIDAR sensor, IMU (Inertial Measurement Unit), DC motors, and motor drivers.

The Arduino Mega is our mainboard and responsible for most of the communications which is a commonly used microcontroller in robotics projects due to its extensive input/output (I/O) capabilities, multiple hardware serial communication ports, and expanded memory capacity. Its user-friendly programming language allows for quick access to a wide range of actuators and sensors.

The communication between the Raspberry Pi and LIDAR sensor is established using the USB interface. USB provides various advantages such as hardware compatibility and high-speed data transfer, enabling seamless integration of different devices into the Raspberry Pi. The USB connection also allows for hot-plugging, facilitating easy connection and disconnection of devices. This choice of USB connection enhances flexibility and rapid prototyping capabilities.

The communication between the LIDAR sensor and Raspberry Pi utilizes the SCIP 2.0 protocol. This standardized protocol ensures data integrity and reliability during the transmission of sensor data. It enables the Raspberry Pi to accurately read and process data from the LIDAR sensor, enhancing detection and environmental mapping capabilities.

The integration of the Arduino and Raspberry Pi combines their respective strengths. The Arduino excels in interacting with a wide range of sensors and actuators, while the Raspberry Pi provides advanced processing capabilities. This connection allows for the creation of a more complex and efficient robotic system.

The communication between the Arduino and Raspberry Pi is established through USB, enabling bidirectional data exchange and efficient data transfer between the two platforms. This serial communication connection can be easily established using programming languages like Python, facilitating integration and extensibility of the code. The use of USB simplifies the development, testing, and optimization of our system.

For more detailed information about the communication configuration, including schematics and component specifications, please visit our Electronics repository:

[DustBusterAI-Electronics](https://github.com/onur-ulusoy/DustBusterAI-Electronics)
