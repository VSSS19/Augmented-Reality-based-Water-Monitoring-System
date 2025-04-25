# Augmented-Reality-based-Water-Monitoring-System

This project focuses on building an interactive water level monitoring system that combines 
the power of Augmented Reality (AR) and the Internet of Things (IoT) to provide real-time 
insights in a visually engaging way. The goal is to make water level monitoring more efficient, 
accurate, and user-friendly—especially in settings where manual checking can be inconvenient 
or impractical. 

At the heart of the system is an ESP8266 microcontroller, which reads data from an 
ultrasonic sensor to measure the water level inside a tank. This data is then sent wirelessly to 
the Firebase Realtime Database, ensuring live updates are available at any time. What sets 
this project apart is its use of AR through Unity, allowing users to scan a marker and 
instantly see a 3D model of the water tank, complete with the current water level rendered 
inside it. 

### Design Approach
The core idea behind this project is to develop a smart and accessible system for monitoring 
water levels using a combination of IoT and Augmented Reality (AR) technologies. The goal 
is to offer users a simple yet powerful way to visualize and track water levels in real time, 
helping them make better decisions about water usage. 

To bring this idea to life, the system uses the ESP8266 (NodeMCU) microcontroller, which is 
both affordable and energy-efficient, and comes with built-in Wi-Fi capabilities—making it 
perfect for wireless communication. An ultrasonic sensor is used to detect the distance from 
the sensor to the water’s surface, helping calculate the exact level of water in the tank. 

All the collected data is sent to a cloud-based database, making it possible to access water 
level information remotely. On the user’s side, an AR-based mobile application built with 
Unity and Vuforia lets them see the water level in a virtual 3D tank just by scanning a marker. 
This makes the data more interactive and easier to understand at a glance, even for people who 
aren't tech-savvy.
