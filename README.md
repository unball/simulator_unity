# IEEE Very Small Size Soccer simulator

Simulator for the IEEE Very Small Size Soccer competition. Developed in Unity and integrated with the ROS environment using the rosbridge suite.

## Running the simulator

In order to run the simulator, it is necessary to have [ROS](http://wiki.ros.org/ROS/Installation) and the [rosbridge suite](http://wiki.ros.org/rosbridge_suite) installed, as well as the latest simulator build, which can be found [here](https://drive.google.com/drive/folders/0BwlvQGynHcxZZlJTcWZUazNqT00?usp=sharing). Alternatively, the simulator code can be downloaded and built using the [Unity Engine](https://store.unity.com/). 

To run the simulator, open a terminal window and start roscore (with the `roscore` command). On a new terminal window, start the rosbridge server:

    rosrun rosbridge_server rosbridge_websocket

After that, just run the simulator executable.

Running the simulator before starting the rosbridge server is not a problem, but the simulation won't start until the rosbridge suite has started.

## Measurement conventions

1 Unity unit = 0.1 metres = 100 pixels

Developed and maintained by [Gabriel Naves](https://github.com/gabrielnaves)
