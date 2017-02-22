# IEEE Very Small Size Soccer simulator

Simulator for the IEEE Very Small Size Soccer competition. Developed in Unity and integrated with the ROS environment using the rosbridge suite.

## Running the simulator

Before running the simulator, it is necessary to have [ROS](http://wiki.ros.org/ROS/Installation) and the [rosbridge suite](http://wiki.ros.org/rosbridge_suite) installed, as well as the latest simulator build, which can be found [here](https://drive.google.com/drive/folders/0BwlvQGynHcxZZlJTcWZUazNqT00?usp=sharing). Alternatively, the simulator code can be downloaded and built using the [Unity Engine](https://store.unity.com/). 

To run the simulator, open a terminal window and start roscore (with the `roscore` command). On a new terminal window, start the rosbridge server:

    rosrun rosbridge_server rosbridge_websocket

After that, just run the simulator executable.

Running the simulator before starting the rosbridge server is not a problem, but the simulation won't start until the rosbridge suite has started.

## ROS Message details

All robot positions and their orientations, and the ball position are published on a single ROS message of type "unball/MeasurementSystemMessage", on the topic "measurement_system_topic". The message file can be viewed [here](https://github.com/unball/ieee-very-small/blob/master/software/msg/MeasurementSystemMessage.msg).

Pausing and resuming the simulation publishes a message of type "unball/KeyboardMessage", on the topic "keyboard_topic". Pausing will send the char 'p' and resuming will send the message 'r'. The message file can be viewed [here](https://github.com/unball/ieee-very-small/blob/master/software/msg/KeyboardMessage.msg).

The robots can be controlled by an external application through ROS, by publishing messages of type "communication/robots_speeds_msg", on the topic "robots_speeds". The message file can be viewed [here](https://github.com/unball/communication/blob/master/msg/robots_speeds_msg.msg).

All measurements are received and transmitted according to the [International System of Units](https://en.wikipedia.org/wiki/International_System_of_Units).

## Measurement conventions

1 Unity unit = 0.1 metres = 100 pixels

Developed and maintained by [Gabriel Naves](https://github.com/gabrielnaves)
